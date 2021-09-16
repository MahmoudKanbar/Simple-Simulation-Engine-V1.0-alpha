using Assimp;
using OpenTK.Graphics.OpenGL;
using OpenTK.Mathematics;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;
using SixLabors.ImageSharp.Processing;
using System;
using System.Collections.Generic;
using System.IO;


public class SimulationModel
{
    private static Dictionary<string, SimulationModel> simulationModels = new();
    public static SimulationModel CreateByPath(string path)
    {
        string name = Path.GetFileNameWithoutExtension(path);

        if (simulationModels.TryGetValue(name, out SimulationModel newSimulationModel))
            return newSimulationModel;

        newSimulationModel = new SimulationModel(path);
        simulationModels.Add(name, newSimulationModel);
        return newSimulationModel;
    }

    public static SimulationModel CreateByName(string name)
    {
        Console.WriteLine(name);
        if (simulationModels.TryGetValue(name, out SimulationModel newSimulationModel))
            return newSimulationModel;

        string modelsDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\Resources\Models\";
        string path = modelsDirectory + name;

        newSimulationModel = new SimulationModel(path);
        simulationModels.Add(name, newSimulationModel);
        return newSimulationModel;
    }


    // -----------------------------------------------------------------------------
    private readonly LinkedList<SimulationMesh> meshesList;

    public readonly string path;
    public readonly string name;

    public SimulationModel(string modelPath)
    {
        meshesList = new LinkedList<SimulationMesh>();

        path = modelPath;
        name = Path.GetFileNameWithoutExtension(modelPath);

        var importer = new AssimpContext();
        var scene = importer.ImportFile(
            modelPath,
            PostProcessSteps.JoinIdenticalVertices | PostProcessSteps.Triangulate |
            PostProcessSteps.GenerateNormals | PostProcessSteps.GenerateUVCoords |
            PostProcessSteps.SplitLargeMeshes | PostProcessSteps.CalculateTangentSpace
            );

        ProcessNode(scene.RootNode, scene);
    }

    private void ProcessNode(Node node, Scene scene)
    {
        // process the meshes in every node
        foreach (var meshIndex in node.MeshIndices)
        {
            Mesh assimpMesh = scene.Meshes[meshIndex];
            SimulationMesh mesh = ProcessAssimpMesh(assimpMesh, scene);
            meshesList.AddLast(mesh);
        }

        // iterate over all the children
        foreach (var child in node.Children) ProcessNode(child, scene);
    }

    private SimulationMesh ProcessAssimpMesh(Mesh assimpMesh, Scene scene)
    {
        LinkedList<VertexContainer> vertices = new();
        LinkedList<int> indecies = new();
        LinkedList<TextureContainer> textures = new();

        // Getting vertex info
        for (int i = 0; i < assimpMesh.VertexCount; i++)
        {
            VertexContainer vertexContainer = new();

            if (assimpMesh.HasVertices)
            {
                var position = assimpMesh.Vertices[i];
                vertexContainer.position = new Vector3(position.X, position.Y, position.Z);
            }


            //if (assimpMesh.HasVertexColors(0))
            //{
            //    var color = scene.Materials[assimpMesh.MaterialIndex].ColorDiffuse;
            //    var color = assimpMesh.VertexColorChannels[0][i];
            //    vertexContainer.color = new Vector3(color.R, color.G, color.B);
            //}

            var color = scene.Materials[assimpMesh.MaterialIndex].ColorDiffuse;
            vertexContainer.color = new Vector3(color.R, color.G, color.B);

            if (assimpMesh.HasNormals)
            {
                var normal = assimpMesh.Normals[i];
                vertexContainer.normal = new Vector3(normal.X, normal.Y, normal.Z);
            }

            if (assimpMesh.HasTangentBasis)
            {
                var tangant = assimpMesh.Tangents[i];
                vertexContainer.tangent.X = tangant.X;
                vertexContainer.tangent.Y = tangant.Y;
                vertexContainer.tangent.Z = tangant.Z;

                var bitangant = assimpMesh.BiTangents[i];
                vertexContainer.bitangent.X = bitangant.X;
                vertexContainer.bitangent.Y = bitangant.Y;
                vertexContainer.bitangent.Z = bitangant.Z;
            }

            if (assimpMesh.HasTextureCoords(0))
            {
                var UV = assimpMesh.TextureCoordinateChannels[0][i];
                vertexContainer.uv.X = UV.X;
                vertexContainer.uv.Y = UV.Y;
            }


            vertices.AddLast(vertexContainer);
        }

        // Getting indecies

        for (int i = 0; i < assimpMesh.FaceCount; i++)
        {
            var face = assimpMesh.Faces[i];
            if (!face.HasIndices) break;

            for (int j = 0; j < face.IndexCount; j++)
            {
                var index = face.Indices[j];
                indecies.AddLast(index);
            }
        }

        // Getting materials and textures

        Material material = scene.Materials[assimpMesh.MaterialIndex];

        var diffuseTextures = MaterialToTextureContainer(material, TextureType.Diffuse);
        foreach (var textureContainer in diffuseTextures) textures.AddLast(textureContainer);

        var specularTextures = MaterialToTextureContainer(material, TextureType.Specular);
        foreach (var textureContainer in specularTextures) textures.AddLast(textureContainer);

        var heightTextures = MaterialToTextureContainer(material, TextureType.Height);
        foreach (var textureContainer in heightTextures) textures.AddLast(textureContainer);


        return new SimulationMesh(vertices, textures, indecies);
    }

    private readonly Dictionary<string, TextureContainer> loadedTextures = new();

    private LinkedList<TextureContainer> MaterialToTextureContainer(Material material, TextureType textureType)
    {
        LinkedList<TextureContainer> textures = new();

        TextureSlot[] textureSlots = material.GetMaterialTextures(textureType);
        for (int i = 0; i < textureSlots.Length; i++)
        {
            // the texture slot only return the name of the texture WITHOUT the model directory
            string texturePath = Directory.GetParent(path).FullName + @"\" + textureSlots[i].FilePath;
            if (loadedTextures.TryGetValue(texturePath, out TextureContainer textureContainer))
            {
                textures.AddLast(textureContainer);
            }
            else
            {
                textureContainer.type = textureType;
                textureContainer.ID = LoadTextureFromFile(texturePath);

                textures.AddLast(textureContainer);
                loadedTextures.Add(texturePath, textureContainer);
            }
        }

        return textures;
    }

    private static int LoadTextureFromFile(string texturePath)
    {
        int textureID;
        var image = Image.Load<Rgba32>(texturePath);

        image.Mutate(x => x.Flip(FlipMode.Vertical));

        var data = new List<byte>(4 * image.Width * image.Height);

        for (int r = 0; r < image.Height; r++)
        {
            var row = image.GetPixelRowSpan(r);
            for (int c = 0; c < image.Width; c++)
            {
                data.Add(row[c].R);
                data.Add(row[c].G);
                data.Add(row[c].B);
                data.Add(row[c].A);
            }
        }

        textureID = GL.GenTexture();
        GL.BindTexture(TextureTarget.Texture2D, textureID);

        GL.TexImage2D(TextureTarget.Texture2D, 0, PixelInternalFormat.Rgba, image.Width, image.Height, 0, PixelFormat.Rgba, PixelType.UnsignedByte, data.ToArray());

        GL.TextureParameter(textureID, TextureParameterName.TextureMinFilter, (int)TextureMinFilter.Linear);
        GL.TextureParameter(textureID, TextureParameterName.TextureMagFilter, (int)TextureMagFilter.Linear);

        GL.BindTexture(TextureTarget.Texture2D, 0);

        return textureID;
    }


    public void Draw(Shader shader)
    {
        foreach (var mesh in meshesList) mesh.Draw(shader);
    }
}
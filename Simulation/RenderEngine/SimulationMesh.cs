using OpenTK.Graphics.OpenGL;
using OpenTK.Mathematics;
using System.Collections.Generic;
using System;
public struct VertexContainer
{
    public Vector3 position;
    public Vector3 color;
    public Vector3 normal;
    public Vector3 tangent;
    public Vector3 bitangent;
    public Vector2 uv;
}

public struct TextureContainer
{
    public int ID;
    public Assimp.TextureType type;
}

public class SimulationMesh
{
    private readonly LinkedList<VertexContainer> vertexContainers;
    private readonly LinkedList<TextureContainer> textureContainers;
    private readonly LinkedList<int> indecies;

    private readonly int arrayObject;
    private readonly int bufferObject;
    private readonly int elementObject;

    public SimulationMesh(LinkedList<VertexContainer> vertexContainers, LinkedList<TextureContainer> textureContainers, LinkedList<int> indecies)
    {
        this.vertexContainers = vertexContainers;
        this.textureContainers = textureContainers;
        this.indecies = indecies;

        arrayObject = GL.GenVertexArray();
        GL.BindVertexArray(arrayObject);

        // -----------------------------------
        // buffer object stuff
        bufferObject = GL.GenBuffer();
        GL.BindBuffer(BufferTarget.ArrayBuffer, bufferObject);
        // sending the data
        var verticesFloatArray = GetVerticesArray();
        GL.BufferData(BufferTarget.ArrayBuffer, verticesFloatArray.Length * sizeof(float), verticesFloatArray, BufferUsageHint.StaticDraw);
        // positions pointer
        GL.VertexAttribPointer(0, 3, VertexAttribPointerType.Float, false, 17 * sizeof(float), 0);
        GL.EnableVertexAttribArray(0);
        // colors pointer
        GL.VertexAttribPointer(1, 3, VertexAttribPointerType.Float, false, 17 * sizeof(float), 3 * sizeof(float));
        GL.EnableVertexAttribArray(1);
        // normals pointer
        GL.VertexAttribPointer(2, 3, VertexAttribPointerType.Float, false, 17 * sizeof(float), 6 * sizeof(float));
        GL.EnableVertexAttribArray(2);
        // tangent pointer
        GL.VertexAttribPointer(3, 3, VertexAttribPointerType.Float, false, 17 * sizeof(float), 9 * sizeof(float));
        GL.EnableVertexAttribArray(3);
        // bi-tangent pointer
        GL.VertexAttribPointer(4, 3, VertexAttribPointerType.Float, false, 17 * sizeof(float), 12 * sizeof(float));
        GL.EnableVertexAttribArray(4);
        // UV pointer
        GL.VertexAttribPointer(5, 2, VertexAttribPointerType.Float, false, 17 * sizeof(float), 15 * sizeof(float));
        GL.EnableVertexAttribArray(5);
        // -----------------------------------

        // -----------------------------------
        // element buffer stuff
        elementObject = GL.GenBuffer();
        GL.BindBuffer(BufferTarget.ElementArrayBuffer, elementObject);
        // sending the data
        var indeciesArray = GetIndeciesArray();
        GL.BufferData(BufferTarget.ElementArrayBuffer, indeciesArray.Length * sizeof(uint), indeciesArray, BufferUsageHint.StaticDraw);
        // -----------------------------------

        GL.BindVertexArray(0);
    }

    private float[] GetVerticesArray()
    {
        float[] verticesFloatArray = new float[vertexContainers.Count * 17];

        int i = 0;
        foreach (var vertex in vertexContainers)
        {
            // positions
            verticesFloatArray[i] = vertex.position.X;
            verticesFloatArray[i + 1] = vertex.position.Y;
            verticesFloatArray[i + 2] = vertex.position.Z;
            // colors
            verticesFloatArray[i + 3] = vertex.color.X;
            verticesFloatArray[i + 4] = vertex.color.Y;
            verticesFloatArray[i + 5] = vertex.color.Z;
            // normals
            verticesFloatArray[i + 6] = vertex.normal.X;
            verticesFloatArray[i + 7] = vertex.normal.Y;
            verticesFloatArray[i + 8] = vertex.normal.Z;
            // tangents
            verticesFloatArray[i + 9] = vertex.tangent.X;
            verticesFloatArray[i + 10] = vertex.tangent.Y;
            verticesFloatArray[i + 11] = vertex.tangent.Z;
            // bi-tangents
            verticesFloatArray[i + 12] = vertex.bitangent.X;
            verticesFloatArray[i + 13] = vertex.bitangent.Y;
            verticesFloatArray[i + 14] = vertex.bitangent.Z;
            // UVs
            verticesFloatArray[i + 15] = vertex.uv.X;
            verticesFloatArray[i + 16] = vertex.uv.Y;

            i += 17;
        }

        return verticesFloatArray;
    }

    private int[] GetIndeciesArray()
    {
        int[] indeciesArray = new int[indecies.Count];
        indecies.CopyTo(indeciesArray, 0);
        return indeciesArray;
    }

    public void Draw(Shader shader)
    {
        GL.UseProgram(shader.ID);

        // TODO reconsider textures in meshes
        int i = 0;
        bool hasDiffuseMap = false;
        bool hasSpecularMap = false;
        bool hasHeightMap = false;

        foreach (var textureContainer in textureContainers)
        {
            if (textureContainer.type == Assimp.TextureType.Diffuse) hasDiffuseMap = true;
            if (textureContainer.type == Assimp.TextureType.Specular) hasSpecularMap = true;
            if (textureContainer.type == Assimp.TextureType.Height) hasHeightMap = true;

            string uniformName = $"material.{textureContainer.type.ToString().ToLower()}";
            GL.ActiveTexture(TextureUnit.Texture0 + i);
            GL.BindTexture(TextureTarget.Texture2D, textureContainer.ID);
            shader.SetUniform(uniformName, i);
            i += 1;
        }

        shader.SetUniform("hasDiffuseMap", hasDiffuseMap);
        shader.SetUniform("hasSpecularMap", hasSpecularMap);
        shader.SetUniform("hasHeightMap", hasHeightMap);

        GL.BindVertexArray(arrayObject);
        GL.DrawElements(PrimitiveType.Triangles, indecies.Count, DrawElementsType.UnsignedInt, 0);
        GL.BindVertexArray(0);

    }

    ~SimulationMesh()
    {
        GL.DeleteBuffer(bufferObject);
        GL.DeleteBuffer(elementObject);
        GL.DeleteVertexArray(arrayObject);
    }
}
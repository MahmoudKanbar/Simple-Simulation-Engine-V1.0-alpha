using OpenTK.Mathematics;
using OpenTK.Windowing.Desktop;
using System.Collections.Generic;
using System.Linq;
using System;

public enum ShaderName
{
    Global, Debug
}

public class SimulationManager
{

    public Vector3 gravity = new(0f, -10.0f, 0f);

    public float airDensity = 1.225f;
    public float frictionCoK = 10.0f;
    public float frictionCoS = 0.2f;

    public readonly GameWindow gameWindow;
    public readonly string resourcesDirectory;

    public readonly Dictionary<ShaderName, Shader> shadersList;
    public readonly LinkedList<SimulationObject> simulationObjectsList;

    public readonly LinkedList<DebugShape> debugList;
    public readonly LinkedList<Collider> collidersList;
    public readonly LinkedList<Camera> camerasList;

    // lights
    public int directionalLightsCount;
    public int pointLightsCount;
    public int spotLightsCount;
    public readonly LinkedList<Light> lights;

    public Camera CurrentCamera { get; private set; }

    public Vector4 debugColor = new Vector4(1, 0, 0, 1);
    public bool showColliders = true;
    public bool showObjects = true;

    // delta time stuff
    public float timeScale = 0f;
    public float DeltaTime
    {
        get
        {
            return (float)gameWindow.RenderTime * timeScale;
        }
    }


    public SimulationManager(GameWindow gameWindow, string resourcesDirectory)
    {
        this.gameWindow = gameWindow;
        this.resourcesDirectory = resourcesDirectory;

        shadersList = new Dictionary<ShaderName, Shader>();
        simulationObjectsList = new LinkedList<SimulationObject>();

        lights = new LinkedList<Light>();
        collidersList = new LinkedList<Collider>();
        camerasList = new LinkedList<Camera>();

        var debugShader = new Shader(resourcesDirectory + @"\Shaders\debug_shader.vert", resourcesDirectory + @"\Shaders\debug_shader.frag");
        var globalShader = new Shader(resourcesDirectory + @"\Shaders\global_shader.vert", resourcesDirectory + @"\Shaders\global_shader.frag");

        shadersList.TryAdd(ShaderName.Debug, debugShader);
        shadersList.TryAdd(ShaderName.Global, globalShader);
    }

    public Shader GetShader(ShaderName shaderName)
    {
        if (shadersList.TryGetValue(shaderName, out Shader usedShader)) return usedShader;
        return null;
    }

    public void SetCurrentCamera(string cameraName)
    {
        foreach (var camera in camerasList)
        {
            if (camera.simulationObject.name == cameraName)
            {
                CurrentCamera = camera;
                break;
            }
        }
    }
    public void SwitchCamera()
    {
        if (CurrentCamera == null)
        {
            if (camerasList.Count > 0) CurrentCamera = camerasList.First.Value;
            return;
        }

        for (var node = camerasList.First; node != null; node = node.Next)
        {
            if (node.Value == CurrentCamera)
            {
                if (node.Next == null) CurrentCamera = camerasList.First.Value;
                else CurrentCamera = node.Next.Value;
                break;
            }
        }
    }
    public void ChangeProjection()
    {
        if (CurrentCamera == null) return;
        if (CurrentCamera.projectionType == ProjectionType.Perspective) CurrentCamera.projectionType = ProjectionType.Orthographic;
        else CurrentCamera.projectionType = ProjectionType.Perspective;
    }


    public void UpdateCycle()
    {
        // ------------------------------------------------------------------------------------
        // update physics and transforms

        foreach (var simulationObject in simulationObjectsList)
        {
            var rigidBody = simulationObject.GetComponent<RigidBody>();
            var transform = simulationObject.transform;

            if (rigidBody != null) rigidBody.Update();
            transform.Update();
        }


        // ------------------------------------------------------------------------------------
        // update collisions

        foreach (var collider in collidersList) collider.collidedWithSet = new HashSet<Collider>();

        var collidersArray = collidersList.ToArray();
        for (int i = 0; i < collidersArray.Length; i++)
        {
            for (int j = i + 1; j < collidersArray.Length; j++)
            {
                var leftCollider = collidersArray[i];
                var rightCollider = collidersArray[j];
                var collisionHappened = false;
                CollisionData collisionData = null;

                if (leftCollider is SphereCollider && rightCollider is SphereCollider)
                    collisionHappened = CheckCollision(leftCollider as SphereCollider, rightCollider as SphereCollider, ref collisionData);
                if (leftCollider is BoxCollider && rightCollider is BoxCollider)
                    collisionHappened = CheckCollision(leftCollider as BoxCollider, rightCollider as BoxCollider);
                if (leftCollider is SphereCollider && rightCollider is BoxCollider)
                    collisionHappened = CheckCollision(leftCollider as SphereCollider, rightCollider as BoxCollider, ref collisionData);
                if (leftCollider is BoxCollider && rightCollider is SphereCollider)
                    collisionHappened = CheckCollision(rightCollider as SphereCollider, leftCollider as BoxCollider, ref collisionData);

                if (collisionHappened) Physics.ManageCollision(leftCollider, rightCollider, this, in collisionData);
            }
        }

        // ------------------------------------------------------------------------------------
        // rendering

        if (CurrentCamera == null) return;
        if (!showColliders && !showObjects) return;

        Shader globalShader = GetShader(ShaderName.Global);
        Shader debugShader = GetShader(ShaderName.Debug);

        globalShader.SetUniform("view_position", CurrentCamera.transform.position);
        globalShader.SetUniform("view", CurrentCamera.ViewMatrix);
        globalShader.SetUniform("projection", CurrentCamera.ProjectionMatrix);

        debugShader.SetUniform("view", CurrentCamera.ViewMatrix);
        debugShader.SetUniform("projection", CurrentCamera.ProjectionMatrix);

        globalShader.SetUniform("directionalLightsCount", directionalLightsCount);
        globalShader.SetUniform("pointLightsCount", pointLightsCount);
        globalShader.SetUniform("spotLightsCount", spotLightsCount);


        int directionalLightsCounter = 0;
        int pointLightsCounter = 0;
        int spotLightsCounter = 0;
        foreach (var light in lights)
        {
            string lightName = string.Empty;
            if (light is DirectionalLight) lightName = $"directionalLightsList[{directionalLightsCounter++}]";
            if (light is PointLight) lightName = $"pointLightsList[{pointLightsCounter++}]";
            if (light is SpotLight) lightName = $"spotLightsList[{spotLightsCounter++}]";
            light.SetInShader(globalShader, lightName);
        }

        if (showObjects)
        {
            foreach (var simulationObject in simulationObjectsList)
            {
                var modelRenderer = simulationObject.GetComponent<ModelRenderer>();
                if (modelRenderer != null)
                {
                    modelRenderer.Draw(globalShader);
                }
            }
        }

        if (showColliders)
        {
            foreach (var collider in collidersList)
            {
                collider.Draw(debugColor);
            }
        }
    }

    private bool CheckCollision(SphereCollider sphere1, SphereCollider sphere2, ref CollisionData collisionData)
    {
        var distance = (sphere1.ActualCenter - sphere2.ActualCenter).Length;
        var radiusSum = sphere1.Radius + sphere2.Radius;
        bool isIntersect = distance < radiusSum;

        if(isIntersect)
        {
            collisionData = new CollisionData
            {
                normal = (sphere1.ActualCenter - sphere2.ActualCenter).Normalized(),
                point = (sphere1.ActualCenter - sphere2.ActualCenter).Normalized() * sphere1.Radius,
                intersectionAmount = distance - radiusSum
            };
            return true;
        }

        return false;
    }

    private bool CheckCollision(BoxCollider box1, BoxCollider box2)
    {
        bool noIntersection = false;
        // building box 1 axes
        var box1Vertices = box1.Vertices;
        Vector3[] box1Axes = new Vector3[3];
        box1Axes[0] = box1Vertices[7] - box1Vertices[4]; box1Axes[0].Normalize();
        box1Axes[1] = box1Vertices[5] - box1Vertices[4]; box1Axes[1].Normalize();
        box1Axes[2] = box1Vertices[0] - box1Vertices[4]; box1Axes[2].Normalize();

        // building box 1 axes
        var box2Vertices = box2.Vertices;
        Vector3[] box2Axes = new Vector3[3];
        box2Axes[0] = box2Vertices[7] - box2Vertices[4]; box2Axes[0].Normalize();
        box2Axes[1] = box2Vertices[5] - box2Vertices[4]; box2Axes[1].Normalize();
        box2Axes[2] = box2Vertices[0] - box2Vertices[4]; box2Axes[2].Normalize();

        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                // ensure that the axis is not aligned
                if (MathHelper.Abs(Vector3.Dot(box1Axes[i], box2Axes[j])) == 1) continue;

                float min1 = float.PositiveInfinity, max1 = float.NegativeInfinity;
                float min2 = float.PositiveInfinity, max2 = float.NegativeInfinity;
                Vector3 newAxis = Vector3.Cross(box1Axes[i], box2Axes[j]).Normalized();
                for (int k = 0; k < 8; k++)
                {
                    // find min
                    if (Vector3.Dot(box1Vertices[k], newAxis) < min1) min1 = Vector3.Dot(box1Vertices[k], newAxis);
                    if (Vector3.Dot(box2Vertices[k], newAxis) < min2) min2 = Vector3.Dot(box2Vertices[k], newAxis);
                    // find max
                    if (Vector3.Dot(box1Vertices[k], newAxis) > max1) max1 = Vector3.Dot(box1Vertices[k], newAxis);
                    if (Vector3.Dot(box2Vertices[k], newAxis) > max2) max2 = Vector3.Dot(box2Vertices[k], newAxis);
                }
                noIntersection |= min1 > max2 || min2 > max1;
            }
        }

        return !noIntersection;
    }

    private bool CheckCollision(SphereCollider sphere, BoxCollider box, ref CollisionData collisionData)
    {
        Vector3[] boxVertices = box.Vertices;
        Vector3[] boxAxes = new Vector3[3];
        boxAxes[0] = boxVertices[7] - boxVertices[4]; boxAxes[0].Normalize();
        boxAxes[1] = boxVertices[5] - boxVertices[4]; boxAxes[1].Normalize();
        boxAxes[2] = boxVertices[0] - boxVertices[4]; boxAxes[2].Normalize();

        bool noIntersection = false;
        for (int i = 0; i < boxAxes.Length; i++)
        {
            float minSphere = Vector3.Dot(boxAxes[i], sphere.ActualCenter) - sphere.Radius;
            float maxSphere = Vector3.Dot(boxAxes[i], sphere.ActualCenter) + sphere.Radius;

            float minBox = float.PositiveInfinity;
            float maxBox = float.NegativeInfinity;
            for (int j = 0; j < boxVertices.Length; j++)
            {
                var temp = Vector3.Dot(boxAxes[i], boxVertices[j]);
                if (temp < minBox) minBox = temp;
                if (temp > maxBox) maxBox = temp;
            }
            noIntersection |= minBox > maxSphere || minSphere  > maxBox;
        }

        if(!noIntersection)
        {
            // check vertex intersection
            //foreach (var vertex in boxVertices)
            //{
            //    var distance = (sphere.ActualCenter - vertex).Length;
            //    if(distance <= sphere.Radius)
            //    {
            //        collisionData = new CollisionData
            //        {
            //            normal = (sphere.ActualCenter - vertex).Normalized(),
            //            point = sphere.ActualCenter - (sphere.ActualCenter - vertex).Normalized() * sphere.Radius,
            //            intersectionAmount = sphere.Radius - distance
            //        };
            //        return true;
            //    }
            //}

            // check face intersection
            var planes = box.Planes;
            foreach(var plane in planes)
            {
                float sphereToPlane = plane.GetDistance(sphere.ActualCenter);
                if(sphereToPlane <= sphere.Radius)
                {
                    Ray ray = new Ray { position = sphere.ActualCenter, direction = -plane.normal };
                    RayCast(ray, out RayCastHit rayCastHit);
                    collisionData = new CollisionData
                    {
                        normal = plane.normal,
                        //point = sphere.ActualCenter - plane.normal * sphere.Radius,
                        point = rayCastHit.hitPoint,
                        intersectionAmount = sphere.Radius - sphereToPlane
                    };
                    return true;
                }
            }

            // check edge intersection
            var edges = box.Edges;
            foreach (var edge in edges)
            {
                var D = edge.direction;
                var V = edge.start - sphere.ActualCenter;
                var delta = (2 * Vector3.Dot(D, V)) * (2 * Vector3.Dot(D, V)) - 4 * Vector3.Dot(D, D) * (Vector3.Dot(V, V) - sphere.Radius * sphere.Radius);
                if (delta >= 0)
                {
                    var squareDelta = (float)MathHelper.Sqrt(delta);
                    var t1 = (-2 * Vector3.Dot(D, V) + squareDelta) / (2 * Vector3.Dot(D, D)); var p1 = t1 * D + edge.start;
                    var t2 = (-2 * Vector3.Dot(D, V) - squareDelta) / (2 * Vector3.Dot(D, D)); var p2 = t2 * D + edge.start;

                    collisionData = new CollisionData
                    {
                        normal = (sphere.ActualCenter + (p1 + p2) / 2).Normalized(),
                        point = sphere.ActualCenter + (sphere.ActualCenter + (p1 + p2) / 2).Normalized() * sphere.Radius,
                        intersectionAmount = sphere.Radius - (sphere.ActualCenter + (p1 + p2) / 2).Length
                    };
                    return true;
                }
            }

            return true;
        }

        return false;
    }


    public bool RayCast(Ray ray, out RayCastHit rayCastHit)
    {
        foreach (var temp in collidersList)
        {
            if (temp.Intersect(ray, out Vector3 point))
            {
                rayCastHit = new RayCastHit
                {
                    hitPoint = point,
                    collider = temp,
                    distance = (point - ray.position).Length
                };
                return true;
            }
        }

        rayCastHit = default;
        return false;
    }
}


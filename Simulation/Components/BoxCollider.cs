using OpenTK.Mathematics;
using System;

public class BoxCollider : Collider
{
    public Vector3 HalfExterns;
    public Vector3[] Vertices
    {
        get
        {
            Vector3[] vertices = new Vector3[8];
            for (int i = 0; i < vertices.Length; i++)
            {
                vertices[i] = ActualCenter + (transform.rotationMatrix * new Vector4(_UnitBoxVertices[i] * HalfExterns, 1.0f)).Xyz;
            }
            return vertices;
        }
    }

    private static readonly Vector3[] _UnitBoxVertices =
    {
         new Vector3(-1f, -1f, 1),
         new Vector3(-1f, 1f, 1),
         new Vector3(1f, 1f, 1),
         new Vector3(1f, -1f, 1),
         new Vector3(-1f, -1f, -1),
         new Vector3(-1f, 1f, -1),
         new Vector3(1f, 1f, -1),
         new Vector3(1f, -1f, -1)
    };

    private static readonly int[] _PlanesQuadsIndices =
    {
        0,  1,  2,  3,
        4,  5,  6,  7,
        6,  2,  3,  7,
        0,  1,  5,  4,
        0,  4,  7,  3,
        1,  5,  6,  2
    };

    private static readonly int[] _EdgesIndices =
    {
        0, 3,
        0, 1,
        0, 4,
        1, 5,
        1, 2,
        2, 6,
        2, 3,
        3, 7,
        4, 7,
        4, 5,
        5, 6,
        6, 7
    };

    public Plane[] Planes
    {
        get
        {
            Vector3[] tempVertices = Vertices;
            Plane[] tempPlanes = new Plane[6];

            int pNumber = 0;
            for (int i = 0; i < _PlanesQuadsIndices.Length; i += 4)
            {
                var a = tempVertices[_PlanesQuadsIndices[i]];
                var b = tempVertices[_PlanesQuadsIndices[i + 1]];
                var c = tempVertices[_PlanesQuadsIndices[i + 2]];
                var d = tempVertices[_PlanesQuadsIndices[i + 3]];

                tempPlanes[pNumber] = new Plane(a, b, c, d, ActualCenter);
                pNumber++;
            }

            return tempPlanes;
        }
    }

    public Edge[] Edges
    {
        get
        {
            Vector3[] tempVertices = Vertices;
            Edge[] temp = new Edge[12];
            int eNumber = 0;
            for (int i = 0; i < _EdgesIndices.Length; i += 2)
            {
                var a = tempVertices[_EdgesIndices[i]];
                var b = tempVertices[_EdgesIndices[i + 1]];
                temp[eNumber] = new Edge(a, b);
                eNumber++;
            }
            return temp;
        }
    }


    public BoxCollider(Transform transform, SimulationObject simulationObject) : base(transform, simulationObject)
    {
        HalfExterns = Vector3.One;
        colliderShape = new WiredBox();
    }

    public override bool Intersect(Ray ray, out Vector3 point)
    {
        Vector3[] tempVertices = Vertices;
        Vector3 nearestPoint = Vector3.PositiveInfinity;
        bool intersect = false;
        for (int i = 0; i < _PlanesQuadsIndices.Length; i += 4)
        {
            var a = tempVertices[_PlanesQuadsIndices[i]];
            var b = tempVertices[_PlanesQuadsIndices[i + 1]];
            var c = tempVertices[_PlanesQuadsIndices[i + 2]];
            var d = tempVertices[_PlanesQuadsIndices[i + 3]];

            if (Plane.Intersect(ray, a, b, c, d, out Vector3 intersectionPoint))
            {
                intersect = true;
                float intersectionPointDistance = (ray.position - intersectionPoint).Length;
                float nearestPointDistance = (ray.position - nearestPoint).Length;
                if (intersectionPointDistance < nearestPointDistance) nearestPoint = intersectionPoint;
            }
        }

        point = nearestPoint;
        return intersect;
    }



    public override void Draw(Vector4 color)
    {
        if (colliderShape == null) return;
        var mat = Matrix4.CreateScale(HalfExterns) * transform.rotationMatrix.Inverted() * transform.translationMatrix;
        colliderShape.Draw(mat, simulationObject.simulationManager.GetShader(ShaderName.Debug), color);
    }
}
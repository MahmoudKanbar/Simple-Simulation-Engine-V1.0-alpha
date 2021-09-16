using OpenTK.Mathematics;
using System;
public class WiredBox : DebugShape
{
    public WiredBox()
    {
        vertices = new float[]
        {
             -1f, -1f, 1,
             -1f, 1f, 1,
             1f, 1f, 1,
             1f, -1f, 1,

             -1f, -1f, -1,
             -1f, 1f, -1,
             1f, 1f, -1,
             1f, -1f, -1
        };

        indices = new int[]
        {
            0, 1,   1, 2,   2, 3,   3, 0,
            4, 5,   5, 6,   6, 7,   7, 4,
            1, 5,   2, 6,   3, 7,   0, 4
        };

        //// making half externs
        //for (int i = 0; i < vertices.Length; i += 3)
        //{
        //    vertices[i] *= halfExterns.X;
        //    vertices[i + 1] *= halfExterns.Y;
        //    vertices[i + 2] *= halfExterns.Z;
        //}

        Initialize();
    }

    public WiredBox(Vector3[] vertices)
    {
        this.vertices = new float[24];
        for (int i = 0; i < 8; i++)
        {
            Console.WriteLine(vertices[i]);
        }


            for (int i = 0; i < 8; i++)
        {
            this.vertices[i] = vertices[i].X;
            this.vertices[i + 1] = vertices[i].Y;
            this.vertices[i + 2] = vertices[i].Z;
        }

        indices = new int[]
        {
            0, 1,   1, 2,   2, 3,   3, 0,
            4, 5,   5, 6,   6, 7,   7, 4,
            1, 5,   2, 6,   3, 7,   0, 4
        };

        Initialize();
    }
}

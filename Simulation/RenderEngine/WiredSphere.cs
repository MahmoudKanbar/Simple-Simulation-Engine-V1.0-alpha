using OpenTK.Mathematics;
using System;
using System.Collections.Generic;
using System.Linq;

public class WiredSphere : DebugShape
{
    public static readonly float STEP = MathHelper.DegreesToRadians(5f);
    public WiredSphere(float radius)
    {
        int capacity = (int)(MathHelper.TwoPi / STEP) * 2;
        vertices = new float[capacity * 3];
        LinkedList<int> indices = new LinkedList<int>();

        for (int i = 1; i < capacity; i++)
        {
            if (i == capacity / 2) continue;
            indices.AddLast(i - 1);
            indices.AddLast(i);
        }
        indices.AddLast(capacity / 2 - 1);
        indices.AddLast(0);

        indices.AddLast(capacity - 1);
        indices.AddLast(capacity / 2);

        float angel = 0f;
        int index = 0;
        while (angel < MathHelper.TwoPi && index < vertices.Length / 2)
        {
            vertices[index] = 0;
            vertices[index + 1] = radius * MathF.Sin(angel);
            vertices[index + 2] = radius * MathF.Cos(angel);

            vertices[vertices.Length / 2 + index] = radius * MathF.Cos(angel);
            vertices[vertices.Length / 2 + index + 1] = 0;
            vertices[vertices.Length / 2 + index + 2] = radius * MathF.Sin(angel);

            index += 3;
            angel += STEP;
        }

        this.indices = indices.ToArray();

        Initialize();
    }
}


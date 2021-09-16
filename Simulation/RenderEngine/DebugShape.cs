using OpenTK.Graphics.OpenGL;
using OpenTK.Mathematics;
public abstract class DebugShape
{
    protected int vertexArray;
    protected int vertexBuffer;
    protected int elementBuffer;

    protected float[] vertices;
    protected int[] indices;

    public virtual void Draw(Matrix4 model, Shader shader, Vector4 color)
    {
        shader.SetUniform("model", model);
        shader.SetUniform("color", color);

        GL.BindVertexArray(vertexArray);
        GL.DrawElements(PrimitiveType.Lines, indices.Length, DrawElementsType.UnsignedInt, 0);
        GL.BindVertexArray(0);
    }

    protected virtual void Initialize()
    {
        vertexArray = GL.GenVertexArray();
        GL.BindVertexArray(vertexArray);

        vertexBuffer = GL.GenBuffer();
        GL.BindBuffer(BufferTarget.ArrayBuffer, vertexBuffer);

        GL.BufferData(BufferTarget.ArrayBuffer, sizeof(float) * vertices.Length, vertices, BufferUsageHint.StaticDraw);
        GL.VertexAttribPointer(0, 3, VertexAttribPointerType.Float, false, 3 * sizeof(float), 0);
        GL.EnableVertexAttribArray(0);

        elementBuffer = GL.GenBuffer();
        GL.BindBuffer(BufferTarget.ElementArrayBuffer, elementBuffer);
        GL.BufferData(BufferTarget.ElementArrayBuffer, sizeof(float) * indices.Length, indices, BufferUsageHint.StaticDraw);

        GL.BindBuffer(BufferTarget.ArrayBuffer, 0);
        GL.BindVertexArray(0);
    }
}


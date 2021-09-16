
using OpenTK.Graphics.OpenGL;
using OpenTK.Mathematics;

public class LineSegment : DebugShape
{
    public readonly float thickness;
    public readonly float duration;
    public readonly Vector3 origin;
    public readonly Vector3 direction;
    public LineSegment(Vector3 origin, Vector3 direction, float thickness, float duration)
    {
        vertices = new float[]
        {
            origin.X, origin.Y, origin.Z,
            origin.X + direction.X, origin.Y + direction.Y, origin.Z + direction.Z
        };
        indices = new int[] { 0, 1 };

        this.origin = origin;
        this.direction = direction;
        this.thickness = thickness;
        this.duration = duration;

        Initialize();
    }

    public override void Draw(Matrix4 model, Shader shader, Vector4 color)
    {
        GL.LineWidth(thickness);
        base.Draw(model, shader, color);
        GL.LineWidth(1);
    }
}

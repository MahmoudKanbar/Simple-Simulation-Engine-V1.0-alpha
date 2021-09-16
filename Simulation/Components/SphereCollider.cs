using System;
using OpenTK.Mathematics;

public class SphereCollider : Collider
{
    private float _Radius;
    public float Radius
    {
        get
        {
            return _Radius;
        }
        set
        {
            _Radius = value;
            colliderShape = new WiredSphere(value);
        }
    }

    public SphereCollider(Transform transform, SimulationObject simulationObject) : base(transform, simulationObject)
    {
        Radius = 1.0f;
    }

    public override bool Intersect(Ray ray, out Vector3 point)
    {
        var D = ray.direction;
        var V = ray.position - ActualCenter;
        var delta = (2 * Vector3.Dot(D, V)) * (2 * Vector3.Dot(D, V)) - 4 * Vector3.Dot(D, D) * (Vector3.Dot(V, V) - Radius * Radius);
        if (delta >= 0)
        {
            var squareDelta = (float)MathHelper.Sqrt(delta);
            var t1 = (-2 * Vector3.Dot(D, V) + squareDelta) / (2 * Vector3.Dot(D, D)); var p1 = t1 * D + ray.position;
            var t2 = (-2 * Vector3.Dot(D, V) - squareDelta) / (2 * Vector3.Dot(D, D)); var p2 = t2 * D + ray.position;

            if ((p1 - ray.position).Length <= (p2 - ray.position).Length) point = p1;
            else point = p2;

            return true;
        }

        point = Vector3.NegativeInfinity;
        return false;
    }

    public override void Draw(Vector4 color)
    {
        if (colliderShape == null) return;
        colliderShape.Draw(transform.modelRT , simulationObject.simulationManager.GetShader(ShaderName.Debug), color);
    }
}
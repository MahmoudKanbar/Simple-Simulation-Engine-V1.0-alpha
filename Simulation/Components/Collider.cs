using OpenTK.Mathematics;
using System.Collections.Generic;

public abstract class Collider : Component
{
    public HashSet<Collider> collidedWithSet;
    public DebugShape colliderShape;

    public Vector3 RelativeCenter { get; set; }
    public Vector3 ActualCenter => transform.position + RelativeCenter;


    public Collider(Transform transform, SimulationObject simulationObject) : base(transform, simulationObject)
    {
        collidedWithSet = new HashSet<Collider>();
        RelativeCenter = Vector3.Zero;
        simulationObject.simulationManager.collidersList.AddLast(this);
    }

    public abstract bool Intersect(Ray ray, out Vector3 point);

    public abstract void Draw(Vector4 color);
}
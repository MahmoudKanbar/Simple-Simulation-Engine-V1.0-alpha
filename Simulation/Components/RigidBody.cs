using OpenTK.Mathematics;
using System;

public class RigidBody : Component
{
    public float shapeCoefficient;
    public float mass;

    public Vector3 linearVelocity;
    public Vector3 linearAcceleration;
    public Vector3 force;

    public Vector3 rotationAix;
    public Vector3 angularMomentum;
    public Vector3 angularVelocity;
    public Vector3 angularAcceleration;
    public Vector3 torque;

    public Matrix3 inertiaTensor;
    public Matrix3 inverseInertiaTensor;

    public bool isStatic;
    public bool disableGravity;

    public Vector3 externalForce;
    public Vector3 externalTorque;

    public RigidBody(Transform transform, SimulationObject simulationObject) : base(transform, simulationObject)
    {
        mass = 1f;
        shapeCoefficient = 0.47f;

        linearVelocity = Vector3.Zero;
        linearAcceleration = Vector3.Zero;
        force = Vector3.Zero;

        rotationAix = Vector3.UnitY;
        angularMomentum = Vector3.Zero;
        angularVelocity = Vector3.Zero;
        angularAcceleration = Vector3.Zero;
        torque = Vector3.Zero;

        CalculateInertiaTensor();

        isStatic = false;
        disableGravity = false;
    }

    public void Update()
    {
        if (isStatic) return;

        float deltaTime = simulationObject.simulationManager.DeltaTime;

        if(!disableGravity) force += simulationObject.simulationManager.gravity * mass;
        ApplyDrag();
        ApplyMagnus();

        force += externalForce;
        torque += externalTorque;

        linearAcceleration = force / mass;
        linearVelocity += linearAcceleration * deltaTime;
        transform.position += linearVelocity * deltaTime;


        angularAcceleration = inverseInertiaTensor * torque;
        angularVelocity += angularAcceleration * deltaTime;

        transform.rotation *= new Quaternion(angularVelocity * deltaTime);

        force = Vector3.Zero;
        torque = Vector3.Zero;
    }


    private void CalculateInertiaTensor()
    {
        Collider collider = simulationObject.GetComponent<Collider>();

        if (collider is SphereCollider sphereCollider)
        {
            float r = sphereCollider.Radius;
            var temp = Matrix3.Identity;

            temp.Diagonal = Vector3.One * (0.4f * mass * r * r);
            inertiaTensor = temp;
        }
        else if (collider is BoxCollider boxCollider)
        {
            float W = boxCollider.HalfExterns.X * 2;
            float H = boxCollider.HalfExterns.Y * 2;
            float D = boxCollider.HalfExterns.Z * 2;

            float Ixx = mass * (H * H + D * D) / 12f;
            float Iyy = mass * (W * W + D * D) / 12f;
            float Izz = mass * (W * W + H * H) / 12f;

            var temp = Matrix3.Identity;
            temp.Diagonal = new Vector3(Ixx, Iyy, Izz);
            inertiaTensor = temp;
        }
        else
        {
            inertiaTensor = Matrix3.Identity;
        }

        inverseInertiaTensor = inertiaTensor.Inverted();
    }

    private void ApplyMagnus()
    {
        if (simulationObject.GetComponent<SphereCollider>() == null) return;
        float vTan = simulationObject.GetComponent<SphereCollider>().Radius * angularVelocity.Length;
        float magnusCoefficient = 1 / (2 + (linearVelocity.Length / vTan));
        var magnusForce = 0.5f * (simulationObject.simulationManager.airDensity) * GetArea() * magnusCoefficient * Vector3.Cross(angularVelocity, linearVelocity).Normalized();
        if (float.IsNaN(magnusForce.X))
        {
            magnusForce.X = 0;
        }
        if (float.IsNaN(magnusForce.Y))
        {
            magnusForce.Y = 0;
        }
        if (float.IsNaN(magnusForce.Z))
        {
            magnusForce.Z = 0;
        }
        force += magnusForce;
    }

    private void ApplyDrag()
    {
        SphereCollider collider = (simulationObject.GetComponent<Collider>() as SphereCollider);

        Vector3 dragForce = Vector3.Zero;
        Vector3 normal = linearVelocity.Normalized();
        if (linearVelocity == Vector3.Zero)
        {
            normal = Vector3.Zero;
        }
        dragForce = -0.5f * simulationObject.simulationManager.airDensity * linearVelocity.LengthSquared * GetArea() * shapeCoefficient * normal;
        force += dragForce;

        Vector3 wnormal = angularVelocity.Normalized();

        Vector3 dragTorque = Vector3.Zero;
        dragTorque = -0.5f * simulationObject.simulationManager.airDensity * angularVelocity.LengthSquared * GetArea() * shapeCoefficient * wnormal;

        if (float.IsNaN(dragTorque.X))
        {
            dragTorque.X = 0;
            //angularVelocity.X %= (2 * MathHelper.Pi);
        }
        if (float.IsNaN(dragTorque.Y))
        {
            dragTorque.Y = 0;
            //angularVelocity.Y %= (2 * MathHelper.Pi);
        }
        if (float.IsNaN(dragTorque.Z))
        {
            dragTorque.Z = 0;
            //angularVelocity.Z %= (2 * MathHelper.Pi);
        }

        torque += dragTorque;
    }
    private float GetArea()
    {
        Collider collider = simulationObject.GetComponent<Collider>();
        if (collider is SphereCollider sphereCollider)
        {
            return MathHelper.Pi * sphereCollider.Radius * sphereCollider.Radius;
        }
        else if (collider is BoxCollider boxCollider)
        {

        }

        return 1;
    }
}
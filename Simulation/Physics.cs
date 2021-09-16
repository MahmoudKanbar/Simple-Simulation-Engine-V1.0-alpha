using OpenTK.Mathematics;
using System;

public struct Ray
{
    public Vector3 position;
    public Vector3 direction;
}

public struct RayCastHit
{
    public Vector3 hitPoint;
    public float distance;
    public Collider collider;
}

public static class Physics
{
    public static void ManageCollision(Collider collider1, Collider collider2, SimulationManager simulationManager, in CollisionData collisionData)
    {
        collider1.collidedWithSet.Add(collider2);
        collider2.collidedWithSet.Add(collider1);

        Console.WriteLine($"Collision Detected :: {collider1.simulationObject.name} with {collider2.simulationObject.name}");

        float deltaTime = simulationManager.DeltaTime;

        // collision response
        RigidBody rigid1 = collider1.simulationObject.GetComponent<RigidBody>();
        RigidBody rigid2 = collider2.simulationObject.GetComponent<RigidBody>();
        if (rigid1 == null || rigid2 == null) return;

        float m1 = rigid1.mass, m2 = rigid2.mass;
        Vector3 u1 = rigid1.linearVelocity, u2 = rigid2.linearVelocity;
        Vector3 f1 = rigid1.force, f2 = rigid2.force;


        Vector3 center1 = collider1.ActualCenter, center2 = collider2.ActualCenter;


        if (collisionData == null)
        {
            Vector3 v1 = u1 - (2 * m2 * Vector3.Dot(u1 - u2, center1 - center2) * (center1 - center2)) / ((m1 + m2) * (center1 - center2).LengthSquared);
            Vector3 v2 = u2 - (2 * m1 * Vector3.Dot(u2 - u1, center2 - center1) * (center2 - center1)) / ((m1 + m2) * (center2 - center1).LengthSquared);
            rigid1.linearVelocity = v1;
            rigid2.linearVelocity = v2;
        }
        else
        {
            float ia = collisionData.intersectionAmount;
            Vector3 n1 = collisionData.normal, n2 = collisionData.normal;
            if (Vector3.Dot(n1, collider1.ActualCenter) > 0) n1 = -n1;
            if (Vector3.Dot(n2, collider2.ActualCenter) > 0) n2 = -n2;

            Vector3 faceR1 = Vector3.Dot(n1, f2) * n1 * ia;
            Vector3 faceR2 = Vector3.Dot(n2, f1) * n2 * ia;

            Vector3 r1 = collisionData.point - collider1.ActualCenter;
            Vector3 r2 = collisionData.point - collider2.ActualCenter;

            Vector3 t1 = -Vector3.Cross(collisionData.point - collider1.ActualCenter, u1) * simulationManager.frictionCoK;
            Vector3 t2 = -Vector3.Cross(collisionData.point - collider2.ActualCenter, u2) * simulationManager.frictionCoK;

            //float p1 = (m1 * u1).Length, p2 = (m2 * u2).Length, p = p1 + p2;
            //collider1.transform.position += (ia * (p1 / p) * n1) * deltaTime;
            //collider2.transform.position += (ia * (p2 / p) * n2) * deltaTime;
            SolveIntersections(collider1, collider2, collisionData.point, n1, n2, ia);
            Vector3 v1 = u1 - (2 * m2 * Vector3.Dot(u1 - u2, n1) * n1) / (m1 + m2);
            Vector3 v2 = u2 - (2 * m1 * Vector3.Dot(u2 - u1, n2) * n2) / (m1 + m2);

            rigid1.linearVelocity = v1; rigid1.angularVelocity += rigid1.inverseInertiaTensor * t1 * deltaTime * deltaTime; /*rigid1.force += faceR1 * deltaTime;*/
            rigid2.linearVelocity = v2; rigid2.angularVelocity += rigid2.inverseInertiaTensor * t2 * deltaTime * deltaTime; /*rigid2.force += faceR2 * deltaTime;*/
        }
    }
    private static void SolveIntersections(Collider collider1, Collider collider2, Vector3 point, Vector3 n1, Vector3 n2, float ia)
    {
        if (collider1 is SphereCollider && collider2 is SphereCollider)
        {
            var pos1 = collider1.simulationObject.transform.position;
            var pos2 = collider2.simulationObject.transform.position;
            float intersection = (((collider1 as SphereCollider).Radius + (collider2 as SphereCollider).Radius) - (pos1 - pos2).Length);

            RigidBody rigid1 = collider1.simulationObject.GetComponent<RigidBody>();
            RigidBody rigid2 = collider2.simulationObject.GetComponent<RigidBody>();
            if (rigid1 == null || rigid2 == null) return;

            float m1 = rigid1.mass, m2 = rigid2.mass;
            Vector3 u1 = rigid1.linearVelocity, u2 = rigid2.linearVelocity;

            float p1 = u1.Length;

            float p2 = u2.Length;

            float segmaP = p1 + p2;
            if (!rigid1.isStatic)
                collider1.simulationObject.transform.position += ((p1 / segmaP) * (collider1 as SphereCollider).Radius * (pos1 - pos2).Normalized() * intersection);
            if (!rigid2.isStatic)
                collider2.simulationObject.transform.position += ((p2 / segmaP) * (collider2 as SphereCollider).Radius * (pos2 - pos1).Normalized() * intersection);
        }
        if (collider1 is BoxCollider bc && collider2 is SphereCollider sc)
        {
            collider2.transform.position += n1 * MathF.Abs(sc.Radius - (point - sc.ActualCenter).Length);
        }
        else if (collider2 is BoxCollider bc2 && collider1 is SphereCollider sc2)
        {
            collider1.transform.position += n2 * MathF.Abs(sc2.Radius - (point - sc2.ActualCenter).Length);
        }

    }
}


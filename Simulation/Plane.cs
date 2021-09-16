using OpenTK.Mathematics;

public struct Plane
{
    public readonly Vector3 normal;
    public readonly float distanceFromOrigin;

    // p.n + d = 0
    public Plane(Vector3 a, Vector3 b, Vector3 c)
    {
        var ab = b - a;
        var ac = c - a;

        normal = Vector3.Cross(ab, ac).Normalized();
        distanceFromOrigin = -Vector3.Dot(normal, a);
    }

    public Plane(Vector3 a, Vector3 b, Vector3 c, Vector3 d, Vector3 center)
    {
        var temp = (a + b + c + d) / 4;
        normal = (temp - center).Normalized();
        distanceFromOrigin = -Vector3.Dot(normal, temp);
    }

    public float GetDistance(Vector3 point)
    {
        return Vector3.Dot(normal, point) - distanceFromOrigin;
    }

    public bool InPlane(Vector3 point)
    {
        return Vector3.Dot(normal, point) + distanceFromOrigin == 0;
    }

    public bool Intersect(Ray ray, out Vector3 point)
    {
        // the denominator is zero, impossible to solve 
        if (Vector3.Dot(ray.direction, normal) == 0)
        {
            point = Vector3.NegativeInfinity;
            return false;
        }

        float t = -(Vector3.Dot(ray.position, normal) + distanceFromOrigin) / Vector3.Dot(ray.direction, normal);
        point = ray.position + t * ray.direction;
        return true;
    }

    public bool Intersect(Ray ray)
    {
        // the denominator is zero, imposible to solve 
        if (Vector3.Dot(ray.direction.Normalized(), normal) == 0) return false;
        return true;
    }

    public static bool Intersect(Ray ray, Vector3 a, Vector3 b, Vector3 c, Vector3 d, out Vector3 point)
    {
        Plane tempPlane = new Plane(a, b, c);
        if (tempPlane.Intersect(ray, out Vector3 tempPoint) == true)
        {
            float anglesSum = Vector3.CalculateAngle(a - tempPoint, b - tempPoint) + Vector3.CalculateAngle(b - tempPoint, c - tempPoint) +
                              Vector3.CalculateAngle(c - tempPoint, d - tempPoint) + Vector3.CalculateAngle(d - tempPoint, a - tempPoint);


            if (MathHelper.ApproximatelyEquivalent(anglesSum, MathHelper.TwoPi, 0.05f))
            {
                point = tempPoint;
                return true;
            }


        }

        point = Vector3.NegativeInfinity;
        return false;
    }
}

public struct Edge
{
    public Vector3 direction;
    public Vector3 start, end;

    public Edge(Vector3 start, Vector3 end)
    {
        this.start = start;
        this.end = end;

        direction = (end - start).Normalized();
    }
}



using OpenTK.Mathematics;

public class CollisionData
{
    public Vector3 normal;
    public Vector3 point;
    public float intersectionAmount;

    public override string ToString()
    {
        return $"normal = {normal}, point = {point}, intersection amount = {intersectionAmount}";
    }
}
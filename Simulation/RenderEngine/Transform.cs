using OpenTK.Mathematics;
using System.Collections.Generic;

public class Transform
{
    public Matrix4 modelSRT;
    public Matrix4 modelRT;
    public Matrix4 translationMatrix;
    public Matrix4 rotationMatrix;
    public Matrix4 scalingMatrix;

    public Vector3 position;
    public Vector3 scale;

    public Vector3 forward;
    public Vector3 right;
    public Vector3 up;

    public Quaternion rotation;

    public Transform parent;
    public readonly LinkedList<Transform> childrenList;

    public Transform()
    {
        position = Vector3.Zero;
        rotation = Quaternion.Identity;
        scale = Vector3.One;

        forward = -Vector3.UnitZ;
        right = Vector3.UnitX;
        up = Vector3.UnitY;

        childrenList = new LinkedList<Transform>();
    }

    public void Update()
    {
        // creating the transform matrix
        Matrix4.CreateTranslation(position, out translationMatrix);
        Matrix4.CreateFromQuaternion(rotation, out rotationMatrix);
        Matrix4.CreateScale(scale, out scalingMatrix);

        modelRT = rotationMatrix * translationMatrix * Matrix4.Identity;
        modelSRT = scalingMatrix * modelRT;

        // caclulating forward, up and right
        forward = (modelSRT * -Vector4.UnitZ).Xyz;
        right = Vector3.Cross(forward, Vector3.UnitY).Normalized();
        up = Vector3.Cross(right, forward).Normalized();
    }

}
using OpenTK.Mathematics;
using OpenTK.Windowing.Desktop;
using OpenTK.Windowing.GraphicsLibraryFramework;


public enum ProjectionType
{
    Perspective, Orthographic
}
public class Camera : Component
{
    // the game window responsible of the camera
    private GameWindow gameWindow;
    // projection settings
    public float nearClipPlane = 0.01f;
    public float farClipPlane = 2000f;
    public float fieldOfView = 45f;
    public float aspectRatio = 16 / 9;

    public ProjectionType projectionType = ProjectionType.Perspective;

    public Camera(Transform transform, SimulationObject simulationObject) : base(transform, simulationObject)
    {
        simulationObject.simulationManager.camerasList.AddLast(this);
        gameWindow = simulationObject.simulationManager.gameWindow;
    }

    public Matrix4 ViewMatrix
    {
        get
        {
            return Matrix4.LookAt(transform.position, transform.position + transform.forward, transform.up);
        }
    }
    public Matrix4 PerspectiveMatrix
    {
        get
        {
            if (gameWindow.Size.X == 0f || gameWindow.Size.Y == 0) return Matrix4.Identity;
            aspectRatio = gameWindow.Size.X / gameWindow.Size.Y;
            return Matrix4.CreatePerspectiveFieldOfView(MathHelper.DegreesToRadians(fieldOfView), aspectRatio, nearClipPlane, farClipPlane);
        }
    }
    public Matrix4 OrthographicMatrix
    {
        get
        {
            if (gameWindow.Size.X == 0f || gameWindow.Size.Y == 0) return Matrix4.Identity;
            aspectRatio = gameWindow.Size.X / gameWindow.Size.Y;

            float width = 50 * fieldOfView / 45f;
            float height = width / aspectRatio;

            return Matrix4.CreateOrthographic(width, height, nearClipPlane, farClipPlane);
        }
    }
    public Matrix4 ProjectionMatrix
    {
        get
        {
            if (projectionType == ProjectionType.Perspective) return PerspectiveMatrix;
            else return OrthographicMatrix;
        }
    }
    public void FppCameraController(float mouseSensitivity, float speed)
    {
        float deltaTime = (float)gameWindow.RenderTime;
        // ----------------------------------------------------------------------------------------------
        // update camera rotation
        if (gameWindow.MouseState.IsButtonDown(MouseButton.Button2))
        {
            var mouseOffset = gameWindow.MouseState.Position - gameWindow.MouseState.PreviousPosition;
            Quaternion horizentalRotate = Quaternion.FromAxisAngle(transform.up, mouseOffset.X * deltaTime * mouseSensitivity);
            Quaternion verticalRotate = Quaternion.FromAxisAngle(transform.right, mouseOffset.Y * deltaTime * mouseSensitivity);
            transform.rotation *= horizentalRotate * verticalRotate;
        }

        // update camera fov
        var wheelOffset = gameWindow.MouseState.Scroll.Y - gameWindow.MouseState.PreviousScroll.Y;
        fieldOfView -= wheelOffset;

        if (fieldOfView <= 1) fieldOfView = 1;
        if (fieldOfView >= 90) fieldOfView = 90;

        // update camera position
        if (gameWindow.KeyboardState.IsKeyDown(Keys.LeftShift)) speed *= 10;
        if (gameWindow.KeyboardState.IsKeyDown(Keys.W)) transform.position += transform.forward * deltaTime * speed;
        if (gameWindow.KeyboardState.IsKeyDown(Keys.S)) transform.position -= transform.forward * deltaTime * speed;
        if (gameWindow.KeyboardState.IsKeyDown(Keys.D)) transform.position += transform.right * deltaTime * speed;
        if (gameWindow.KeyboardState.IsKeyDown(Keys.A)) transform.position -= transform.right * deltaTime * speed;
        if (gameWindow.KeyboardState.IsKeyDown(Keys.Space)) transform.position += Vector3.UnitY * deltaTime * speed;
        if (gameWindow.KeyboardState.IsKeyDown(Keys.LeftControl)) transform.position -= Vector3.UnitY * deltaTime * speed;

    }

    public Ray CameraToWorldRay(Vector3 screenPosition)
    {
        var clipSpaceRay = new Vector4
        {
            X = (2.0f * screenPosition.X) / gameWindow.Size.X - 1.0f,
            Y = 1.0f - (2.0f * screenPosition.Y) / gameWindow.Size.Y,
            Z = -1.0f,
            W = 1.0f
        };

        // TODO Orthographic projection doesn't work
        var cameraSpaceRay = Matrix4.Invert(ProjectionMatrix) * clipSpaceRay;
        cameraSpaceRay.Z = -1; cameraSpaceRay.W = 0;
        var worldRay = Matrix4.Invert(ViewMatrix) * cameraSpaceRay;
        return new Ray { position = transform.position, direction = worldRay.Xyz.Normalized() };
    }
}


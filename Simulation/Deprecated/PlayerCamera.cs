using OpenTK.Mathematics;
using OpenTK.Windowing.Desktop;
using OpenTK.Windowing.GraphicsLibraryFramework;

namespace Deprecated
{
    public class PlayerCamera
    {
        // velocities
        public float movementVelocity = 5f;
        public float angularVelocity = 10f;
        public float zoomingVelocity = 100f;
        // Angles thing
        public float pitch = 0f;
        public float yaw = 0f;
        // position
        public Vector3 position = Vector3.Zero;
        // axis
        public Vector3 forward = -Vector3.UnitZ;
        public Vector3 right = Vector3.UnitX;
        public Vector3 up = Vector3.UnitY;
        // the game window responsible of the camera
        public GameWindow gameWindow;
        // projection settings
        public float nearClipPlane = 0.01f;
        public float farClipPlane = 2000f;
        public float fieldOfView = 45f;
        public float aspectRatio = 16 / 9;


        public PlayerCamera(GameWindow gameWindow, float movementVelocity, float angularVelocity, float zoomingVelocity)
        {
            this.gameWindow = gameWindow;

            this.movementVelocity = movementVelocity;
            this.angularVelocity = angularVelocity;
            this.zoomingVelocity = zoomingVelocity;
        }

        public PlayerCamera(GameWindow gameWindow) { this.gameWindow = gameWindow; }

        public void UpdatePositionByKeyboard()
        {
            float speed = movementVelocity * (float)gameWindow.RenderTime;
            if (gameWindow.KeyboardState.IsKeyDown(Keys.LeftShift)) speed *= 10;

            if (gameWindow.KeyboardState.IsKeyDown(Keys.W)) position += forward * speed;
            if (gameWindow.KeyboardState.IsKeyDown(Keys.S)) position -= forward * speed;
            if (gameWindow.KeyboardState.IsKeyDown(Keys.D)) position += right * speed;
            if (gameWindow.KeyboardState.IsKeyDown(Keys.A)) position -= right * speed;
        }

        public void UpdateAnglesByMouse()
        {
            Vector2 mouseOffset = gameWindow.MouseState.Position - gameWindow.MouseState.PreviousPosition;
            yaw += mouseOffset.X * angularVelocity * (float)gameWindow.RenderTime;
            pitch -= mouseOffset.Y * angularVelocity * (float)gameWindow.RenderTime;

            if (pitch >= 90) pitch = 89;
            if (pitch <= -90) pitch = -89;


            UpdateAxis();
        }

        public void UpdateFovByMouse()
        {
            float offset = gameWindow.MouseState.Scroll.Y - gameWindow.MouseState.PreviousScroll.Y;
            fieldOfView -= offset * zoomingVelocity * (float)gameWindow.RenderTime;
            if (fieldOfView >= 60) fieldOfView = 60;
            if (fieldOfView <= 1) fieldOfView = 1;
        }

        public void UpdateAxis()
        {
            float yawR = MathHelper.DegreesToRadians(yaw);
            float pitchR = MathHelper.DegreesToRadians(pitch);

            forward = new Vector3
            {
                X = (float)(MathHelper.Cos(yawR) * MathHelper.Cos(pitchR)),
                Y = (float)(MathHelper.Sin(pitchR)),
                Z = (float)(MathHelper.Sin(yawR) * MathHelper.Cos(pitchR))
            };

            right = Vector3.Cross(forward, Vector3.UnitY);
            up = Vector3.Cross(right, forward);
        }

        public Matrix4 ViewMatrix => Matrix4.LookAt(position, position + forward, up);
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
                float width = gameWindow.Size.X * fieldOfView / 45;
                float height = gameWindow.Size.Y * fieldOfView / 45;
                return Matrix4.CreateOrthographic(width, height, nearClipPlane, farClipPlane);
            }
        }

    }
}
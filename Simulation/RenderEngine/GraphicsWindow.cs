using OpenTK.Graphics.OpenGL;
using OpenTK.Mathematics;
using OpenTK.Windowing.Common;
using OpenTK.Windowing.Desktop;
using OpenTK.Windowing.GraphicsLibraryFramework;
using System;
using System.Collections.Generic;

public class GraphicsWindow : GameWindow
{
    public SimulationManager simulationManager;

    public static GraphicsWindow Create(int width, int height, string title)
    {
        var gameWindowSettings = new GameWindowSettings()
        {
            //RenderFrequency = 60f,
            //UpdateFrequency = 320f
        };
        var nativeWindowSettings = new NativeWindowSettings
        {
            Size = new Vector2i(width, height),
            Title = title,
            API = ContextAPI.OpenGL,
            Profile = ContextProfile.Core,
            APIVersion = new Version(3, 3),
        };

        var graphicsWindow = new GraphicsWindow(gameWindowSettings, nativeWindowSettings);

        return graphicsWindow;
    }

    private GraphicsWindow(GameWindowSettings gameWindowSettings, NativeWindowSettings nativeWindowSettings) :
        base(gameWindowSettings, nativeWindowSettings)
    {
    }

    protected override void OnUpdateFrame(FrameEventArgs args)
    {
        base.OnUpdateFrame(args);
    }

    protected override void OnLoad()
    {
        GL.ClearColor(0f, 0.5f, 0.5f, 0f);
        GL.Enable(EnableCap.DepthTest);

        base.OnLoad();
    }

    protected override void OnUnload()
    {
        base.OnUnload();
    }

    protected override void OnRenderFrame(FrameEventArgs e)
    {
        GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);

        if (simulationManager == null) return;

        // camera not null
        if (simulationManager.CurrentCamera != null) simulationManager.CurrentCamera.FppCameraController(1f, 20);

        // switch cameras
        if (KeyboardState.IsKeyDown(Keys.Tab) && !KeyboardState.WasKeyDown(Keys.Tab)) simulationManager.SwitchCamera();
        if (KeyboardState.IsKeyDown(Keys.P) && !KeyboardState.WasKeyDown(Keys.P)) simulationManager.ChangeProjection();

        // Time Scale
        if (KeyboardState.IsKeyDown(Keys.Up) && !KeyboardState.WasKeyDown(Keys.Up)) simulationManager.timeScale += 1;
        if (KeyboardState.IsKeyDown(Keys.Down) && !KeyboardState.WasKeyDown(Keys.Down)) simulationManager.timeScale -= 1;

        // Add Balls
        if (MouseState.IsButtonDown(MouseButton.Button1) && !MouseState.WasButtonDown(MouseButton.Button1) && canAddBalls) AddBalls();

        simulationManager.UpdateCycle();

        Context.SwapBuffers();
        base.OnRenderFrame(e);
    }

    public bool canAddBalls = false;
    public void AddBalls()
    {
        int number = simulationManager.simulationObjectsList.Count;
        SimulationObject s = new SimulationObject($"Ball {number}", simulationManager);
        s.transform.position = simulationManager.CurrentCamera.transform.position + simulationManager.CurrentCamera.transform.forward * 10;
        s.AddComponent<ModelRenderer>();
        s.GetComponent<ModelRenderer>().simulationModel = SimulationModel.CreateByName("Ball.obj");
        s.AddComponent<SphereCollider>();
        s.AddComponent<RigidBody>();
        s.GetComponent<RigidBody>().linearVelocity = simulationManager.CurrentCamera.transform.forward * 10;
        s.GetComponent<RigidBody>().mass = 20;
    }

    protected override void OnResize(ResizeEventArgs e)
    {
        GL.Viewport(0, 0, e.Width, e.Height);
        base.OnResize(e);
    }
}
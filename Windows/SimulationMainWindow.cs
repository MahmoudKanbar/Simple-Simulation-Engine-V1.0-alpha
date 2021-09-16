using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Globalization;
using System.Windows.Forms;
using OpenTK.Mathematics;
using OpenTK.Windowing.Common;
using OpenTK.Windowing.Desktop;

namespace Scientific_Calculations
{
    public partial class SimulationMainWindow : Form
    {
        public GraphicsWindow graphicsWindow;

        private SimulationManager engineManager;
        private SimulationManager earthManager;
        private SimulationManager roomManager;

        private SimulationObject selectedSimulationObject;

        // constrains
        private float GX = 0, GY = -10, GZ = 0;
        private float AD = 1.225f;
        float FCK = 10.0f, FCS = 0.2f;

        Quaternion q1 = Quaternion.FromEulerAngles(Vector3.UnitX * MathHelper.DegreesToRadians(45));
        Quaternion q2 = Quaternion.FromEulerAngles(Vector3.UnitY * MathHelper.DegreesToRadians(45));
        Quaternion q3 = Quaternion.FromEulerAngles(Vector3.UnitZ * MathHelper.DegreesToRadians(45));

        // transform
        float PX = 0, PY = 0, PZ = 0;
        float RX = 0, RY = 0, RZ = 0;
        float SX = 1, SY = 1, SZ = 1;

        public SimulationMainWindow()
        {
            InitializeComponent();

            string resources = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\Resources";

            graphicsWindow = GraphicsWindow.Create(1200, 700, "Simulation");

            engineManager = new SimulationManager(graphicsWindow, resources);
            InitializeEngine();

            earthManager = new SimulationManager(graphicsWindow, resources);
            InitializeEarth();

            roomManager = new SimulationManager(graphicsWindow, resources);
            InitializeRoom();

            SimulationObjectInfo.Multiline = true;
            SimulationObjectInfo.ScrollBars = ScrollBars.Both;


            Timer timer = new Timer();
            timer.Interval = 200;
            timer.Tick += new EventHandler(UpdateInfo);
            timer.Start();
        }


        private int lastCount;
        private void UpdateInfo(object sender, EventArgs eventArgs)
        {
            if (graphicsWindow.simulationManager != null && graphicsWindow.simulationManager.simulationObjectsList.Count > lastCount)
            {
                simulationObjectsList.Items.Clear();

                foreach (var sm in graphicsWindow.simulationManager.simulationObjectsList)
                    simulationObjectsList.Items.Add(sm.name);

                lastCount = graphicsWindow.simulationManager.simulationObjectsList.Count;
            }

            if (selectedSimulationObject == null) return;

            string info = string.Empty;
            Transform transform = selectedSimulationObject.transform;
            RigidBody rigidBody = selectedSimulationObject.GetComponent<RigidBody>();

            info += $"position = {transform.position}\n" +
                    $"rotation = {transform.rotation.ToEulerAngles()}\n" +
                    $"scale = {transform.scale}\n";

            if (rigidBody != null)
            {
                info += $"linear velocity = {rigidBody.linearVelocity}\n" +
                        $"linear acceleration = {rigidBody.linearAcceleration}\n" +
                        $"total force = {rigidBody.force}\n" +
                        $"angular velocity = {rigidBody.angularVelocity}\n" +
                        $"angular acceleration = {rigidBody.angularAcceleration}\n" +
                        $"total torque = {rigidBody.torque}\n" +
                        $"mass = {rigidBody.mass}";
            }

            SimulationObjectInfo.Text = info;

        }

        private void UpdateConstrains()
        {
            SimulationManager sm = graphicsWindow.simulationManager;
            if (sm == null) return;

            RXT.Text = sm.gravity.X.ToString();
            RYT.Text = sm.gravity.Y.ToString();
            RZT.Text = sm.gravity.Z.ToString();

            ADT.Text = sm.airDensity.ToString();

            FCKT.Text = sm.frictionCoK.ToString();
            FCST.Text = sm.frictionCoS.ToString();
        }

        private void UpdateTransform()
        {
            if (selectedSimulationObject == null) return;
            Transform transform = selectedSimulationObject.transform;
            Vector3 rotation = transform.rotation.ToEulerAngles();

            PXT.Text = transform.position.X.ToString();
            PYT.Text = transform.position.Y.ToString();
            PZT.Text = transform.position.Z.ToString();

            RXT.Text = rotation.X.ToString();
            RYT.Text = rotation.Y.ToString();
            RZT.Text = rotation.Z.ToString();

            SXT.Text = transform.scale.X.ToString();
            SYT.Text = transform.scale.Y.ToString();
            SZT.Text = transform.scale.Z.ToString();
        }


        private void InitializeEngine()
        {
            SimulationObject mainCamera = new SimulationObject("Main Camera", engineManager);

            SimulationObject directionalLight = new SimulationObject("Directional Light", engineManager);
            directionalLight.transform.rotation = q1 * q2 * q3;
            directionalLight.AddComponent<DirectionalLight>();

            mainCamera.transform.position = new Vector3(0, 0, 10);
            mainCamera.AddComponent<Camera>();
            engineManager.SetCurrentCamera("Main Camera");
        }

        private void InitializeEarth()
        {

            //1.0	0.045	0.0075
            SimulationObject directionalLight = new SimulationObject("directionalLight", earthManager);
            directionalLight.AddComponent<DirectionalLight>();
            directionalLight.transform.rotation = q1 * q2 * q3;

            SimulationObject simulationObject2 = new SimulationObject("Earth", earthManager);
            simulationObject2.transform.position = new Vector3(0, 0, 0);
            simulationObject2.transform.scale = new Vector3(10, 10, 10);

            simulationObject2.AddComponent<ModelRenderer>();
            simulationObject2.GetComponent<ModelRenderer>().simulationModel = SimulationModel.CreateByName("Ball.obj");

            simulationObject2.AddComponent<SphereCollider>();
            simulationObject2.GetComponent<SphereCollider>().Radius = 10;
            simulationObject2.AddComponent<RigidBody>();
            simulationObject2.GetComponent<RigidBody>().disableGravity = true;
            simulationObject2.GetComponent<RigidBody>().isStatic = true;
            simulationObject2.GetComponent<RigidBody>().mass = 1000;

            SimulationObject spotLight = new SimulationObject("spotLight", earthManager);
            spotLight.transform.position = new Vector3(0, 20, 0);
            spotLight.AddComponent<PointLight>();
            spotLight.GetComponent<PointLight>().attenuation = 0.000001f;


            // camera
            SimulationObject mainCamera = new SimulationObject("Main Camera", earthManager);
            mainCamera.transform.position = new Vector3(0, 0, 150);
            mainCamera.AddComponent<Camera>();
            mainCamera.AddComponent<PointLight>();
            mainCamera.GetComponent<PointLight>().attenuation = 0.00001f;

            SimulationObject secondCamera = new SimulationObject("Second Camera", earthManager);
            secondCamera.transform.position = new Vector3(10, 10, 0);
            secondCamera.transform.rotation = q1;
            secondCamera.AddComponent<Camera>();

            earthManager.SetCurrentCamera("Main Camera");
        }

        private void InitializeRoom()
        {

            SimulationObject directionalLight = new SimulationObject("directionalLight", roomManager);
            directionalLight.AddComponent<DirectionalLight>();
            directionalLight.transform.rotation = q1 * q2 * q3;

            {
                SimulationObject simulationObject2 = new SimulationObject("Earth", roomManager);
                simulationObject2.transform.position = new Vector3(0, -50, 0) / 5;
                simulationObject2.transform.scale = new Vector3(50, 50, 50) / 5;
                simulationObject2.AddComponent<ModelRenderer>();
                simulationObject2.GetComponent<ModelRenderer>().simulationModel = SimulationModel.CreateByName("Cube.obj");
                simulationObject2.AddComponent<BoxCollider>();
                simulationObject2.GetComponent<BoxCollider>().HalfExterns = Vector3.One * 10;
                simulationObject2.AddComponent<RigidBody>();
                simulationObject2.GetComponent<RigidBody>().disableGravity = true;
                simulationObject2.GetComponent<RigidBody>().isStatic = true;
                simulationObject2.GetComponent<RigidBody>().mass = 1000;
            }


            // camera
            SimulationObject mainCamera = new SimulationObject("Main Camera", roomManager);
            mainCamera.transform.position = new Vector3(0, 0, 150);
            mainCamera.AddComponent<Camera>();

            SimulationObject secondCamera = new SimulationObject("Second Camera", roomManager);
            secondCamera.transform.position = new Vector3(10, 10, 0);
            secondCamera.transform.rotation = q1;
            secondCamera.AddComponent<Camera>();

            roomManager.SetCurrentCamera("Main Camera");
        }

        private void AddSimulationObject(object sender, System.EventArgs e)
        {
            int number = graphicsWindow.simulationManager.simulationObjectsList.Count;
            SimulationObject simulationObject = new SimulationObject($"Object {number++}", graphicsWindow.simulationManager);
            UpdateTransform();
        }


        private void PXTextChanged(object sender, EventArgs e)
        {
            float.TryParse(PXT.Text, out PX);
        }

        private void PYTextChanged(object sender, EventArgs e)
        {
            float.TryParse(PYT.Text, out PY);
        }

        private void PZTextChanged(object sender, EventArgs e)
        {
            float.TryParse(PZT.Text, out PZ);
        }

        private void RXTextChanged(object sender, EventArgs e)
        {
            float.TryParse(RXT.Text, out RX);
        }

        private void RYTextChanged(object sender, EventArgs e)
        {
            float.TryParse(RYT.Text, out RY);
        }

        private void RZTextChanged(object sender, EventArgs e)
        {
            float.TryParse(RZT.Text, out RZ);
        }

        private void SXTextChanged(object sender, EventArgs e)
        {
            float.TryParse(SXT.Text, out SX);
        }
        private void SYTextChanged(object sender, EventArgs e)
        {
            float.TryParse(SYT.Text, out SY);
        }

        private void SZTextChanged(object sender, EventArgs e)
        {
            float.TryParse(SZT.Text, out SZ);
        }

        private void BoxColliderAction(object sender, EventArgs e)
        {
            if (selectedSimulationObject == null) return;
            BoxColliderWindow boxColliderWindow = new BoxColliderWindow(selectedSimulationObject);
            boxColliderWindow.Show();
        }

        private void CameraAction(object sender, EventArgs e)
        {
            if (selectedSimulationObject == null) return;
            selectedSimulationObject.AddComponent<Camera>();
        }

        private void DeleteRigidBody(object sender, EventArgs e)
        {
            if (selectedSimulationObject == null) return;
            selectedSimulationObject.RemoveComponent<RigidBody>();
        }

        private void DeleteBoxCollider(object sender, EventArgs e)
        {
            if (selectedSimulationObject == null) return;
            selectedSimulationObject.RemoveComponent<BoxCollider>();
        }

        private void DeleteSphereCollider(object sender, EventArgs e)
        {
            if (selectedSimulationObject == null) return;
            selectedSimulationObject.RemoveComponent<SphereCollider>();
        }

        private void DeleteCamera(object sender, EventArgs e)
        {
            if (selectedSimulationObject == null) return;
            selectedSimulationObject.RemoveComponent<Camera>();
        }

        private void GXTextChange(object sender, EventArgs e)
        {
            float.TryParse(GXT.Text, out GX);
        }
        private void GYTextChange(object sender, EventArgs e)
        {
            float.TryParse(GYT.Text, out GY);
        }

        private void ADTextChange(object sender, EventArgs e)
        {
            float.TryParse(ADT.Text, out AD);
        }
        private void FCKTextChange(object sender, EventArgs e)
        {
            float.TryParse(FCKT.Text, out FCK);
        }

        private void FCSTextChange(object sender, EventArgs e)
        {
            float.TryParse(FCST.Text, out FCS);
        }

        private void SaveConstrains(object sender, EventArgs e)
        {
            if (graphicsWindow.simulationManager == null) return;
            graphicsWindow.simulationManager.gravity = new Vector3(GX, GY, GZ);
            graphicsWindow.simulationManager.airDensity = AD;
            graphicsWindow.simulationManager.frictionCoK = FCK;
            graphicsWindow.simulationManager.frictionCoS = FCS;
        }

        private void ModelRendererAction(object sender, EventArgs e)
        {
            if (selectedSimulationObject == null) return;
            //ModelRendereWindow boxColliderWindow = new ModelRendereWindow(selectedSimulationObject);
            //boxColliderWindow.Show();
            selectedSimulationObject.AddComponent<ModelRenderer>();
            selectedSimulationObject.GetComponent<ModelRenderer>().simulationModel = SimulationModel.CreateByName("Ball.obj");
        }

        private void DeleteModelRenderer(object sender, EventArgs e)
        {
            if (selectedSimulationObject == null) return;
            selectedSimulationObject.RemoveComponent<ModelRenderer>();
        }

        private void ShowOrHideColliders(object sender, EventArgs e)
        {
            bool value = graphicsWindow.simulationManager.showColliders;
            if (value)
                graphicsWindow.simulationManager.showColliders = false;
            else
                graphicsWindow.simulationManager.showColliders = true;
        }

        private void ShowOrHideObjects(object sender, EventArgs e)
        {
            bool value = graphicsWindow.simulationManager.showObjects;
            if (value)
                graphicsWindow.simulationManager.showObjects = false;
            else
                graphicsWindow.simulationManager.showObjects = true;
        }

        private void SaveTransform(object sender, EventArgs e)
        {
            if (selectedSimulationObject != null)
            {
                selectedSimulationObject.transform.position.X = PX;
                selectedSimulationObject.transform.position.Y = PY;
                selectedSimulationObject.transform.position.Z = PZ;

                if (RX != 0 && RY != 0 && RZ != 0)
                {
                    Vector3 rotationVector = new Vector3(RX, RY, RZ);
                    Quaternion rotation = Quaternion.FromAxisAngle(rotationVector.Normalized(), MathHelper.DegreesToRadians(rotationVector.Length));
                    selectedSimulationObject.transform.rotation = rotation;
                }
                else
                {
                    selectedSimulationObject.transform.rotation = Quaternion.Identity;
                }

                selectedSimulationObject.transform.scale.X = SX;
                selectedSimulationObject.transform.scale.Y = SY;
                selectedSimulationObject.transform.scale.Z = SZ;
            }
        }

        private void GZTextChange(object sender, EventArgs e)
        {
            float.TryParse(GZT.Text, out GZ);
        }

        private void SphereColliderAction(object sender, EventArgs e)
        {
            if (selectedSimulationObject == null) return;
            SphereColliderWindow boxColliderWindow = new SphereColliderWindow(selectedSimulationObject);
            boxColliderWindow.Show();
        }

        private void ChangeSelectedSM(object sender, EventArgs e)
        {
            var currentSimulationManager = graphicsWindow.simulationManager;
            int smIndex = simulationObjectsList.FocusedItem.Index;
            selectedSimulationObject = currentSimulationManager.simulationObjectsList.ElementAt(smIndex);
            UpdateTransform();
        }

        private void RunEngine(object sender, EventArgs e)
        {
            graphicsWindow.simulationManager = engineManager;
            graphicsWindow.canAddBalls = false;
            graphicsWindow.Run();
            UpdateConstrains();
        }

        private void RunEarth(object sender, EventArgs e)
        {
            graphicsWindow.simulationManager = earthManager;
            graphicsWindow.canAddBalls = true;
            graphicsWindow.Run();
            UpdateConstrains();
        }

        private void RunRoom(object sender, EventArgs e)
        {
            graphicsWindow.simulationManager = roomManager;
            graphicsWindow.canAddBalls = true;
            graphicsWindow.Run();
            UpdateConstrains();
        }

        private void RigidBodyAction(object sender, EventArgs e)
        {
            if (selectedSimulationObject == null) return;
            RigidBodyWindow rigidBodyWindow = new RigidBodyWindow(selectedSimulationObject);
            rigidBodyWindow.Show();
        }

        private void ResumeSimulation(object sender, EventArgs e)
        {
            graphicsWindow.simulationManager.timeScale = 1f;
        }

        // to clear the textboxes all at once after adding a simulator
        private void ClearTextBoxes()
        {
            Action<Control.ControlCollection> func = null;

            func = (controls) =>
            {
                foreach (Control control in controls)
                    if (control is TextBox)
                        (control as TextBox).Clear();
                    else
                        func(control.Controls);
            };

            func(Controls);
        }

    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OpenTK.Mathematics;

namespace Scientific_Calculations
{
    public partial class SphereColliderWindow : Form
    {
        private SphereCollider sphereCollider;

        private float RCX = 0, RCY = 0, RCZ = 0;
        private float R = 1;

        public SphereColliderWindow(SimulationObject selectedSimulationObject)
        {
            InitializeComponent();

            sphereCollider = selectedSimulationObject.GetComponent<SphereCollider>();
            if (sphereCollider == null)
            {
                selectedSimulationObject.AddComponent<SphereCollider>();
                sphereCollider = selectedSimulationObject.GetComponent<SphereCollider>();
            }

            RCXT.Text = sphereCollider.RelativeCenter.X.ToString();
            RCYT.Text = sphereCollider.RelativeCenter.Y.ToString();
            RCZT.Text = sphereCollider.RelativeCenter.Z.ToString();

            RT.Text = sphereCollider.Radius.ToString();
        }

        private void SaveSphereCollider(object sender, EventArgs e)
        {
            sphereCollider.RelativeCenter = new Vector3(RCX, RCY, RCZ);
            sphereCollider.Radius = R;
            Close();
        }

        private void RCXTextChanged(object sender, EventArgs e)
        {
            float.TryParse(RCXT.Text, out RCX);
        }

        private void RCYTextChanged(object sender, EventArgs e)
        {
            float.TryParse(RCYT.Text, out RCY);
        }

        private void RCZTextChanged(object sender, EventArgs e)
        {
            float.TryParse(RCZT.Text, out RCZ);
        }

        private void RTextChanged(object sender, EventArgs e)
        {
            float.TryParse(RT.Text, out R);
        }
    }
}

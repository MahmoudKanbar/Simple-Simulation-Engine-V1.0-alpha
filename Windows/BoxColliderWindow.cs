using OpenTK.Mathematics;
using System;
using System.Windows.Forms;

namespace Scientific_Calculations
{
    public partial class BoxColliderWindow : Form
    {
        private BoxCollider boxCollider;

        private float RCX = 0, RCY = 0, RCZ = 0;
        private float HEX = 1, HEY = 1, HEZ = 1;

        public BoxColliderWindow(SimulationObject selectedSimulationObject)
        {
            InitializeComponent();

            boxCollider = selectedSimulationObject.GetComponent<BoxCollider>();
            if (boxCollider == null)
            {
                selectedSimulationObject.AddComponent<BoxCollider>();
                boxCollider = selectedSimulationObject.GetComponent<BoxCollider>();
            }

            RCXT.Text = boxCollider.RelativeCenter.X.ToString();
            RCYT.Text = boxCollider.RelativeCenter.Y.ToString();
            RCZT.Text = boxCollider.RelativeCenter.Z.ToString();

            HEXT.Text = boxCollider.HalfExterns.X.ToString();
            HEYT.Text = boxCollider.HalfExterns.Y.ToString();
            HEZT.Text = boxCollider.HalfExterns.Z.ToString();
        }

        private void SaveBoxCollider(object sender, EventArgs e)
        {
            boxCollider.RelativeCenter = new Vector3(RCX, RCY, RCZ);
            boxCollider.HalfExterns = new Vector3(HEX, HEY, HEZ);
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

        private void HEXTextChanged(object sender, EventArgs e)
        {
            float.TryParse(HEXT.Text, out HEX);
        }

        private void HEYTextChanged(object sender, EventArgs e)
        {
            float.TryParse(HEYT.Text, out HEY);
        }

        private void HEZTextChanged(object sender, EventArgs e)
        {
            float.TryParse(HEZT.Text, out HEZ);
        }
    }

}

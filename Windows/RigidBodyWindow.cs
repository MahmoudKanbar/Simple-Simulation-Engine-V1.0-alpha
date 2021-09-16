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
    public partial class RigidBodyWindow : Form
    {
        private float LVX = 0, LVY = 0, LVZ = 0;
        private float AVX = 0, AVY = 0, AVZ = 0;
        private float ETX = 0, ETY = 0, ETZ = 0;
        private float EFX = 0, EFY = 0, EFZ = 0;
        private float mass = 1;

        private RigidBody rigidBody = null;

        public RigidBodyWindow(SimulationObject selectedSimulationObject)
        {
            InitializeComponent();

            rigidBody = selectedSimulationObject.GetComponent<RigidBody>();
            if (rigidBody == null)
            {
                selectedSimulationObject.AddComponent<RigidBody>();
                rigidBody = selectedSimulationObject.GetComponent<RigidBody>();
            }

            LVXT.Text = rigidBody.linearVelocity.X.ToString();
            LVYT.Text = rigidBody.linearVelocity.Y.ToString();
            LVZT.Text = rigidBody.linearVelocity.Z.ToString();

            AVXT.Text = rigidBody.angularVelocity.X.ToString();
            AVYT.Text = rigidBody.angularVelocity.Y.ToString();
            AVZT.Text = rigidBody.angularVelocity.Z.ToString();

            EFXT.Text = rigidBody.externalForce.X.ToString();
            EFYT.Text = rigidBody.externalForce.Y.ToString();
            EFZT.Text = rigidBody.externalForce.Z.ToString();

            ETXT.Text = rigidBody.externalTorque.X.ToString();
            ETYT.Text = rigidBody.externalTorque.Y.ToString();
            ETZT.Text = rigidBody.externalTorque.Z.ToString();

            massT.Text = rigidBody.mass.ToString();

            if (rigidBody.isStatic) constrainsList.SetItemCheckState(0, CheckState.Checked);
            if (rigidBody.disableGravity) constrainsList.SetItemCheckState(1, CheckState.Checked);
        }

        private void SaveRigidBody(object sender, EventArgs e)
        {
            rigidBody.linearVelocity = new Vector3(LVX, LVY, LVZ);
            rigidBody.angularVelocity = new Vector3(AVX, AVY, AVZ);
            rigidBody.externalForce = new Vector3(EFX, EFY, EFZ);
            rigidBody.externalTorque = new Vector3(ETX, ETY, ETZ);
            rigidBody.mass = mass;

            rigidBody.isStatic = constrainsList.GetItemChecked(0);
            rigidBody.disableGravity = constrainsList.GetItemChecked(1);
            Close();
        }


        private void LVXT_Changed(object sender, EventArgs e)
        {
            string LVXText = LVXT.Text;
            if (LVXText != "") float.TryParse(LVXText, out LVX);
        }

        private void LVYT_Changed(object sender, EventArgs e)
        {
            string linear_Ytext = LVYT.Text;
            if (linear_Ytext != "") float.TryParse(linear_Ytext, out LVY);
        }

        private void UpdateConstrains(object sender, ItemCheckEventArgs e)
        {
            rigidBody.isStatic = constrainsList.GetItemChecked(0);
            rigidBody.disableGravity = constrainsList.GetItemChecked(1);
        }

        private void LVZT_Changed(object sender, EventArgs e)
        {
            string linear_Ztext = LVZT.Text;
            if (linear_Ztext != "") float.TryParse(linear_Ztext, out LVZ);
        }

        private void AVXT_Changed(object sender, EventArgs e)
        {
            string ang_Vel_Xtext = AVXT.Text;
            if (ang_Vel_Xtext != "")
                float.TryParse(ang_Vel_Xtext, out AVX);
        }

        private void AVYT_Changed(object sender, EventArgs e)
        {
            string ang_Vel_Ytext = AVYT.Text;
            if (ang_Vel_Ytext != "") float.TryParse(ang_Vel_Ytext, out AVY);
        }

        private void AVZT_Changed(object sender, EventArgs e)
        {
            string ang_Vel_Ztext = AVZT.Text;
            if (ang_Vel_Ztext != "")
                float.TryParse(ang_Vel_Ztext, out AVZ);
        }

        private void ETXT_Changed(object sender, EventArgs e)
        {
            string tor_Xtext = ETXT.Text;
            if (tor_Xtext != "") float.TryParse(tor_Xtext, out ETX);
        }

        private void ETYT_Changed(object sender, EventArgs e)
        {
            string tor_Ytext = ETYT.Text;
            if (tor_Ytext != "")
                float.TryParse(tor_Ytext, out ETY);
        }

        private void ETZT_Changed(object sender, EventArgs e)
        {
            string tor_Ztext = ETZT.Text;
            if (tor_Ztext != "") float.TryParse(tor_Ztext, out ETZ);
        }

        private void EFXT_Changed(object sender, EventArgs e)
        {
            string force_Xtext = EFXT.Text;
            if (force_Xtext != "") float.TryParse(force_Xtext, out EFX);
        }

        private void EFYT_Changed(object sender, EventArgs e)
        {
            string force_Ytext = EFYT.Text;
            if (force_Ytext != "") float.TryParse(force_Ytext, out EFY);
        }

        private void EFZT_Changed(object sender, EventArgs e)
        {
            string force_Ztext = EFZT.Text;
            if (force_Ztext != "") float.TryParse(force_Ztext, out EFZ);
        }

        private void Mass_Changed(object sender, EventArgs e)
        {
            string mass_text = massT.Text;
            if (mass_text != "") float.TryParse(mass_text, out mass);
            if (mass == 0) mass = 1f;
        }
    }
}

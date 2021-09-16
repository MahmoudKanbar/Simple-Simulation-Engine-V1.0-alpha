using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Scientific_Calculations
{
    public partial class ModelRendereWindow : Form
    {
        private ModelRenderer modelRenderer;

        private string tempMN, tempMP;
        public ModelRendereWindow(SimulationObject selectedSimulationObject)
        {
            InitializeComponent();

            modelRenderer = selectedSimulationObject.GetComponent<ModelRenderer>();
            if (modelRenderer == null)
            {
                selectedSimulationObject.AddComponent<ModelRenderer>();
                modelRenderer = selectedSimulationObject.GetComponent<ModelRenderer>();
            }

            if (modelRenderer.simulationModel != null)
            {
                string modelName = modelRenderer.simulationModel.name;
                if (modelName == "ball.obj") modelsList.SetSelected(0, true);
                else if (modelName == "Cube.obj") modelsList.SetSelected(1, true);
                else if (modelName == "SurvivalBackPack.obj") modelsList.SetSelected(2, true);

                modelPath.Text = modelRenderer.simulationModel.path;
            }
        }

        private bool useByName;
        private void ChangeModelByName(object sender, EventArgs e)
        {
            if (modelsList.SelectedIndex == 0) tempMN = "ball.obj";
            else if (modelsList.GetSelected(1)) tempMN = "Cube.obj";
            else if (modelsList.GetSelected(2)) tempMN = "SurvivalBackPack.obj";
            useByName = true;
        }

        private void ChangeModelByPath(object sender, EventArgs e)
        {
            tempMP = modelPath.Text;
        }

        private void Save(object sender, EventArgs e)
        {
            if (modelsList.GetSelected(0)) { tempMN = "ball.obj"; useByName = true; }
            else if (modelsList.GetSelected(1)) { tempMN = "Cube.obj"; useByName = true; }
            else if (modelsList.GetSelected(2)) { tempMN = "SurvivalBackPack.obj"; useByName = true; }

            if (useByName)
            {
                modelRenderer.simulationModel = SimulationModel.CreateByName(tempMP);
                Close();
                return;
            }
            modelRenderer.simulationModel = SimulationModel.CreateByPath(tempMP);
            Close();
        }
    }
}

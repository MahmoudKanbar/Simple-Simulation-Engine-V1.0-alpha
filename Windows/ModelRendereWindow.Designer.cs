
namespace Scientific_Calculations
{
    partial class ModelRendereWindow
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.modelsList = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.modelPath = new System.Windows.Forms.TextBox();
            this.saveModelRenderer = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // modelsList
            // 
            this.modelsList.Font = new System.Drawing.Font("Consolas", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.modelsList.FormattingEnabled = true;
            this.modelsList.ItemHeight = 20;
            this.modelsList.Items.AddRange(new object[] {
            "Sphere",
            "Box",
            "SurvivalBackPack"});
            this.modelsList.Location = new System.Drawing.Point(159, 23);
            this.modelsList.Name = "modelsList";
            this.modelsList.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.modelsList.Size = new System.Drawing.Size(231, 84);
            this.modelsList.TabIndex = 0;
            this.modelsList.SelectedIndexChanged += new System.EventHandler(this.ChangeModelByName);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(12, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(120, 23);
            this.label1.TabIndex = 1;
            this.label1.Text = "Model Name";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(12, 129);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(120, 23);
            this.label2.TabIndex = 2;
            this.label2.Text = "Model Path";
            // 
            // modelPath
            // 
            this.modelPath.Location = new System.Drawing.Point(159, 125);
            this.modelPath.Name = "modelPath";
            this.modelPath.Size = new System.Drawing.Size(231, 27);
            this.modelPath.TabIndex = 3;
            this.modelPath.TextChanged += new System.EventHandler(this.ChangeModelByPath);
            // 
            // saveModelRenderer
            // 
            this.saveModelRenderer.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.saveModelRenderer.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.saveModelRenderer.Location = new System.Drawing.Point(12, 158);
            this.saveModelRenderer.Name = "saveModelRenderer";
            this.saveModelRenderer.Size = new System.Drawing.Size(378, 62);
            this.saveModelRenderer.TabIndex = 9;
            this.saveModelRenderer.Text = "Save";
            this.saveModelRenderer.UseVisualStyleBackColor = true;
            this.saveModelRenderer.Click += new System.EventHandler(this.Save);
            // 
            // ModelRendereWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(418, 237);
            this.Controls.Add(this.saveModelRenderer);
            this.Controls.Add(this.modelPath);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.modelsList);
            this.Name = "ModelRendereWindow";
            this.Text = "ModelRendereWindow";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox modelsList;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox modelPath;
        private System.Windows.Forms.Button saveModelRenderer;
    }
}
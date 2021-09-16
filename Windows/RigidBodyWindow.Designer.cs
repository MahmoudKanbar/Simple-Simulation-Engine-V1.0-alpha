
namespace Scientific_Calculations
{
    partial class RigidBodyWindow
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
            this.label52 = new System.Windows.Forms.Label();
            this.label48 = new System.Windows.Forms.Label();
            this.massT = new System.Windows.Forms.TextBox();
            this.EFZT = new System.Windows.Forms.TextBox();
            this.EFYT = new System.Windows.Forms.TextBox();
            this.EFXT = new System.Windows.Forms.TextBox();
            this.ETZT = new System.Windows.Forms.TextBox();
            this.ETYT = new System.Windows.Forms.TextBox();
            this.LVXT = new System.Windows.Forms.TextBox();
            this.ETXT = new System.Windows.Forms.TextBox();
            this.LVYT = new System.Windows.Forms.TextBox();
            this.label40 = new System.Windows.Forms.Label();
            this.label44 = new System.Windows.Forms.Label();
            this.AVXT = new System.Windows.Forms.TextBox();
            this.LVZT = new System.Windows.Forms.TextBox();
            this.AVYT = new System.Windows.Forms.TextBox();
            this.label18 = new System.Windows.Forms.Label();
            this.AVZT = new System.Windows.Forms.TextBox();
            this.saveButton = new System.Windows.Forms.Button();
            this.constrainsList = new System.Windows.Forms.CheckedListBox();
            this.SuspendLayout();
            // 
            // label52
            // 
            this.label52.AutoSize = true;
            this.label52.Location = new System.Drawing.Point(15, 155);
            this.label52.Name = "label52";
            this.label52.Size = new System.Drawing.Size(42, 20);
            this.label52.TabIndex = 137;
            this.label52.Text = "Mass";
            // 
            // label48
            // 
            this.label48.AutoSize = true;
            this.label48.Location = new System.Drawing.Point(12, 120);
            this.label48.Name = "label48";
            this.label48.Size = new System.Drawing.Size(102, 20);
            this.label48.TabIndex = 136;
            this.label48.Text = "External Force";
            // 
            // massT
            // 
            this.massT.Location = new System.Drawing.Point(183, 152);
            this.massT.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.massT.Name = "massT";
            this.massT.Size = new System.Drawing.Size(44, 27);
            this.massT.TabIndex = 135;
            this.massT.Text = "1";
            this.massT.TextChanged += new System.EventHandler(this.Mass_Changed);
            // 
            // EFZT
            // 
            this.EFZT.Location = new System.Drawing.Point(283, 117);
            this.EFZT.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.EFZT.Name = "EFZT";
            this.EFZT.Size = new System.Drawing.Size(44, 27);
            this.EFZT.TabIndex = 134;
            this.EFZT.Text = "0";
            this.EFZT.TextChanged += new System.EventHandler(this.EFZT_Changed);
            // 
            // EFYT
            // 
            this.EFYT.Location = new System.Drawing.Point(233, 117);
            this.EFYT.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.EFYT.Name = "EFYT";
            this.EFYT.Size = new System.Drawing.Size(44, 27);
            this.EFYT.TabIndex = 133;
            this.EFYT.Text = "0";
            this.EFYT.TextChanged += new System.EventHandler(this.EFYT_Changed);
            // 
            // EFXT
            // 
            this.EFXT.Location = new System.Drawing.Point(183, 117);
            this.EFXT.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.EFXT.Name = "EFXT";
            this.EFXT.Size = new System.Drawing.Size(44, 27);
            this.EFXT.TabIndex = 132;
            this.EFXT.Text = "0";
            this.EFXT.TextChanged += new System.EventHandler(this.EFXT_Changed);
            // 
            // ETZT
            // 
            this.ETZT.Location = new System.Drawing.Point(283, 82);
            this.ETZT.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ETZT.Name = "ETZT";
            this.ETZT.Size = new System.Drawing.Size(44, 27);
            this.ETZT.TabIndex = 131;
            this.ETZT.Text = "0";
            this.ETZT.TextChanged += new System.EventHandler(this.ETZT_Changed);
            // 
            // ETYT
            // 
            this.ETYT.Location = new System.Drawing.Point(233, 82);
            this.ETYT.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ETYT.Name = "ETYT";
            this.ETYT.Size = new System.Drawing.Size(44, 27);
            this.ETYT.TabIndex = 130;
            this.ETYT.Text = "0";
            this.ETYT.TextChanged += new System.EventHandler(this.ETYT_Changed);
            // 
            // LVXT
            // 
            this.LVXT.Location = new System.Drawing.Point(183, 12);
            this.LVXT.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.LVXT.Name = "LVXT";
            this.LVXT.Size = new System.Drawing.Size(44, 27);
            this.LVXT.TabIndex = 120;
            this.LVXT.Text = "0";
            this.LVXT.TextChanged += new System.EventHandler(this.LVXT_Changed);
            // 
            // ETXT
            // 
            this.ETXT.Location = new System.Drawing.Point(183, 82);
            this.ETXT.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ETXT.Name = "ETXT";
            this.ETXT.Size = new System.Drawing.Size(44, 27);
            this.ETXT.TabIndex = 129;
            this.ETXT.Text = "0";
            this.ETXT.TextChanged += new System.EventHandler(this.ETXT_Changed);
            // 
            // LVYT
            // 
            this.LVYT.Location = new System.Drawing.Point(233, 12);
            this.LVYT.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.LVYT.Name = "LVYT";
            this.LVYT.Size = new System.Drawing.Size(44, 27);
            this.LVYT.TabIndex = 121;
            this.LVYT.Text = "0";
            this.LVYT.TextChanged += new System.EventHandler(this.LVYT_Changed);
            // 
            // label40
            // 
            this.label40.AutoSize = true;
            this.label40.Location = new System.Drawing.Point(12, 50);
            this.label40.Name = "label40";
            this.label40.Size = new System.Drawing.Size(116, 20);
            this.label40.TabIndex = 124;
            this.label40.Text = "Angular velocity";
            this.label40.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label44
            // 
            this.label44.AutoSize = true;
            this.label44.Location = new System.Drawing.Point(12, 85);
            this.label44.Name = "label44";
            this.label44.Size = new System.Drawing.Size(112, 20);
            this.label44.TabIndex = 128;
            this.label44.Text = "External Torque";
            // 
            // AVXT
            // 
            this.AVXT.Location = new System.Drawing.Point(183, 47);
            this.AVXT.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.AVXT.Name = "AVXT";
            this.AVXT.Size = new System.Drawing.Size(44, 27);
            this.AVXT.TabIndex = 125;
            this.AVXT.Text = "0";
            this.AVXT.TextChanged += new System.EventHandler(this.AVXT_Changed);
            // 
            // LVZT
            // 
            this.LVZT.Location = new System.Drawing.Point(283, 12);
            this.LVZT.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.LVZT.Name = "LVZT";
            this.LVZT.Size = new System.Drawing.Size(44, 27);
            this.LVZT.TabIndex = 122;
            this.LVZT.Text = "0";
            this.LVZT.TextChanged += new System.EventHandler(this.LVZT_Changed);
            // 
            // AVYT
            // 
            this.AVYT.Location = new System.Drawing.Point(233, 47);
            this.AVYT.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.AVYT.Name = "AVYT";
            this.AVYT.Size = new System.Drawing.Size(44, 27);
            this.AVYT.TabIndex = 126;
            this.AVYT.Text = "0";
            this.AVYT.TextChanged += new System.EventHandler(this.AVYT_Changed);
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(12, 19);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(104, 20);
            this.label18.TabIndex = 123;
            this.label18.Text = "Linear velocity";
            // 
            // AVZT
            // 
            this.AVZT.Location = new System.Drawing.Point(283, 47);
            this.AVZT.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.AVZT.Name = "AVZT";
            this.AVZT.Size = new System.Drawing.Size(44, 27);
            this.AVZT.TabIndex = 127;
            this.AVZT.Text = "0";
            this.AVZT.TextChanged += new System.EventHandler(this.AVZT_Changed);
            // 
            // saveButton
            // 
            this.saveButton.Location = new System.Drawing.Point(19, 240);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(308, 52);
            this.saveButton.TabIndex = 138;
            this.saveButton.Text = "Save";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.SaveRigidBody);
            // 
            // constrainsList
            // 
            this.constrainsList.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.constrainsList.FormattingEnabled = true;
            this.constrainsList.Items.AddRange(new object[] {
            "IS STATIC",
            "DISABLE GRAVITY"});
            this.constrainsList.Location = new System.Drawing.Point(19, 186);
            this.constrainsList.Name = "constrainsList";
            this.constrainsList.Size = new System.Drawing.Size(308, 48);
            this.constrainsList.TabIndex = 151;
            this.constrainsList.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.UpdateConstrains);
            // 
            // RigidBodyWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.ClientSize = new System.Drawing.Size(341, 311);
            this.Controls.Add(this.constrainsList);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.label52);
            this.Controls.Add(this.label48);
            this.Controls.Add(this.massT);
            this.Controls.Add(this.EFZT);
            this.Controls.Add(this.EFYT);
            this.Controls.Add(this.EFXT);
            this.Controls.Add(this.ETZT);
            this.Controls.Add(this.ETYT);
            this.Controls.Add(this.LVXT);
            this.Controls.Add(this.ETXT);
            this.Controls.Add(this.LVYT);
            this.Controls.Add(this.label40);
            this.Controls.Add(this.label44);
            this.Controls.Add(this.AVXT);
            this.Controls.Add(this.LVZT);
            this.Controls.Add(this.AVYT);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.AVZT);
            this.Name = "RigidBodyWindow";
            this.Text = "RigidBodyWindow";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label52;
        private System.Windows.Forms.Label label48;
        private System.Windows.Forms.TextBox massT;
        private System.Windows.Forms.TextBox EFZT;
        private System.Windows.Forms.TextBox EFYT;
        private System.Windows.Forms.TextBox EFXT;
        private System.Windows.Forms.TextBox ETZT;
        private System.Windows.Forms.TextBox ETYT;
        private System.Windows.Forms.TextBox LVXT;
        private System.Windows.Forms.TextBox ETXT;
        private System.Windows.Forms.TextBox LVYT;
        private System.Windows.Forms.Label label40;
        private System.Windows.Forms.Label label44;
        private System.Windows.Forms.TextBox AVXT;
        private System.Windows.Forms.TextBox LVZT;
        private System.Windows.Forms.TextBox AVYT;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.TextBox AVZT;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.CheckedListBox constrainsList;
    }
}
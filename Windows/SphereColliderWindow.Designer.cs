
namespace Scientific_Calculations
{
    partial class SphereColliderWindow
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
            this.saveButton = new System.Windows.Forms.Button();
            this.RCZT = new System.Windows.Forms.TextBox();
            this.RCYT = new System.Windows.Forms.TextBox();
            this.RCXT = new System.Windows.Forms.TextBox();
            this.label25 = new System.Windows.Forms.Label();
            this.RT = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // saveButton
            // 
            this.saveButton.Location = new System.Drawing.Point(273, 12);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(229, 62);
            this.saveButton.TabIndex = 131;
            this.saveButton.Text = "Save";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.SaveSphereCollider);
            // 
            // RCZT
            // 
            this.RCZT.Location = new System.Drawing.Point(223, 12);
            this.RCZT.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.RCZT.Name = "RCZT";
            this.RCZT.Size = new System.Drawing.Size(44, 27);
            this.RCZT.TabIndex = 130;
            this.RCZT.Text = "0";
            this.RCZT.TextChanged += new System.EventHandler(this.RCZTextChanged);
            // 
            // RCYT
            // 
            this.RCYT.Location = new System.Drawing.Point(173, 12);
            this.RCYT.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.RCYT.Name = "RCYT";
            this.RCYT.Size = new System.Drawing.Size(44, 27);
            this.RCYT.TabIndex = 129;
            this.RCYT.Text = "0";
            this.RCYT.TextChanged += new System.EventHandler(this.RCYTextChanged);
            // 
            // RCXT
            // 
            this.RCXT.Location = new System.Drawing.Point(123, 12);
            this.RCXT.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.RCXT.Name = "RCXT";
            this.RCXT.Size = new System.Drawing.Size(44, 27);
            this.RCXT.TabIndex = 128;
            this.RCXT.Text = "0";
            this.RCXT.TextChanged += new System.EventHandler(this.RCXTextChanged);
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Location = new System.Drawing.Point(10, 16);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(107, 20);
            this.label25.TabIndex = 127;
            this.label25.Text = "Relative center";
            // 
            // RT
            // 
            this.RT.Location = new System.Drawing.Point(123, 47);
            this.RT.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.RT.Name = "RT";
            this.RT.Size = new System.Drawing.Size(44, 27);
            this.RT.TabIndex = 133;
            this.RT.Text = "1";
            this.RT.TextChanged += new System.EventHandler(this.RTextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 51);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 20);
            this.label1.TabIndex = 132;
            this.label1.Text = "Radius";
            // 
            // SphereColliderWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.ClientSize = new System.Drawing.Size(513, 84);
            this.Controls.Add(this.RT);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.RCZT);
            this.Controls.Add(this.RCYT);
            this.Controls.Add(this.RCXT);
            this.Controls.Add(this.label25);
            this.Name = "SphereColliderWindow";
            this.Text = "SphereColliderWindow";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.TextBox RCZT;
        private System.Windows.Forms.TextBox RCYT;
        private System.Windows.Forms.TextBox RCXT;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.TextBox RT;
        private System.Windows.Forms.Label label1;
    }
}
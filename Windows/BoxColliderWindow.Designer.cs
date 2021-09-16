
namespace Scientific_Calculations
{
    partial class BoxColliderWindow
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
            this.RCZT = new System.Windows.Forms.TextBox();
            this.RCYT = new System.Windows.Forms.TextBox();
            this.RCXT = new System.Windows.Forms.TextBox();
            this.label25 = new System.Windows.Forms.Label();
            this.HEZT = new System.Windows.Forms.TextBox();
            this.label19 = new System.Windows.Forms.Label();
            this.HEYT = new System.Windows.Forms.TextBox();
            this.HEXT = new System.Windows.Forms.TextBox();
            this.saveButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // RCZT
            // 
            this.RCZT.Location = new System.Drawing.Point(225, 5);
            this.RCZT.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.RCZT.Name = "RCZT";
            this.RCZT.Size = new System.Drawing.Size(44, 27);
            this.RCZT.TabIndex = 125;
            this.RCZT.Text = "0";
            this.RCZT.TextChanged += new System.EventHandler(this.RCZTextChanged);
            // 
            // RCYT
            // 
            this.RCYT.Location = new System.Drawing.Point(175, 5);
            this.RCYT.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.RCYT.Name = "RCYT";
            this.RCYT.Size = new System.Drawing.Size(44, 27);
            this.RCYT.TabIndex = 124;
            this.RCYT.Text = "0";
            this.RCYT.TextChanged += new System.EventHandler(this.RCYTextChanged);
            // 
            // RCXT
            // 
            this.RCXT.Location = new System.Drawing.Point(125, 5);
            this.RCXT.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.RCXT.Name = "RCXT";
            this.RCXT.Size = new System.Drawing.Size(44, 27);
            this.RCXT.TabIndex = 123;
            this.RCXT.Text = "0";
            this.RCXT.TextChanged += new System.EventHandler(this.RCXTextChanged);
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Location = new System.Drawing.Point(12, 9);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(107, 20);
            this.label25.TabIndex = 122;
            this.label25.Text = "Relative center";
            // 
            // HEZT
            // 
            this.HEZT.Location = new System.Drawing.Point(225, 40);
            this.HEZT.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.HEZT.Name = "HEZT";
            this.HEZT.Size = new System.Drawing.Size(44, 27);
            this.HEZT.TabIndex = 121;
            this.HEZT.Text = "1";
            this.HEZT.TextChanged += new System.EventHandler(this.HEZTextChanged);
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(12, 43);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(88, 20);
            this.label19.TabIndex = 118;
            this.label19.Text = "Half externs";
            // 
            // HEYT
            // 
            this.HEYT.Location = new System.Drawing.Point(175, 40);
            this.HEYT.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.HEYT.Name = "HEYT";
            this.HEYT.Size = new System.Drawing.Size(44, 27);
            this.HEYT.TabIndex = 120;
            this.HEYT.Text = "1";
            this.HEYT.TextChanged += new System.EventHandler(this.HEYTextChanged);
            // 
            // HEXT
            // 
            this.HEXT.Location = new System.Drawing.Point(125, 40);
            this.HEXT.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.HEXT.Name = "HEXT";
            this.HEXT.Size = new System.Drawing.Size(44, 27);
            this.HEXT.TabIndex = 119;
            this.HEXT.Text = "1";
            this.HEXT.TextChanged += new System.EventHandler(this.HEXTextChanged);
            // 
            // saveButton
            // 
            this.saveButton.Location = new System.Drawing.Point(275, 5);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(229, 62);
            this.saveButton.TabIndex = 126;
            this.saveButton.Text = "Save";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.SaveBoxCollider);
            // 
            // BoxColliderWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.ClientSize = new System.Drawing.Size(516, 79);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.RCZT);
            this.Controls.Add(this.RCYT);
            this.Controls.Add(this.RCXT);
            this.Controls.Add(this.label25);
            this.Controls.Add(this.HEZT);
            this.Controls.Add(this.label19);
            this.Controls.Add(this.HEYT);
            this.Controls.Add(this.HEXT);
            this.Name = "BoxColliderWindow";
            this.Text = "BoxColliderWindow";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox RCZT;
        private System.Windows.Forms.TextBox RCYT;
        private System.Windows.Forms.TextBox RCXT;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.TextBox HEZT;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.TextBox HEYT;
        private System.Windows.Forms.TextBox HEXT;
        private System.Windows.Forms.Button saveButton;
    }
}
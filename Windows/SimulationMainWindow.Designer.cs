
namespace Scientific_Calculations
{
    partial class SimulationMainWindow
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.SimulationObjectInfo = new System.Windows.Forms.TextBox();
            this.addSimulationObjectButton = new System.Windows.Forms.Button();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.runEngineButton = new System.Windows.Forms.Button();
            this.runEarthDemoButton = new System.Windows.Forms.Button();
            this.runRoomDemoButton = new System.Windows.Forms.Button();
            this.simulationObjectsList = new System.Windows.Forms.ListView();
            this.SimulationObjects = new System.Windows.Forms.ColumnHeader();
            this.label9 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.RZT = new System.Windows.Forms.TextBox();
            this.RYT = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.SZT = new System.Windows.Forms.TextBox();
            this.SYT = new System.Windows.Forms.TextBox();
            this.PZT = new System.Windows.Forms.TextBox();
            this.PYT = new System.Windows.Forms.TextBox();
            this.PXT = new System.Windows.Forms.TextBox();
            this.RXT = new System.Windows.Forms.TextBox();
            this.SXT = new System.Windows.Forms.TextBox();
            this.label63 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.showObjects = new System.Windows.Forms.CheckBox();
            this.showColliders = new System.Windows.Forms.CheckBox();
            this.saveConstrainsButton = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.FCST = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.FCKT = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.ADT = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.GXT = new System.Windows.Forms.TextBox();
            this.GYT = new System.Windows.Forms.TextBox();
            this.GZT = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.rigidBodyButton = new System.Windows.Forms.Button();
            this.sphereCollider = new System.Windows.Forms.Button();
            this.boxColliderButton = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.DRBB = new System.Windows.Forms.Button();
            this.DSCB = new System.Windows.Forms.Button();
            this.DBCB = new System.Windows.Forms.Button();
            this.CameraButton = new System.Windows.Forms.Button();
            this.DCB = new System.Windows.Forms.Button();
            this.modelRendererButton = new System.Windows.Forms.Button();
            this.DMR = new System.Windows.Forms.Button();
            this.saveTransform = new System.Windows.Forms.Button();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // SimulationObjectInfo
            // 
            this.SimulationObjectInfo.BackColor = System.Drawing.Color.Silver;
            this.SimulationObjectInfo.ForeColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.SimulationObjectInfo.Location = new System.Drawing.Point(658, 47);
            this.SimulationObjectInfo.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.SimulationObjectInfo.Multiline = true;
            this.SimulationObjectInfo.Name = "SimulationObjectInfo";
            this.SimulationObjectInfo.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.SimulationObjectInfo.Size = new System.Drawing.Size(504, 410);
            this.SimulationObjectInfo.TabIndex = 1;
            // 
            // addSimulationObjectButton
            // 
            this.addSimulationObjectButton.BackColor = System.Drawing.SystemColors.MenuBar;
            this.addSimulationObjectButton.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.addSimulationObjectButton.ForeColor = System.Drawing.Color.Black;
            this.addSimulationObjectButton.Location = new System.Drawing.Point(12, 623);
            this.addSimulationObjectButton.Margin = new System.Windows.Forms.Padding(0);
            this.addSimulationObjectButton.Name = "addSimulationObjectButton";
            this.addSimulationObjectButton.Size = new System.Drawing.Size(332, 73);
            this.addSimulationObjectButton.TabIndex = 0;
            this.addSimulationObjectButton.Text = "Add Simulation Object";
            this.addSimulationObjectButton.UseVisualStyleBackColor = false;
            this.addSimulationObjectButton.Click += new System.EventHandler(this.AddSimulationObject);
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 3;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(200, 100);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tableLayoutPanel3.ColumnCount = 1;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel3.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 3;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(200, 100);
            this.tableLayoutPanel3.TabIndex = 0;
            // 
            // runEngineButton
            // 
            this.runEngineButton.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.runEngineButton.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.runEngineButton.Location = new System.Drawing.Point(658, 464);
            this.runEngineButton.Name = "runEngineButton";
            this.runEngineButton.Size = new System.Drawing.Size(164, 35);
            this.runEngineButton.TabIndex = 8;
            this.runEngineButton.Text = "Run Engine";
            this.runEngineButton.UseVisualStyleBackColor = true;
            this.runEngineButton.Click += new System.EventHandler(this.RunEngine);
            // 
            // runEarthDemoButton
            // 
            this.runEarthDemoButton.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.runEarthDemoButton.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.runEarthDemoButton.Location = new System.Drawing.Point(998, 464);
            this.runEarthDemoButton.Name = "runEarthDemoButton";
            this.runEarthDemoButton.Size = new System.Drawing.Size(164, 35);
            this.runEarthDemoButton.TabIndex = 9;
            this.runEarthDemoButton.Text = "Run Earth Demo";
            this.runEarthDemoButton.UseVisualStyleBackColor = true;
            this.runEarthDemoButton.Click += new System.EventHandler(this.RunEarth);
            // 
            // runRoomDemoButton
            // 
            this.runRoomDemoButton.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.runRoomDemoButton.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.runRoomDemoButton.Location = new System.Drawing.Point(828, 464);
            this.runRoomDemoButton.Name = "runRoomDemoButton";
            this.runRoomDemoButton.Size = new System.Drawing.Size(164, 35);
            this.runRoomDemoButton.TabIndex = 10;
            this.runRoomDemoButton.Text = "Run Room Demo";
            this.runRoomDemoButton.UseVisualStyleBackColor = true;
            this.runRoomDemoButton.Click += new System.EventHandler(this.RunRoom);
            // 
            // simulationObjectsList
            // 
            this.simulationObjectsList.Activation = System.Windows.Forms.ItemActivation.OneClick;
            this.simulationObjectsList.AllowDrop = true;
            this.simulationObjectsList.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.simulationObjectsList.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.simulationObjectsList.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.simulationObjectsList.CausesValidation = false;
            this.simulationObjectsList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.SimulationObjects});
            this.simulationObjectsList.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.simulationObjectsList.HideSelection = false;
            this.simulationObjectsList.LabelWrap = false;
            this.simulationObjectsList.Location = new System.Drawing.Point(12, 13);
            this.simulationObjectsList.Margin = new System.Windows.Forms.Padding(0);
            this.simulationObjectsList.Name = "simulationObjectsList";
            this.simulationObjectsList.ShowGroups = false;
            this.simulationObjectsList.Size = new System.Drawing.Size(332, 599);
            this.simulationObjectsList.TabIndex = 11;
            this.simulationObjectsList.TabStop = false;
            this.simulationObjectsList.UseCompatibleStateImageBehavior = false;
            this.simulationObjectsList.View = System.Windows.Forms.View.Details;
            this.simulationObjectsList.SelectedIndexChanged += new System.EventHandler(this.ChangeSelectedSM);
            // 
            // SimulationObjects
            // 
            this.SimulationObjects.Text = "Simulation Objects ";
            this.SimulationObjects.Width = 333;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label9.Location = new System.Drawing.Point(9, 117);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(48, 18);
            this.label9.TabIndex = 16;
            this.label9.Text = "Scale";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label5.Location = new System.Drawing.Point(9, 83);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(72, 18);
            this.label5.TabIndex = 9;
            this.label5.Text = "Rotation";
            // 
            // RZT
            // 
            this.RZT.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.RZT.Location = new System.Drawing.Point(222, 79);
            this.RZT.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.RZT.Name = "RZT";
            this.RZT.Size = new System.Drawing.Size(44, 25);
            this.RZT.TabIndex = 18;
            this.RZT.Text = "0";
            this.RZT.TextChanged += new System.EventHandler(this.RZTextChanged);
            // 
            // RYT
            // 
            this.RYT.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.RYT.Location = new System.Drawing.Point(172, 79);
            this.RYT.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.RYT.Name = "RYT";
            this.RYT.Size = new System.Drawing.Size(44, 25);
            this.RYT.TabIndex = 11;
            this.RYT.Text = "0";
            this.RYT.TextChanged += new System.EventHandler(this.RYTextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label4.Location = new System.Drawing.Point(9, 51);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(72, 18);
            this.label4.TabIndex = 8;
            this.label4.Text = "Position";
            // 
            // SZT
            // 
            this.SZT.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.SZT.Location = new System.Drawing.Point(222, 114);
            this.SZT.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.SZT.Name = "SZT";
            this.SZT.Size = new System.Drawing.Size(44, 25);
            this.SZT.TabIndex = 12;
            this.SZT.Text = "1";
            this.SZT.TextChanged += new System.EventHandler(this.SZTextChanged);
            // 
            // SYT
            // 
            this.SYT.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.SYT.Location = new System.Drawing.Point(172, 114);
            this.SYT.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.SYT.Name = "SYT";
            this.SYT.Size = new System.Drawing.Size(44, 25);
            this.SYT.TabIndex = 19;
            this.SYT.Text = "1";
            this.SYT.TextChanged += new System.EventHandler(this.SYTextChanged);
            // 
            // PZT
            // 
            this.PZT.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.PZT.Location = new System.Drawing.Point(222, 44);
            this.PZT.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.PZT.Name = "PZT";
            this.PZT.Size = new System.Drawing.Size(46, 25);
            this.PZT.TabIndex = 3;
            this.PZT.Text = "0";
            this.PZT.TextChanged += new System.EventHandler(this.PZTextChanged);
            // 
            // PYT
            // 
            this.PYT.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.PYT.Location = new System.Drawing.Point(172, 44);
            this.PYT.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.PYT.Name = "PYT";
            this.PYT.Size = new System.Drawing.Size(44, 25);
            this.PYT.TabIndex = 2;
            this.PYT.Text = "0";
            this.PYT.TextChanged += new System.EventHandler(this.PYTextChanged);
            // 
            // PXT
            // 
            this.PXT.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.PXT.Location = new System.Drawing.Point(122, 45);
            this.PXT.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.PXT.Name = "PXT";
            this.PXT.Size = new System.Drawing.Size(44, 25);
            this.PXT.TabIndex = 7;
            this.PXT.Text = "0";
            this.PXT.TextChanged += new System.EventHandler(this.PXTextChanged);
            // 
            // RXT
            // 
            this.RXT.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.RXT.Location = new System.Drawing.Point(122, 80);
            this.RXT.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.RXT.Name = "RXT";
            this.RXT.Size = new System.Drawing.Size(44, 25);
            this.RXT.TabIndex = 47;
            this.RXT.Text = "0";
            this.RXT.TextChanged += new System.EventHandler(this.RXTextChanged);
            // 
            // SXT
            // 
            this.SXT.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.SXT.Location = new System.Drawing.Point(122, 115);
            this.SXT.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.SXT.Name = "SXT";
            this.SXT.Size = new System.Drawing.Size(44, 25);
            this.SXT.TabIndex = 48;
            this.SXT.Text = "1";
            this.SXT.TextChanged += new System.EventHandler(this.SXTextChanged);
            // 
            // label63
            // 
            this.label63.AutoSize = true;
            this.label63.Font = new System.Drawing.Font("Consolas", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label63.Location = new System.Drawing.Point(3, 12);
            this.label63.Name = "label63";
            this.label63.Size = new System.Drawing.Size(194, 28);
            this.label63.TabIndex = 63;
            this.label63.Text = "Transform Data";
            // 
            // panel3
            // 
            this.panel3.AutoScroll = true;
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.saveTransform);
            this.panel3.Controls.Add(this.showObjects);
            this.panel3.Controls.Add(this.showColliders);
            this.panel3.Controls.Add(this.saveConstrainsButton);
            this.panel3.Controls.Add(this.label7);
            this.panel3.Controls.Add(this.FCST);
            this.panel3.Controls.Add(this.label1);
            this.panel3.Controls.Add(this.FCKT);
            this.panel3.Controls.Add(this.label2);
            this.panel3.Controls.Add(this.ADT);
            this.panel3.Controls.Add(this.label3);
            this.panel3.Controls.Add(this.GXT);
            this.panel3.Controls.Add(this.GYT);
            this.panel3.Controls.Add(this.GZT);
            this.panel3.Controls.Add(this.label6);
            this.panel3.Controls.Add(this.label63);
            this.panel3.Controls.Add(this.SXT);
            this.panel3.Controls.Add(this.RXT);
            this.panel3.Controls.Add(this.PXT);
            this.panel3.Controls.Add(this.PYT);
            this.panel3.Controls.Add(this.PZT);
            this.panel3.Controls.Add(this.SYT);
            this.panel3.Controls.Add(this.SZT);
            this.panel3.Controls.Add(this.label4);
            this.panel3.Controls.Add(this.RYT);
            this.panel3.Controls.Add(this.RZT);
            this.panel3.Controls.Add(this.label5);
            this.panel3.Controls.Add(this.label9);
            this.panel3.Location = new System.Drawing.Point(350, 13);
            this.panel3.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(302, 683);
            this.panel3.TabIndex = 6;
            // 
            // showObjects
            // 
            this.showObjects.AutoSize = true;
            this.showObjects.Checked = true;
            this.showObjects.CheckState = System.Windows.Forms.CheckState.Checked;
            this.showObjects.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.showObjects.Location = new System.Drawing.Point(4, 445);
            this.showObjects.Name = "showObjects";
            this.showObjects.Size = new System.Drawing.Size(164, 27);
            this.showObjects.TabIndex = 171;
            this.showObjects.Text = "Show Objects";
            this.showObjects.UseVisualStyleBackColor = true;
            this.showObjects.CheckedChanged += new System.EventHandler(this.ShowOrHideObjects);
            // 
            // showColliders
            // 
            this.showColliders.AutoSize = true;
            this.showColliders.Checked = true;
            this.showColliders.CheckState = System.Windows.Forms.CheckState.Checked;
            this.showColliders.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.showColliders.Location = new System.Drawing.Point(4, 412);
            this.showColliders.Name = "showColliders";
            this.showColliders.Size = new System.Drawing.Size(186, 27);
            this.showColliders.TabIndex = 170;
            this.showColliders.Text = "Show Colliders";
            this.showColliders.UseVisualStyleBackColor = true;
            this.showColliders.CheckedChanged += new System.EventHandler(this.ShowOrHideColliders);
            // 
            // saveConstrainsButton
            // 
            this.saveConstrainsButton.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.saveConstrainsButton.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.saveConstrainsButton.Location = new System.Drawing.Point(3, 377);
            this.saveConstrainsButton.Name = "saveConstrainsButton";
            this.saveConstrainsButton.Size = new System.Drawing.Size(294, 29);
            this.saveConstrainsButton.TabIndex = 168;
            this.saveConstrainsButton.Text = "Save Constrains";
            this.saveConstrainsButton.UseVisualStyleBackColor = true;
            this.saveConstrainsButton.Click += new System.EventHandler(this.SaveConstrains);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Consolas", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label7.Location = new System.Drawing.Point(3, 207);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(285, 28);
            this.label7.TabIndex = 162;
            this.label7.Text = "Simulation Constrains";
            // 
            // FCST
            // 
            this.FCST.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.FCST.Location = new System.Drawing.Point(243, 351);
            this.FCST.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.FCST.Name = "FCST";
            this.FCST.Size = new System.Drawing.Size(44, 25);
            this.FCST.TabIndex = 160;
            this.FCST.Text = "0";
            this.FCST.TextChanged += new System.EventHandler(this.FCSTextChange);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(9, 354);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(184, 18);
            this.label1.TabIndex = 161;
            this.label1.Text = "Friction Coefficient S";
            // 
            // FCKT
            // 
            this.FCKT.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.FCKT.Location = new System.Drawing.Point(243, 316);
            this.FCKT.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.FCKT.Name = "FCKT";
            this.FCKT.Size = new System.Drawing.Size(44, 25);
            this.FCKT.TabIndex = 158;
            this.FCKT.Text = "0";
            this.FCKT.TextChanged += new System.EventHandler(this.FCKTextChange);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(9, 319);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(184, 18);
            this.label2.TabIndex = 159;
            this.label2.Text = "Friction Coefficient K";
            // 
            // ADT
            // 
            this.ADT.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ADT.Location = new System.Drawing.Point(243, 284);
            this.ADT.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ADT.Name = "ADT";
            this.ADT.Size = new System.Drawing.Size(44, 25);
            this.ADT.TabIndex = 156;
            this.ADT.Text = "0";
            this.ADT.TextChanged += new System.EventHandler(this.ADTextChange);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label3.Location = new System.Drawing.Point(9, 284);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(96, 18);
            this.label3.TabIndex = 157;
            this.label3.Text = "Air Density";
            // 
            // GXT
            // 
            this.GXT.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.GXT.Location = new System.Drawing.Point(143, 248);
            this.GXT.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.GXT.Name = "GXT";
            this.GXT.Size = new System.Drawing.Size(44, 25);
            this.GXT.TabIndex = 152;
            this.GXT.Text = "0";
            this.GXT.TextChanged += new System.EventHandler(this.GXTextChange);
            // 
            // GYT
            // 
            this.GYT.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.GYT.Location = new System.Drawing.Point(193, 248);
            this.GYT.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.GYT.Name = "GYT";
            this.GYT.Size = new System.Drawing.Size(44, 25);
            this.GYT.TabIndex = 153;
            this.GYT.Text = "0";
            this.GYT.TextChanged += new System.EventHandler(this.GYTextChange);
            // 
            // GZT
            // 
            this.GZT.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.GZT.Location = new System.Drawing.Point(243, 248);
            this.GZT.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.GZT.Name = "GZT";
            this.GZT.Size = new System.Drawing.Size(44, 25);
            this.GZT.TabIndex = 154;
            this.GZT.Text = "0";
            this.GZT.TextChanged += new System.EventHandler(this.GZTextChange);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label6.Location = new System.Drawing.Point(9, 248);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(120, 18);
            this.label6.TabIndex = 155;
            this.label6.Text = "Global Gravity";
            // 
            // rigidBodyButton
            // 
            this.rigidBodyButton.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.rigidBodyButton.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.rigidBodyButton.Location = new System.Drawing.Point(658, 525);
            this.rigidBodyButton.Name = "rigidBodyButton";
            this.rigidBodyButton.Size = new System.Drawing.Size(125, 29);
            this.rigidBodyButton.TabIndex = 12;
            this.rigidBodyButton.Text = "Rigid Body";
            this.rigidBodyButton.UseVisualStyleBackColor = true;
            this.rigidBodyButton.Click += new System.EventHandler(this.RigidBodyAction);
            // 
            // sphereCollider
            // 
            this.sphereCollider.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.sphereCollider.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.sphereCollider.Location = new System.Drawing.Point(658, 595);
            this.sphereCollider.Name = "sphereCollider";
            this.sphereCollider.Size = new System.Drawing.Size(125, 29);
            this.sphereCollider.TabIndex = 13;
            this.sphereCollider.Text = "Sphere Colllider";
            this.sphereCollider.UseVisualStyleBackColor = true;
            this.sphereCollider.Click += new System.EventHandler(this.SphereColliderAction);
            // 
            // boxColliderButton
            // 
            this.boxColliderButton.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.boxColliderButton.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.boxColliderButton.Location = new System.Drawing.Point(658, 560);
            this.boxColliderButton.Name = "boxColliderButton";
            this.boxColliderButton.Size = new System.Drawing.Size(125, 29);
            this.boxColliderButton.TabIndex = 14;
            this.boxColliderButton.Text = "Box Collider";
            this.boxColliderButton.UseVisualStyleBackColor = true;
            this.boxColliderButton.Click += new System.EventHandler(this.BoxColliderAction);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Consolas", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label8.Location = new System.Drawing.Point(658, 12);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(363, 28);
            this.label8.TabIndex = 15;
            this.label8.Text = "Selected Object Information";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(658, 502);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(507, 20);
            this.label10.TabIndex = 162;
            this.label10.Text = "---------------------------------------------------------------------------------" +
    "--";
            // 
            // DRBB
            // 
            this.DRBB.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.DRBB.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.DRBB.Location = new System.Drawing.Point(789, 525);
            this.DRBB.Name = "DRBB";
            this.DRBB.Size = new System.Drawing.Size(125, 29);
            this.DRBB.TabIndex = 163;
            this.DRBB.Text = "Delete";
            this.DRBB.UseVisualStyleBackColor = true;
            this.DRBB.Click += new System.EventHandler(this.DeleteRigidBody);
            // 
            // DSCB
            // 
            this.DSCB.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.DSCB.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.DSCB.Location = new System.Drawing.Point(789, 595);
            this.DSCB.Name = "DSCB";
            this.DSCB.Size = new System.Drawing.Size(125, 29);
            this.DSCB.TabIndex = 164;
            this.DSCB.Text = "Delete";
            this.DSCB.UseVisualStyleBackColor = true;
            this.DSCB.Click += new System.EventHandler(this.DeleteSphereCollider);
            // 
            // DBCB
            // 
            this.DBCB.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.DBCB.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.DBCB.Location = new System.Drawing.Point(789, 560);
            this.DBCB.Name = "DBCB";
            this.DBCB.Size = new System.Drawing.Size(125, 29);
            this.DBCB.TabIndex = 165;
            this.DBCB.Text = "Delete";
            this.DBCB.UseVisualStyleBackColor = true;
            this.DBCB.Click += new System.EventHandler(this.DeleteBoxCollider);
            // 
            // CameraButton
            // 
            this.CameraButton.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.CameraButton.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.CameraButton.Location = new System.Drawing.Point(658, 630);
            this.CameraButton.Name = "CameraButton";
            this.CameraButton.Size = new System.Drawing.Size(125, 29);
            this.CameraButton.TabIndex = 166;
            this.CameraButton.Text = "Add Camera";
            this.CameraButton.UseVisualStyleBackColor = true;
            this.CameraButton.Click += new System.EventHandler(this.CameraAction);
            // 
            // DCB
            // 
            this.DCB.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.DCB.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.DCB.Location = new System.Drawing.Point(789, 630);
            this.DCB.Name = "DCB";
            this.DCB.Size = new System.Drawing.Size(125, 29);
            this.DCB.TabIndex = 167;
            this.DCB.Text = "Delete";
            this.DCB.UseVisualStyleBackColor = true;
            this.DCB.Click += new System.EventHandler(this.DeleteCamera);
            // 
            // modelRendererButton
            // 
            this.modelRendererButton.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.modelRendererButton.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.modelRendererButton.Location = new System.Drawing.Point(658, 665);
            this.modelRendererButton.Name = "modelRendererButton";
            this.modelRendererButton.Size = new System.Drawing.Size(125, 29);
            this.modelRendererButton.TabIndex = 168;
            this.modelRendererButton.Text = "Model";
            this.modelRendererButton.UseVisualStyleBackColor = true;
            this.modelRendererButton.Click += new System.EventHandler(this.ModelRendererAction);
            // 
            // DMR
            // 
            this.DMR.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.DMR.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.DMR.Location = new System.Drawing.Point(789, 665);
            this.DMR.Name = "DMR";
            this.DMR.Size = new System.Drawing.Size(125, 29);
            this.DMR.TabIndex = 169;
            this.DMR.Text = "Delete";
            this.DMR.UseVisualStyleBackColor = true;
            this.DMR.Click += new System.EventHandler(this.DeleteModelRenderer);
            // 
            // saveTransform
            // 
            this.saveTransform.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.saveTransform.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.saveTransform.Location = new System.Drawing.Point(3, 147);
            this.saveTransform.Name = "saveTransform";
            this.saveTransform.Size = new System.Drawing.Size(294, 29);
            this.saveTransform.TabIndex = 172;
            this.saveTransform.Text = "Save Transform";
            this.saveTransform.UseVisualStyleBackColor = true;
            this.saveTransform.Click += new System.EventHandler(this.SaveTransform);
            // 
            // SimulationMainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(1172, 720);
            this.Controls.Add(this.DMR);
            this.Controls.Add(this.modelRendererButton);
            this.Controls.Add(this.DCB);
            this.Controls.Add(this.CameraButton);
            this.Controls.Add(this.DBCB);
            this.Controls.Add(this.DSCB);
            this.Controls.Add(this.DRBB);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.boxColliderButton);
            this.Controls.Add(this.SimulationObjectInfo);
            this.Controls.Add(this.sphereCollider);
            this.Controls.Add(this.rigidBodyButton);
            this.Controls.Add(this.simulationObjectsList);
            this.Controls.Add(this.runRoomDemoButton);
            this.Controls.Add(this.runEarthDemoButton);
            this.Controls.Add(this.runEngineButton);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.addSimulationObjectButton);
            this.ForeColor = System.Drawing.SystemColors.Control;
            this.Name = "SimulationMainWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button addSimulationObjectButton;
        private System.Windows.Forms.TextBox SimulationObjectInfo;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.Button runEngineButton;
        private System.Windows.Forms.Button runEarthDemoButton;
        private System.Windows.Forms.Button runRoomDemoButton;
        private System.Windows.Forms.ListView simulationObjectsList;
        private System.Windows.Forms.ColumnHeader SimulationObjects;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox RZT;
        private System.Windows.Forms.TextBox RYT;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox SZT;
        private System.Windows.Forms.TextBox SYT;
        private System.Windows.Forms.TextBox PZT;
        private System.Windows.Forms.TextBox PYT;
        private System.Windows.Forms.TextBox PXT;
        private System.Windows.Forms.TextBox RXT;
        private System.Windows.Forms.TextBox SXT;
        private System.Windows.Forms.Label label63;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button rigidBodyButton;
        private System.Windows.Forms.Button sphereCollider;
        private System.Windows.Forms.Button boxColliderButton;
        private System.Windows.Forms.TextBox FCST;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox FCKT;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox ADT;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox GXT;
        private System.Windows.Forms.TextBox GYT;
        private System.Windows.Forms.TextBox GZT;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button DRBB;
        private System.Windows.Forms.Button DSCB;
        private System.Windows.Forms.Button DBCB;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button CameraButton;
        private System.Windows.Forms.Button DCB;
        private System.Windows.Forms.Button saveConstrainsButton;
        private System.Windows.Forms.Button modelRendererButton;
        private System.Windows.Forms.Button DMR;
        private System.Windows.Forms.CheckBox showObjects;
        private System.Windows.Forms.CheckBox showColliders;
        private System.Windows.Forms.Button saveTransform;
    }
}


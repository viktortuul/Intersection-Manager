namespace Main
{
    partial class MainFrame
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
            this.components = new System.ComponentModel.Container();
            this.btnAll = new System.Windows.Forms.Button();
            this.pbSimulation = new System.Windows.Forms.PictureBox();
            this.timer_simulation = new System.Windows.Forms.Timer(this.components);
            this.label3 = new System.Windows.Forms.Label();
            this.cBRun = new System.Windows.Forms.CheckBox();
            this.cBShowGhost = new System.Windows.Forms.CheckBox();
            this.btnN = new System.Windows.Forms.Button();
            this.btnE = new System.Windows.Forms.Button();
            this.btnW = new System.Windows.Forms.Button();
            this.btnS = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cBTarget = new System.Windows.Forms.CheckBox();
            this.btnRand = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.cBShowZones = new System.Windows.Forms.CheckBox();
            this.nudZoom = new System.Windows.Forms.NumericUpDown();
            this.cBZoom = new System.Windows.Forms.CheckBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.nudDelayAIM = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.nudSpawnSpeed = new System.Windows.Forms.NumericUpDown();
            this.label7 = new System.Windows.Forms.Label();
            this.nudSpeedLimit = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.nudDistMargin = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.tBApproachingVehicles = new System.Windows.Forms.TextBox();
            this.timer_print = new System.Windows.Forms.Timer(this.components);
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.btnStartTest = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.nudDelay = new System.Windows.Forms.NumericUpDown();
            this.nudTestLength = new System.Windows.Forms.NumericUpDown();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.labelDuration = new System.Windows.Forms.Label();
            this.pbProjection = new System.Windows.Forms.PictureBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.cbTrafficLights = new System.Windows.Forms.CheckBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.timerSignal = new System.Windows.Forms.Timer(this.components);
            this.label4 = new System.Windows.Forms.Label();
            this.timerYellow = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pbSimulation)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudZoom)).BeginInit();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudDelayAIM)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudSpawnSpeed)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudSpeedLimit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudDistMargin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudDelay)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudTestLength)).BeginInit();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbProjection)).BeginInit();
            this.SuspendLayout();
            // 
            // btnAll
            // 
            this.btnAll.Location = new System.Drawing.Point(49, 58);
            this.btnAll.Margin = new System.Windows.Forms.Padding(2);
            this.btnAll.Name = "btnAll";
            this.btnAll.Size = new System.Drawing.Size(40, 40);
            this.btnAll.TabIndex = 0;
            this.btnAll.Text = "All";
            this.btnAll.UseVisualStyleBackColor = true;
            this.btnAll.Click += new System.EventHandler(this.button1_Click);
            // 
            // pbSimulation
            // 
            this.pbSimulation.BackColor = System.Drawing.Color.White;
            this.pbSimulation.Location = new System.Drawing.Point(410, 3);
            this.pbSimulation.Margin = new System.Windows.Forms.Padding(2);
            this.pbSimulation.Name = "pbSimulation";
            this.pbSimulation.Size = new System.Drawing.Size(805, 805);
            this.pbSimulation.TabIndex = 2;
            this.pbSimulation.TabStop = false;
            // 
            // timer_simulation
            // 
            this.timer_simulation.Interval = 10;
            this.timer_simulation.Tick += new System.EventHandler(this.timer_simulation_Tick);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 4);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(93, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Vehicles in system";
            // 
            // cBRun
            // 
            this.cBRun.AutoSize = true;
            this.cBRun.Checked = true;
            this.cBRun.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cBRun.Location = new System.Drawing.Point(6, 19);
            this.cBRun.Name = "cBRun";
            this.cBRun.Size = new System.Drawing.Size(46, 17);
            this.cBRun.TabIndex = 8;
            this.cBRun.Text = "Run";
            this.cBRun.UseVisualStyleBackColor = true;
            this.cBRun.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // cBShowGhost
            // 
            this.cBShowGhost.AutoSize = true;
            this.cBShowGhost.Location = new System.Drawing.Point(6, 65);
            this.cBShowGhost.Name = "cBShowGhost";
            this.cBShowGhost.Size = new System.Drawing.Size(82, 17);
            this.cBShowGhost.TabIndex = 11;
            this.cBShowGhost.Text = "Show ghost";
            this.cBShowGhost.UseVisualStyleBackColor = true;
            this.cBShowGhost.CheckedChanged += new System.EventHandler(this.checkBox2_CheckedChanged);
            // 
            // btnN
            // 
            this.btnN.Location = new System.Drawing.Point(49, 18);
            this.btnN.Name = "btnN";
            this.btnN.Size = new System.Drawing.Size(40, 40);
            this.btnN.TabIndex = 12;
            this.btnN.Text = "N";
            this.btnN.UseVisualStyleBackColor = true;
            this.btnN.Click += new System.EventHandler(this.buttonN_Click);
            // 
            // btnE
            // 
            this.btnE.Location = new System.Drawing.Point(89, 58);
            this.btnE.Name = "btnE";
            this.btnE.Size = new System.Drawing.Size(40, 40);
            this.btnE.TabIndex = 13;
            this.btnE.Text = "E";
            this.btnE.UseVisualStyleBackColor = true;
            this.btnE.Click += new System.EventHandler(this.buttonE_Click);
            // 
            // btnW
            // 
            this.btnW.Location = new System.Drawing.Point(9, 58);
            this.btnW.Name = "btnW";
            this.btnW.Size = new System.Drawing.Size(40, 40);
            this.btnW.TabIndex = 14;
            this.btnW.Text = "W";
            this.btnW.UseVisualStyleBackColor = true;
            this.btnW.Click += new System.EventHandler(this.buttonW_Click);
            // 
            // btnS
            // 
            this.btnS.Location = new System.Drawing.Point(49, 98);
            this.btnS.Name = "btnS";
            this.btnS.Size = new System.Drawing.Size(40, 40);
            this.btnS.TabIndex = 15;
            this.btnS.Text = "S";
            this.btnS.UseVisualStyleBackColor = true;
            this.btnS.Click += new System.EventHandler(this.buttonS_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cBTarget);
            this.groupBox1.Controls.Add(this.btnRand);
            this.groupBox1.Controls.Add(this.btnN);
            this.groupBox1.Controls.Add(this.btnS);
            this.groupBox1.Controls.Add(this.btnAll);
            this.groupBox1.Controls.Add(this.btnW);
            this.groupBox1.Controls.Add(this.btnE);
            this.groupBox1.Location = new System.Drawing.Point(213, 452);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(187, 175);
            this.groupBox1.TabIndex = 16;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Manual Spawn";
            // 
            // cBTarget
            // 
            this.cBTarget.AutoSize = true;
            this.cBTarget.Checked = true;
            this.cBTarget.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cBTarget.Location = new System.Drawing.Point(9, 152);
            this.cBTarget.Name = "cBTarget";
            this.cBTarget.Size = new System.Drawing.Size(96, 17);
            this.cBTarget.TabIndex = 12;
            this.cBTarget.Text = "Random target";
            this.cBTarget.UseVisualStyleBackColor = true;
            this.cBTarget.CheckedChanged += new System.EventHandler(this.checkBox3_CheckedChanged);
            // 
            // btnRand
            // 
            this.btnRand.Location = new System.Drawing.Point(89, 98);
            this.btnRand.Margin = new System.Windows.Forms.Padding(2);
            this.btnRand.Name = "btnRand";
            this.btnRand.Size = new System.Drawing.Size(82, 40);
            this.btnRand.TabIndex = 16;
            this.btnRand.Text = "Rand";
            this.btnRand.UseVisualStyleBackColor = true;
            this.btnRand.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.cBShowZones);
            this.groupBox2.Controls.Add(this.nudZoom);
            this.groupBox2.Controls.Add(this.cBZoom);
            this.groupBox2.Controls.Add(this.cBRun);
            this.groupBox2.Controls.Add(this.cBShowGhost);
            this.groupBox2.Location = new System.Drawing.Point(14, 451);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(194, 91);
            this.groupBox2.TabIndex = 17;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Simulation";
            // 
            // cBShowZones
            // 
            this.cBShowZones.AutoSize = true;
            this.cBShowZones.Location = new System.Drawing.Point(6, 42);
            this.cBShowZones.Name = "cBShowZones";
            this.cBShowZones.Size = new System.Drawing.Size(84, 17);
            this.cBShowZones.TabIndex = 22;
            this.cBShowZones.Text = "Show zones";
            this.cBShowZones.UseVisualStyleBackColor = true;
            this.cBShowZones.CheckedChanged += new System.EventHandler(this.checkBox4_CheckedChanged);
            // 
            // nudZoom
            // 
            this.nudZoom.Location = new System.Drawing.Point(117, 18);
            this.nudZoom.Name = "nudZoom";
            this.nudZoom.Size = new System.Drawing.Size(38, 20);
            this.nudZoom.TabIndex = 21;
            this.nudZoom.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.nudZoom.ValueChanged += new System.EventHandler(this.numericUpDown1_ValueChanged_1);
            // 
            // cBZoom
            // 
            this.cBZoom.AutoSize = true;
            this.cBZoom.Location = new System.Drawing.Point(58, 19);
            this.cBZoom.Name = "cBZoom";
            this.cBZoom.Size = new System.Drawing.Size(53, 17);
            this.cBZoom.TabIndex = 20;
            this.cBZoom.Text = "Zoom";
            this.cBZoom.UseVisualStyleBackColor = true;
            this.cBZoom.CheckedChanged += new System.EventHandler(this.checkBox3_CheckedChanged_1);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.nudDelayAIM);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Controls.Add(this.nudSpawnSpeed);
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Controls.Add(this.nudSpeedLimit);
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Controls.Add(this.nudDistMargin);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Location = new System.Drawing.Point(14, 548);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(194, 209);
            this.groupBox3.TabIndex = 18;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "AIM parameters";
            // 
            // nudDelayAIM
            // 
            this.nudDelayAIM.DecimalPlaces = 1;
            this.nudDelayAIM.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.nudDelayAIM.Location = new System.Drawing.Point(8, 164);
            this.nudDelayAIM.Name = "nudDelayAIM";
            this.nudDelayAIM.Size = new System.Drawing.Size(120, 20);
            this.nudDelayAIM.TabIndex = 17;
            this.nudDelayAIM.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudDelayAIM.ValueChanged += new System.EventHandler(this.numericUpDownDelayAIM_ValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 148);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(93, 13);
            this.label2.TabIndex = 18;
            this.label2.Text = "Controller delay [s]";
            // 
            // nudSpawnSpeed
            // 
            this.nudSpawnSpeed.DecimalPlaces = 1;
            this.nudSpawnSpeed.Location = new System.Drawing.Point(8, 122);
            this.nudSpawnSpeed.Name = "nudSpawnSpeed";
            this.nudSpawnSpeed.Size = new System.Drawing.Size(120, 20);
            this.nudSpawnSpeed.TabIndex = 15;
            this.nudSpawnSpeed.Value = new decimal(new int[] {
            30,
            0,
            0,
            0});
            this.nudSpawnSpeed.ValueChanged += new System.EventHandler(this.numericUpDown3_ValueChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(8, 106);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(99, 13);
            this.label7.TabIndex = 16;
            this.label7.Text = "Spawn speed [m/s]";
            // 
            // nudSpeedLimit
            // 
            this.nudSpeedLimit.DecimalPlaces = 1;
            this.nudSpeedLimit.Location = new System.Drawing.Point(8, 80);
            this.nudSpeedLimit.Name = "nudSpeedLimit";
            this.nudSpeedLimit.Size = new System.Drawing.Size(120, 20);
            this.nudSpeedLimit.TabIndex = 13;
            this.nudSpeedLimit.Value = new decimal(new int[] {
            30,
            0,
            0,
            0});
            this.nudSpeedLimit.ValueChanged += new System.EventHandler(this.numericUpDown2_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 64);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(85, 13);
            this.label1.TabIndex = 14;
            this.label1.Text = "Speed limit [m/s]";
            // 
            // nudDistMargin
            // 
            this.nudDistMargin.DecimalPlaces = 1;
            this.nudDistMargin.Location = new System.Drawing.Point(8, 37);
            this.nudDistMargin.Name = "nudDistMargin";
            this.nudDistMargin.Size = new System.Drawing.Size(120, 20);
            this.nudDistMargin.TabIndex = 11;
            this.nudDistMargin.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.nudDistMargin.ValueChanged += new System.EventHandler(this.numericUpDownDistMargin_ValueChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(5, 21);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(100, 13);
            this.label5.TabIndex = 12;
            this.label5.Text = "Distance margin [m]";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(293, 3);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(94, 13);
            this.label6.TabIndex = 20;
            this.label6.Text = "Simulation time [s]:";
            // 
            // tBApproachingVehicles
            // 
            this.tBApproachingVehicles.BackColor = System.Drawing.Color.White;
            this.tBApproachingVehicles.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tBApproachingVehicles.Location = new System.Drawing.Point(9, 21);
            this.tBApproachingVehicles.Multiline = true;
            this.tBApproachingVehicles.Name = "tBApproachingVehicles";
            this.tBApproachingVehicles.ReadOnly = true;
            this.tBApproachingVehicles.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tBApproachingVehicles.Size = new System.Drawing.Size(391, 425);
            this.tBApproachingVehicles.TabIndex = 23;
            // 
            // timer_print
            // 
            this.timer_print.Tick += new System.EventHandler(this.timer_print_Tick);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(200, 3);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(68, 13);
            this.label8.TabIndex = 24;
            this.label8.Text = "Real time [s]:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(8, 19);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(91, 13);
            this.label9.TabIndex = 17;
            this.label9.Text = "Spawn interval [s]";
            // 
            // btnStartTest
            // 
            this.btnStartTest.Location = new System.Drawing.Point(106, 72);
            this.btnStartTest.Name = "btnStartTest";
            this.btnStartTest.Size = new System.Drawing.Size(75, 50);
            this.btnStartTest.TabIndex = 25;
            this.btnStartTest.Text = "Start Test";
            this.btnStartTest.UseVisualStyleBackColor = true;
            this.btnStartTest.Click += new System.EventHandler(this.button2_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(7, 58);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(83, 13);
            this.label10.TabIndex = 26;
            this.label10.Text = "Test duration [s]";
            // 
            // nudDelay
            // 
            this.nudDelay.DecimalPlaces = 1;
            this.nudDelay.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.nudDelay.Location = new System.Drawing.Point(11, 35);
            this.nudDelay.Name = "nudDelay";
            this.nudDelay.Size = new System.Drawing.Size(63, 20);
            this.nudDelay.TabIndex = 17;
            this.nudDelay.Value = new decimal(new int[] {
            5,
            0,
            0,
            65536});
            // 
            // nudTestLength
            // 
            this.nudTestLength.DecimalPlaces = 1;
            this.nudTestLength.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.nudTestLength.Location = new System.Drawing.Point(11, 74);
            this.nudTestLength.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.nudTestLength.Name = "nudTestLength";
            this.nudTestLength.Size = new System.Drawing.Size(63, 20);
            this.nudTestLength.TabIndex = 27;
            this.nudTestLength.Value = new decimal(new int[] {
            60,
            0,
            0,
            0});
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.labelDuration);
            this.groupBox4.Controls.Add(this.nudTestLength);
            this.groupBox4.Controls.Add(this.label9);
            this.groupBox4.Controls.Add(this.nudDelay);
            this.groupBox4.Controls.Add(this.btnStartTest);
            this.groupBox4.Controls.Add(this.label10);
            this.groupBox4.Location = new System.Drawing.Point(213, 629);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(187, 128);
            this.groupBox4.TabIndex = 28;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Traffic Test";
            // 
            // labelDuration
            // 
            this.labelDuration.AutoSize = true;
            this.labelDuration.Location = new System.Drawing.Point(11, 103);
            this.labelDuration.Name = "labelDuration";
            this.labelDuration.Size = new System.Drawing.Size(67, 13);
            this.labelDuration.TabIndex = 28;
            this.labelDuration.Text = "Duration: 0 s";
            // 
            // pbProjection
            // 
            this.pbProjection.BackColor = System.Drawing.Color.White;
            this.pbProjection.Location = new System.Drawing.Point(1219, 3);
            this.pbProjection.Name = "pbProjection";
            this.pbProjection.Size = new System.Drawing.Size(400, 500);
            this.pbProjection.TabIndex = 30;
            this.pbProjection.TabStop = false;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(1258, 506);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(33, 13);
            this.label12.TabIndex = 31;
            this.label12.Text = "350m";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(1607, 506);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(21, 13);
            this.label13.TabIndex = 32;
            this.label13.Text = "0m";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(1625, 490);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(18, 13);
            this.label14.TabIndex = 33;
            this.label14.Text = "0s";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(1625, 3);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(24, 13);
            this.label15.TabIndex = 34;
            this.label15.Text = "20s";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(1625, 246);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(24, 13);
            this.label16.TabIndex = 35;
            this.label16.Text = "10s";
            // 
            // cbTrafficLights
            // 
            this.cbTrafficLights.AutoSize = true;
            this.cbTrafficLights.Location = new System.Drawing.Point(1237, 550);
            this.cbTrafficLights.Name = "cbTrafficLights";
            this.cbTrafficLights.Size = new System.Drawing.Size(87, 17);
            this.cbTrafficLights.TabIndex = 36;
            this.cbTrafficLights.Text = "Traffic Lights";
            this.cbTrafficLights.UseVisualStyleBackColor = true;
            this.cbTrafficLights.CheckedChanged += new System.EventHandler(this.cbTrafficLights_CheckedChanged);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1796, 24);
            this.menuStrip1.TabIndex = 37;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.Color.White;
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox1.Location = new System.Drawing.Point(1220, 629);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox1.Size = new System.Drawing.Size(413, 220);
            this.textBox1.TabIndex = 38;
            // 
            // timerSignal
            // 
            this.timerSignal.Enabled = true;
            this.timerSignal.Interval = 30000;
            this.timerSignal.Tick += new System.EventHandler(this.timerSignal_Tick);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(1258, 577);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(64, 13);
            this.label4.TabIndex = 39;
            this.label4.Text = "Green light: ";
            // 
            // timerYellow
            // 
            this.timerYellow.Interval = 5000;
            this.timerYellow.Tick += new System.EventHandler(this.timerYellow_Tick);
            // 
            // MainFrame
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1796, 928);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.cbTrafficLights);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.pbProjection);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.tBApproachingVehicles);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.pbSimulation);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "MainFrame";
            this.Text = "Intersection Simulator";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.MainFrame_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbSimulation)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudZoom)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudDelayAIM)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudSpawnSpeed)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudSpeedLimit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudDistMargin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudDelay)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudTestLength)).EndInit();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbProjection)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnAll;
        private System.Windows.Forms.PictureBox pbSimulation;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox cBRun;
        private System.Windows.Forms.CheckBox cBShowGhost;
        private System.Windows.Forms.Button btnN;
        private System.Windows.Forms.Button btnE;
        private System.Windows.Forms.Button btnW;
        private System.Windows.Forms.Button btnS;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btnRand;
        private System.Windows.Forms.CheckBox cBTarget;
        private System.Windows.Forms.CheckBox cBZoom;
        private System.Windows.Forms.NumericUpDown nudDistMargin;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox tBApproachingVehicles;
        private System.Windows.Forms.NumericUpDown nudZoom;
        private System.Windows.Forms.NumericUpDown nudSpeedLimit;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown nudSpawnSpeed;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.CheckBox cBShowZones;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button btnStartTest;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.NumericUpDown nudDelay;
        private System.Windows.Forms.NumericUpDown nudTestLength;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label labelDuration;
        private System.Windows.Forms.PictureBox pbProjection;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.NumericUpDown nudDelayAIM;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Timer timer_simulation;
        private System.Windows.Forms.Timer timer_print;
        private System.Windows.Forms.CheckBox cbTrafficLights;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Timer timerSignal;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Timer timerYellow;
    }
}


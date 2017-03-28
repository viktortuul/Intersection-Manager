namespace car_simulation
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
            this.buttonM = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.timer_simulation = new System.Windows.Forms.Timer(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.numericUpDown_margin = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.buttonN = new System.Windows.Forms.Button();
            this.buttonE = new System.Windows.Forms.Button();
            this.buttonW = new System.Windows.Forms.Button();
            this.buttonS = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.checkBoxTarget = new System.Windows.Forms.CheckBox();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.checkBox3 = new System.Windows.Forms.CheckBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.numericUpDown3 = new System.Windows.Forms.NumericUpDown();
            this.label7 = new System.Windows.Forms.Label();
            this.numericUpDown2 = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.numericUpDownDistMargin = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.timer_print = new System.Windows.Forms.Timer(this.components);
            this.checkBox4 = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_margin)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownDistMargin)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonM
            // 
            this.buttonM.Location = new System.Drawing.Point(69, 72);
            this.buttonM.Margin = new System.Windows.Forms.Padding(2);
            this.buttonM.Name = "buttonM";
            this.buttonM.Size = new System.Drawing.Size(50, 25);
            this.buttonM.TabIndex = 0;
            this.buttonM.Text = "Alla";
            this.buttonM.UseVisualStyleBackColor = true;
            this.buttonM.Click += new System.EventHandler(this.button1_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.White;
            this.pictureBox1.Location = new System.Drawing.Point(406, 3);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(805, 805);
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // timer_simulation
            // 
            this.timer_simulation.Interval = 10;
            this.timer_simulation.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(11, 4);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(89, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Alla aktiva fordon";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(11, 180);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(246, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Fordon på väg mot korsning (sorterad efter distans)";
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Checked = true;
            this.checkBox1.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox1.Location = new System.Drawing.Point(6, 19);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(151, 17);
            this.checkBox1.TabIndex = 8;
            this.checkBox1.Text = "Kör simulering (Kör/Pause)";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // numericUpDown_margin
            // 
            this.numericUpDown_margin.DecimalPlaces = 1;
            this.numericUpDown_margin.Increment = new decimal(new int[] {
            5,
            0,
            0,
            65536});
            this.numericUpDown_margin.Location = new System.Drawing.Point(6, 34);
            this.numericUpDown_margin.Name = "numericUpDown_margin";
            this.numericUpDown_margin.Size = new System.Drawing.Size(120, 20);
            this.numericUpDown_margin.TabIndex = 9;
            this.numericUpDown_margin.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.numericUpDown_margin.ValueChanged += new System.EventHandler(this.numericUpDown1_ValueChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 18);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(146, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "Tidsmarginal mellan fordon [s]";
            // 
            // checkBox2
            // 
            this.checkBox2.AutoSize = true;
            this.checkBox2.Location = new System.Drawing.Point(6, 42);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(94, 17);
            this.checkBox2.TabIndex = 11;
            this.checkBox2.Text = "Visa spök-bilar";
            this.checkBox2.UseVisualStyleBackColor = true;
            this.checkBox2.CheckedChanged += new System.EventHandler(this.checkBox2_CheckedChanged);
            // 
            // buttonN
            // 
            this.buttonN.Location = new System.Drawing.Point(69, 19);
            this.buttonN.Name = "buttonN";
            this.buttonN.Size = new System.Drawing.Size(50, 50);
            this.buttonN.TabIndex = 12;
            this.buttonN.Text = "Norr";
            this.buttonN.UseVisualStyleBackColor = true;
            this.buttonN.Click += new System.EventHandler(this.buttonN_Click);
            // 
            // buttonE
            // 
            this.buttonE.Location = new System.Drawing.Point(124, 72);
            this.buttonE.Name = "buttonE";
            this.buttonE.Size = new System.Drawing.Size(50, 50);
            this.buttonE.TabIndex = 13;
            this.buttonE.Text = "Öst";
            this.buttonE.UseVisualStyleBackColor = true;
            this.buttonE.Click += new System.EventHandler(this.buttonE_Click);
            // 
            // buttonW
            // 
            this.buttonW.Location = new System.Drawing.Point(14, 72);
            this.buttonW.Name = "buttonW";
            this.buttonW.Size = new System.Drawing.Size(50, 50);
            this.buttonW.TabIndex = 14;
            this.buttonW.Text = "Väst";
            this.buttonW.UseVisualStyleBackColor = true;
            this.buttonW.Click += new System.EventHandler(this.buttonW_Click);
            // 
            // buttonS
            // 
            this.buttonS.Location = new System.Drawing.Point(69, 127);
            this.buttonS.Name = "buttonS";
            this.buttonS.Size = new System.Drawing.Size(50, 50);
            this.buttonS.TabIndex = 15;
            this.buttonS.Text = "Söder";
            this.buttonS.UseVisualStyleBackColor = true;
            this.buttonS.Click += new System.EventHandler(this.buttonS_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.checkBoxTarget);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.buttonN);
            this.groupBox1.Controls.Add(this.buttonS);
            this.groupBox1.Controls.Add(this.buttonM);
            this.groupBox1.Controls.Add(this.buttonW);
            this.groupBox1.Controls.Add(this.buttonE);
            this.groupBox1.Location = new System.Drawing.Point(213, 394);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(187, 220);
            this.groupBox1.TabIndex = 16;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Lägg till fordon";
            // 
            // checkBoxTarget
            // 
            this.checkBoxTarget.AutoSize = true;
            this.checkBoxTarget.Checked = true;
            this.checkBoxTarget.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxTarget.Location = new System.Drawing.Point(6, 183);
            this.checkBoxTarget.Name = "checkBoxTarget";
            this.checkBoxTarget.Size = new System.Drawing.Size(165, 17);
            this.checkBoxTarget.TabIndex = 12;
            this.checkBoxTarget.Text = "Slumpa mål (annars rakt fram)";
            this.checkBoxTarget.UseVisualStyleBackColor = true;
            this.checkBoxTarget.CheckedChanged += new System.EventHandler(this.checkBox3_CheckedChanged);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(69, 97);
            this.button1.Margin = new System.Windows.Forms.Padding(2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(50, 25);
            this.button1.TabIndex = 16;
            this.button1.Text = "Slump";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.checkBox4);
            this.groupBox2.Controls.Add(this.numericUpDown1);
            this.groupBox2.Controls.Add(this.checkBox3);
            this.groupBox2.Controls.Add(this.checkBox1);
            this.groupBox2.Controls.Add(this.checkBox2);
            this.groupBox2.Location = new System.Drawing.Point(14, 393);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(194, 91);
            this.groupBox2.TabIndex = 17;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Simulering";
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Location = new System.Drawing.Point(55, 64);
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(45, 20);
            this.numericUpDown1.TabIndex = 21;
            this.numericUpDown1.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numericUpDown1.ValueChanged += new System.EventHandler(this.numericUpDown1_ValueChanged_1);
            // 
            // checkBox3
            // 
            this.checkBox3.AutoSize = true;
            this.checkBox3.Location = new System.Drawing.Point(6, 65);
            this.checkBox3.Name = "checkBox3";
            this.checkBox3.Size = new System.Drawing.Size(56, 17);
            this.checkBox3.TabIndex = 20;
            this.checkBox3.Text = "Zoom:";
            this.checkBox3.UseVisualStyleBackColor = true;
            this.checkBox3.CheckedChanged += new System.EventHandler(this.checkBox3_CheckedChanged_1);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.numericUpDown3);
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Controls.Add(this.numericUpDown2);
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Controls.Add(this.numericUpDownDistMargin);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.numericUpDown_margin);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Location = new System.Drawing.Point(14, 490);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(194, 188);
            this.groupBox3.TabIndex = 18;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Parametrar för kontrollalgorim";
            // 
            // numericUpDown3
            // 
            this.numericUpDown3.DecimalPlaces = 1;
            this.numericUpDown3.Location = new System.Drawing.Point(8, 164);
            this.numericUpDown3.Name = "numericUpDown3";
            this.numericUpDown3.Size = new System.Drawing.Size(120, 20);
            this.numericUpDown3.TabIndex = 15;
            this.numericUpDown3.Value = new decimal(new int[] {
            15,
            0,
            0,
            0});
            this.numericUpDown3.ValueChanged += new System.EventHandler(this.numericUpDown3_ValueChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(5, 148);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(85, 13);
            this.label7.TabIndex = 16;
            this.label7.Text = "Spawn fart [m/s]";
            // 
            // numericUpDown2
            // 
            this.numericUpDown2.DecimalPlaces = 1;
            this.numericUpDown2.Location = new System.Drawing.Point(8, 119);
            this.numericUpDown2.Name = "numericUpDown2";
            this.numericUpDown2.Size = new System.Drawing.Size(120, 20);
            this.numericUpDown2.TabIndex = 13;
            this.numericUpDown2.Value = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.numericUpDown2.ValueChanged += new System.EventHandler(this.numericUpDown2_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(5, 103);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 13);
            this.label1.TabIndex = 14;
            this.label1.Text = "Fartgräns [m/s]";
            // 
            // numericUpDownDistMargin
            // 
            this.numericUpDownDistMargin.DecimalPlaces = 1;
            this.numericUpDownDistMargin.Location = new System.Drawing.Point(8, 74);
            this.numericUpDownDistMargin.Name = "numericUpDownDistMargin";
            this.numericUpDownDistMargin.Size = new System.Drawing.Size(120, 20);
            this.numericUpDownDistMargin.TabIndex = 11;
            this.numericUpDownDistMargin.Value = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.numericUpDownDistMargin.ValueChanged += new System.EventHandler(this.numericUpDownDistMargin_ValueChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(5, 58);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(164, 13);
            this.label5.TabIndex = 12;
            this.label5.Text = "Distansmarginal mellan fordon [m]";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(316, 3);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(47, 13);
            this.label6.TabIndex = 20;
            this.label6.Text = "Time [s]:";
            this.label6.Click += new System.EventHandler(this.label6_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(9, 20);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox1.Size = new System.Drawing.Size(392, 155);
            this.textBox1.TabIndex = 22;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(9, 196);
            this.textBox2.Multiline = true;
            this.textBox2.Name = "textBox2";
            this.textBox2.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox2.Size = new System.Drawing.Size(392, 192);
            this.textBox2.TabIndex = 23;
            this.textBox2.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            // 
            // timer_print
            // 
            this.timer_print.Tick += new System.EventHandler(this.timer_print_Tick);
            // 
            // checkBox4
            // 
            this.checkBox4.AutoSize = true;
            this.checkBox4.Location = new System.Drawing.Point(107, 42);
            this.checkBox4.Name = "checkBox4";
            this.checkBox4.Size = new System.Drawing.Size(75, 17);
            this.checkBox4.TabIndex = 22;
            this.checkBox4.Text = "Visa zoner";
            this.checkBox4.UseVisualStyleBackColor = true;
            this.checkBox4.CheckedChanged += new System.EventHandler(this.checkBox4_CheckedChanged);
            // 
            // MainFrame
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1077, 709);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.pictureBox1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "MainFrame";
            this.Text = "Intersection Simulator";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_margin)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownDistMargin)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonM;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Timer timer_simulation;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.NumericUpDown numericUpDown_margin;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox checkBox2;
        private System.Windows.Forms.Button buttonN;
        private System.Windows.Forms.Button buttonE;
        private System.Windows.Forms.Button buttonW;
        private System.Windows.Forms.Button buttonS;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.CheckBox checkBoxTarget;
        private System.Windows.Forms.CheckBox checkBox3;
        private System.Windows.Forms.NumericUpDown numericUpDownDistMargin;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.NumericUpDown numericUpDown2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown numericUpDown3;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Timer timer_print;
        private System.Windows.Forms.CheckBox checkBox4;
    }
}


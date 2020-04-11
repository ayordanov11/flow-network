namespace FlowNetworkNew
{
    partial class Form1
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
            this.lblCurrentFlow = new System.Windows.Forms.Label();
            this.Flow = new System.Windows.Forms.Label();
            this.Limit = new System.Windows.Forms.Label();
            this.nudSafetyLimit = new System.Windows.Forms.NumericUpDown();
            this.nudMaxFlow = new System.Windows.Forms.NumericUpDown();
            this.trbrCurrentFlow = new System.Windows.Forms.TrackBar();
            this.lblFuelPercentage = new System.Windows.Forms.Label();
            this.btnNewProject = new System.Windows.Forms.Button();
            this.btnLoad = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnRemove = new System.Windows.Forms.Button();
            this.btnSelect = new System.Windows.Forms.Button();
            this.pipeline_pictureBox = new System.Windows.Forms.PictureBox();
            this.MergerPictureBox = new System.Windows.Forms.PictureBox();
            this.Pump_pictureBox = new System.Windows.Forms.PictureBox();
            this.SinkPictureBox = new System.Windows.Forms.PictureBox();
            this.SplitterPictureBox = new System.Windows.Forms.PictureBox();
            this.AdjSplitterPictureBox = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.nudFuel = new System.Windows.Forms.NumericUpDown();
            this.panelPump = new System.Windows.Forms.Panel();
            this.panelSink = new System.Windows.Forms.Panel();
            this.panelMerger = new System.Windows.Forms.Panel();
            this.panelPipe = new System.Windows.Forms.Panel();
            this.panelAdjSplitter = new System.Windows.Forms.Panel();
            this.panelSplitter = new System.Windows.Forms.Panel();
            this.btnCancel = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.nudSafetyLimit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMaxFlow)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trbrCurrentFlow)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pipeline_pictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MergerPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Pump_pictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SinkPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SplitterPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AdjSplitterPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudFuel)).BeginInit();
            this.panelPump.SuspendLayout();
            this.panelSink.SuspendLayout();
            this.panelMerger.SuspendLayout();
            this.panelPipe.SuspendLayout();
            this.panelAdjSplitter.SuspendLayout();
            this.panelSplitter.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblCurrentFlow
            // 
            this.lblCurrentFlow.AutoSize = true;
            this.lblCurrentFlow.Location = new System.Drawing.Point(129, 369);
            this.lblCurrentFlow.Name = "lblCurrentFlow";
            this.lblCurrentFlow.Size = new System.Drawing.Size(66, 13);
            this.lblCurrentFlow.TabIndex = 41;
            this.lblCurrentFlow.Text = "Current Flow";
            // 
            // Flow
            // 
            this.Flow.AutoSize = true;
            this.Flow.Location = new System.Drawing.Point(265, 369);
            this.Flow.Name = "Flow";
            this.Flow.Size = new System.Drawing.Size(52, 13);
            this.Flow.TabIndex = 40;
            this.Flow.Text = "Max Flow";
            // 
            // Limit
            // 
            this.Limit.AutoSize = true;
            this.Limit.Location = new System.Drawing.Point(75, 318);
            this.Limit.Name = "Limit";
            this.Limit.Size = new System.Drawing.Size(98, 13);
            this.Limit.TabIndex = 39;
            this.Limit.Text = "Pipeline safety limit:";
            // 
            // nudSafetyLimit
            // 
            this.nudSafetyLimit.Enabled = false;
            this.nudSafetyLimit.Location = new System.Drawing.Point(217, 316);
            this.nudSafetyLimit.Name = "nudSafetyLimit";
            this.nudSafetyLimit.Size = new System.Drawing.Size(100, 20);
            this.nudSafetyLimit.TabIndex = 38;
            this.nudSafetyLimit.Value = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.nudSafetyLimit.ValueChanged += new System.EventHandler(this.nudSafetyLimit_ValueChanged);
            // 
            // nudMaxFlow
            // 
            this.nudMaxFlow.Location = new System.Drawing.Point(217, 388);
            this.nudMaxFlow.Name = "nudMaxFlow";
            this.nudMaxFlow.Size = new System.Drawing.Size(100, 20);
            this.nudMaxFlow.TabIndex = 37;
            this.nudMaxFlow.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.nudMaxFlow.ValueChanged += new System.EventHandler(this.nudMaxFlow_ValueChanged);
            // 
            // trbrCurrentFlow
            // 
            this.trbrCurrentFlow.Location = new System.Drawing.Point(33, 388);
            this.trbrCurrentFlow.Name = "trbrCurrentFlow";
            this.trbrCurrentFlow.Size = new System.Drawing.Size(162, 45);
            this.trbrCurrentFlow.TabIndex = 36;
            this.trbrCurrentFlow.Value = 10;
            this.trbrCurrentFlow.Scroll += new System.EventHandler(this.trbrCurrentFlow_Scroll);
            // 
            // lblFuelPercentage
            // 
            this.lblFuelPercentage.AutoSize = true;
            this.lblFuelPercentage.Location = new System.Drawing.Point(129, 273);
            this.lblFuelPercentage.Name = "lblFuelPercentage";
            this.lblFuelPercentage.Size = new System.Drawing.Size(44, 13);
            this.lblFuelPercentage.TabIndex = 34;
            this.lblFuelPercentage.Text = "Fuel % :";
            // 
            // btnNewProject
            // 
            this.btnNewProject.Location = new System.Drawing.Point(242, 446);
            this.btnNewProject.Name = "btnNewProject";
            this.btnNewProject.Size = new System.Drawing.Size(75, 40);
            this.btnNewProject.TabIndex = 32;
            this.btnNewProject.Text = "New Project";
            this.btnNewProject.UseVisualStyleBackColor = true;
            this.btnNewProject.Click += new System.EventHandler(this.btnNewProject_Click);
            // 
            // btnLoad
            // 
            this.btnLoad.Location = new System.Drawing.Point(132, 446);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(75, 40);
            this.btnLoad.TabIndex = 31;
            this.btnLoad.Text = "Load";
            this.btnLoad.UseVisualStyleBackColor = true;
            this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(33, 446);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 40);
            this.btnSave.TabIndex = 30;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnRemove
            // 
            this.btnRemove.BackColor = System.Drawing.Color.Red;
            this.btnRemove.Location = new System.Drawing.Point(227, 97);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(75, 60);
            this.btnRemove.TabIndex = 29;
            this.btnRemove.Text = "Remove";
            this.btnRemove.UseVisualStyleBackColor = false;
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            // 
            // btnSelect
            // 
            this.btnSelect.BackColor = System.Drawing.Color.Lime;
            this.btnSelect.Location = new System.Drawing.Point(227, 31);
            this.btnSelect.Name = "btnSelect";
            this.btnSelect.Size = new System.Drawing.Size(75, 60);
            this.btnSelect.TabIndex = 42;
            this.btnSelect.Text = "Select";
            this.btnSelect.UseVisualStyleBackColor = false;
            this.btnSelect.Click += new System.EventHandler(this.btnSelect_Click);
            // 
            // pipeline_pictureBox
            // 
            this.pipeline_pictureBox.BackColor = System.Drawing.SystemColors.Control;
            this.pipeline_pictureBox.Image = global::FlowNetworkNew.Properties.Resources.Pipeline;
            this.pipeline_pictureBox.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.pipeline_pictureBox.Location = new System.Drawing.Point(5, 5);
            this.pipeline_pictureBox.Name = "pipeline_pictureBox";
            this.pipeline_pictureBox.Size = new System.Drawing.Size(48, 50);
            this.pipeline_pictureBox.TabIndex = 56;
            this.pipeline_pictureBox.TabStop = false;
            this.pipeline_pictureBox.Click += new System.EventHandler(this.pipeline_Click);
            // 
            // MergerPictureBox
            // 
            this.MergerPictureBox.BackColor = System.Drawing.SystemColors.Control;
            this.MergerPictureBox.Image = global::FlowNetworkNew.Properties.Resources.MergerPictureBox_Image;
            this.MergerPictureBox.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.MergerPictureBox.Location = new System.Drawing.Point(5, 5);
            this.MergerPictureBox.Name = "MergerPictureBox";
            this.MergerPictureBox.Size = new System.Drawing.Size(48, 50);
            this.MergerPictureBox.TabIndex = 50;
            this.MergerPictureBox.TabStop = false;
            this.MergerPictureBox.Click += new System.EventHandler(this.MergerPictureBox_Click);
            // 
            // Pump_pictureBox
            // 
            this.Pump_pictureBox.BackColor = System.Drawing.SystemColors.Control;
            this.Pump_pictureBox.Image = global::FlowNetworkNew.Properties.Resources.Pump_pictureBox_Image;
            this.Pump_pictureBox.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.Pump_pictureBox.Location = new System.Drawing.Point(5, 5);
            this.Pump_pictureBox.Name = "Pump_pictureBox";
            this.Pump_pictureBox.Size = new System.Drawing.Size(48, 50);
            this.Pump_pictureBox.TabIndex = 48;
            this.Pump_pictureBox.TabStop = false;
            this.Pump_pictureBox.Click += new System.EventHandler(this.Pump_pictureBox_Click);
            // 
            // SinkPictureBox
            // 
            this.SinkPictureBox.BackColor = System.Drawing.SystemColors.Control;
            this.SinkPictureBox.Image = global::FlowNetworkNew.Properties.Resources.SinkPictureBox_Image;
            this.SinkPictureBox.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.SinkPictureBox.Location = new System.Drawing.Point(5, 5);
            this.SinkPictureBox.Name = "SinkPictureBox";
            this.SinkPictureBox.Size = new System.Drawing.Size(48, 50);
            this.SinkPictureBox.TabIndex = 49;
            this.SinkPictureBox.TabStop = false;
            this.SinkPictureBox.Click += new System.EventHandler(this.SinkPictureBox_Click);
            // 
            // SplitterPictureBox
            // 
            this.SplitterPictureBox.BackColor = System.Drawing.SystemColors.Control;
            this.SplitterPictureBox.Image = global::FlowNetworkNew.Properties.Resources.SplitterPictureBox_Image;
            this.SplitterPictureBox.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.SplitterPictureBox.Location = new System.Drawing.Point(5, 5);
            this.SplitterPictureBox.Name = "SplitterPictureBox";
            this.SplitterPictureBox.Size = new System.Drawing.Size(48, 50);
            this.SplitterPictureBox.TabIndex = 51;
            this.SplitterPictureBox.TabStop = false;
            this.SplitterPictureBox.Click += new System.EventHandler(this.SplitterPictureBox_Click);
            // 
            // AdjSplitterPictureBox
            // 
            this.AdjSplitterPictureBox.BackColor = System.Drawing.SystemColors.Control;
            this.AdjSplitterPictureBox.Image = global::FlowNetworkNew.Properties.Resources.AdjSplitterPictureBox_Image;
            this.AdjSplitterPictureBox.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.AdjSplitterPictureBox.Location = new System.Drawing.Point(5, 5);
            this.AdjSplitterPictureBox.Name = "AdjSplitterPictureBox";
            this.AdjSplitterPictureBox.Size = new System.Drawing.Size(48, 50);
            this.AdjSplitterPictureBox.TabIndex = 52;
            this.AdjSplitterPictureBox.TabStop = false;
            this.AdjSplitterPictureBox.Click += new System.EventHandler(this.AdjSplitterPictureBox_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.pictureBox1.Location = new System.Drawing.Point(336, 31);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(520, 455);
            this.pictureBox1.TabIndex = 33;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBox1_Paint);
            this.pictureBox1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseClick);
            this.pictureBox1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseDown);
            // 
            // nudFuel
            // 
            this.nudFuel.Enabled = false;
            this.nudFuel.Location = new System.Drawing.Point(217, 271);
            this.nudFuel.Name = "nudFuel";
            this.nudFuel.Size = new System.Drawing.Size(100, 20);
            this.nudFuel.TabIndex = 57;
            this.nudFuel.Value = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.nudFuel.ValueChanged += new System.EventHandler(this.nudFuel_ValueChanged);
            // 
            // panelPump
            // 
            this.panelPump.BackColor = System.Drawing.SystemColors.Control;
            this.panelPump.Controls.Add(this.Pump_pictureBox);
            this.panelPump.Location = new System.Drawing.Point(34, 31);
            this.panelPump.Name = "panelPump";
            this.panelPump.Size = new System.Drawing.Size(60, 60);
            this.panelPump.TabIndex = 58;
            // 
            // panelSink
            // 
            this.panelSink.BackColor = System.Drawing.SystemColors.Control;
            this.panelSink.Controls.Add(this.SinkPictureBox);
            this.panelSink.Location = new System.Drawing.Point(34, 97);
            this.panelSink.Name = "panelSink";
            this.panelSink.Size = new System.Drawing.Size(60, 60);
            this.panelSink.TabIndex = 59;
            // 
            // panelMerger
            // 
            this.panelMerger.BackColor = System.Drawing.SystemColors.Control;
            this.panelMerger.Controls.Add(this.MergerPictureBox);
            this.panelMerger.Location = new System.Drawing.Point(34, 163);
            this.panelMerger.Name = "panelMerger";
            this.panelMerger.Size = new System.Drawing.Size(60, 60);
            this.panelMerger.TabIndex = 60;
            // 
            // panelPipe
            // 
            this.panelPipe.BackColor = System.Drawing.SystemColors.Control;
            this.panelPipe.Controls.Add(this.pipeline_pictureBox);
            this.panelPipe.Location = new System.Drawing.Point(120, 31);
            this.panelPipe.Name = "panelPipe";
            this.panelPipe.Size = new System.Drawing.Size(60, 60);
            this.panelPipe.TabIndex = 61;
            // 
            // panelAdjSplitter
            // 
            this.panelAdjSplitter.BackColor = System.Drawing.SystemColors.Control;
            this.panelAdjSplitter.Controls.Add(this.AdjSplitterPictureBox);
            this.panelAdjSplitter.Location = new System.Drawing.Point(120, 97);
            this.panelAdjSplitter.Name = "panelAdjSplitter";
            this.panelAdjSplitter.Size = new System.Drawing.Size(60, 60);
            this.panelAdjSplitter.TabIndex = 62;
            // 
            // panelSplitter
            // 
            this.panelSplitter.BackColor = System.Drawing.SystemColors.Control;
            this.panelSplitter.Controls.Add(this.SplitterPictureBox);
            this.panelSplitter.Location = new System.Drawing.Point(120, 163);
            this.panelSplitter.Name = "panelSplitter";
            this.panelSplitter.Size = new System.Drawing.Size(60, 60);
            this.panelSplitter.TabIndex = 62;
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnCancel.Location = new System.Drawing.Point(227, 163);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 60);
            this.btnCancel.TabIndex = 63;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(931, 516);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.panelAdjSplitter);
            this.Controls.Add(this.panelSplitter);
            this.Controls.Add(this.panelPipe);
            this.Controls.Add(this.panelMerger);
            this.Controls.Add(this.panelSink);
            this.Controls.Add(this.panelPump);
            this.Controls.Add(this.nudFuel);
            this.Controls.Add(this.btnSelect);
            this.Controls.Add(this.lblCurrentFlow);
            this.Controls.Add(this.Flow);
            this.Controls.Add(this.Limit);
            this.Controls.Add(this.nudSafetyLimit);
            this.Controls.Add(this.nudMaxFlow);
            this.Controls.Add(this.trbrCurrentFlow);
            this.Controls.Add(this.lblFuelPercentage);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.btnNewProject);
            this.Controls.Add(this.btnLoad);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnRemove);
            this.Name = "Form1";
            this.Text = "Flow Network";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.nudSafetyLimit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMaxFlow)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trbrCurrentFlow)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pipeline_pictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MergerPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Pump_pictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SinkPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SplitterPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.AdjSplitterPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudFuel)).EndInit();
            this.panelPump.ResumeLayout(false);
            this.panelSink.ResumeLayout(false);
            this.panelMerger.ResumeLayout(false);
            this.panelPipe.ResumeLayout(false);
            this.panelAdjSplitter.ResumeLayout(false);
            this.panelSplitter.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblCurrentFlow;
        private System.Windows.Forms.Label Flow;
        private System.Windows.Forms.Label Limit;
        private System.Windows.Forms.NumericUpDown nudSafetyLimit;
        private System.Windows.Forms.NumericUpDown nudMaxFlow;
        private System.Windows.Forms.TrackBar trbrCurrentFlow;
        private System.Windows.Forms.Label lblFuelPercentage;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnNewProject;
        private System.Windows.Forms.Button btnLoad;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnRemove;
        private System.Windows.Forms.Button btnSelect;
        private System.Windows.Forms.PictureBox MergerPictureBox;
        private System.Windows.Forms.PictureBox Pump_pictureBox;
        private System.Windows.Forms.PictureBox SinkPictureBox;
        private System.Windows.Forms.PictureBox SplitterPictureBox;
        private System.Windows.Forms.PictureBox AdjSplitterPictureBox;
        private System.Windows.Forms.PictureBox pipeline_pictureBox;
        private System.Windows.Forms.NumericUpDown nudFuel;
        private System.Windows.Forms.Panel panelPump;
        private System.Windows.Forms.Panel panelSink;
        private System.Windows.Forms.Panel panelMerger;
        private System.Windows.Forms.Panel panelPipe;
        private System.Windows.Forms.Panel panelAdjSplitter;
        private System.Windows.Forms.Panel panelSplitter;
        private System.Windows.Forms.Button btnCancel;
    }
}


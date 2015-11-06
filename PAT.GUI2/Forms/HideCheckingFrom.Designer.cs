namespace PAT.GUI.Forms
{
    partial class HideCheckingFrom
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HideCheckingFrom));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblRAM = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblCPU = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnBrowser = new System.Windows.Forms.Button();
            this.lblPath = new System.Windows.Forms.Label();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.mRAMCounter)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mCPUCounter)).BeginInit();
            this.GroupBox_Assertions.SuspendLayout();
            this.GroupBox_SelectedAssertion.SuspendLayout();
            this.GroupBox_Options.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.GroupBox_Output.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // ImageList
            // 
            this.ImageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ImageList.ImageStream")));
            this.ImageList.Images.SetKeyName(0, "True");
            this.ImageList.Images.SetKeyName(1, "False");
            this.ImageList.Images.SetKeyName(2, "Unknown");
            this.ImageList.Images.SetKeyName(3, "Prob True");
            // 
            // GroupBox_Assertions
            // 
            this.GroupBox_Assertions.Controls.Add(this.groupBox1);
            this.GroupBox_Assertions.Size = new System.Drawing.Size(808, 208);
            this.GroupBox_Assertions.Text = "";
            this.GroupBox_Assertions.Controls.SetChildIndex(this.ListView_Assertions, 0);
            this.GroupBox_Assertions.Controls.SetChildIndex(this.groupBox1, 0);
            // 
            // GroupBox_SelectedAssertion
            // 
            this.GroupBox_SelectedAssertion.Location = new System.Drawing.Point(0, 208);
            // 
            // Button_Verify
            // 
            this.Button_Verify.Location = new System.Drawing.Point(389, 43);
            // 
            // Button_BAGraph
            // 
            this.Button_BAGraph.Location = new System.Drawing.Point(509, 43);
            // 
            // Button_SimulateWitnessTrace
            // 
            this.Button_SimulateWitnessTrace.Location = new System.Drawing.Point(658, 43);
            // 
            // GroupBox_Options
            // 
            this.GroupBox_Options.Location = new System.Drawing.Point(0, 282);
            // 
            // splitContainer1
            // 
            // 
            // GroupBox_Output
            // 
            this.GroupBox_Output.Location = new System.Drawing.Point(0, 357);
            this.GroupBox_Output.Size = new System.Drawing.Size(808, 298);
            // 
            // TextBox_Output
            // 
            this.TextBox_Output.Size = new System.Drawing.Size(802, 277);
            // 
            // ListView_Assertions
            // 
            this.ListView_Assertions.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.ListView_Assertions.Location = new System.Drawing.Point(3, 71);
            this.ListView_Assertions.Size = new System.Drawing.Size(802, 134);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblRAM);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.lblCPU);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.btnBrowser);
            this.groupBox1.Controls.Add(this.lblPath);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(3, 18);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(802, 50);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "File information";
            // 
            // lblRAM
            // 
            this.lblRAM.AutoSize = true;
            this.lblRAM.BackColor = System.Drawing.SystemColors.Info;
            this.lblRAM.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRAM.ForeColor = System.Drawing.Color.Red;
            this.lblRAM.Location = new System.Drawing.Point(740, 15);
            this.lblRAM.Name = "lblRAM";
            this.lblRAM.Padding = new System.Windows.Forms.Padding(5);
            this.lblRAM.Size = new System.Drawing.Size(10, 27);
            this.lblRAM.TabIndex = 14;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(625, 20);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(100, 17);
            this.label4.TabIndex = 13;
            this.label4.Text = "RAM available:";
            // 
            // lblCPU
            // 
            this.lblCPU.AutoSize = true;
            this.lblCPU.BackColor = System.Drawing.SystemColors.Info;
            this.lblCPU.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCPU.ForeColor = System.Drawing.Color.Red;
            this.lblCPU.Location = new System.Drawing.Point(551, 15);
            this.lblCPU.Name = "lblCPU";
            this.lblCPU.Padding = new System.Windows.Forms.Padding(5);
            this.lblCPU.Size = new System.Drawing.Size(10, 27);
            this.lblCPU.TabIndex = 12;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(468, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 17);
            this.label1.TabIndex = 11;
            this.label1.Text = "CPU usage:";
            // 
            // btnBrowser
            // 
            this.btnBrowser.Location = new System.Drawing.Point(15, 18);
            this.btnBrowser.Name = "btnBrowser";
            this.btnBrowser.Size = new System.Drawing.Size(75, 23);
            this.btnBrowser.TabIndex = 2;
            this.btnBrowser.Text = "Browers..";
            this.btnBrowser.UseVisualStyleBackColor = true;
            this.btnBrowser.Click += new System.EventHandler(this.btnBrowser_Click_1);
            // 
            // lblPath
            // 
            this.lblPath.AutoSize = true;
            this.lblPath.BackColor = System.Drawing.SystemColors.Info;
            this.lblPath.Location = new System.Drawing.Point(112, 18);
            this.lblPath.Name = "lblPath";
            this.lblPath.Padding = new System.Windows.Forms.Padding(5);
            this.lblPath.Size = new System.Drawing.Size(70, 23);
            this.lblPath.TabIndex = 0;
            this.lblPath.Text = "File Path...";
            // 
            // openFileDialog
            // 
            this.openFileDialog.FileName = "openFileDialog";
            // 
            // HideCheckingFrom
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(808, 677);
            this.Name = "HideCheckingFrom";
            this.Text = "HideCheckingFrom";
            this.Controls.SetChildIndex(this.GroupBox_Assertions, 0);
            this.Controls.SetChildIndex(this.GroupBox_SelectedAssertion, 0);
            this.Controls.SetChildIndex(this.GroupBox_Options, 0);
            this.Controls.SetChildIndex(this.GroupBox_Output, 0);
            ((System.ComponentModel.ISupportInitialize)(this.mRAMCounter)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mCPUCounter)).EndInit();
            this.GroupBox_Assertions.ResumeLayout(false);
            this.GroupBox_SelectedAssertion.ResumeLayout(false);
            this.GroupBox_SelectedAssertion.PerformLayout();
            this.GroupBox_Options.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.GroupBox_Output.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnBrowser;
        private System.Windows.Forms.Label lblPath;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.Label lblRAM;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblCPU;
        private System.Windows.Forms.Label label1;


    }
}
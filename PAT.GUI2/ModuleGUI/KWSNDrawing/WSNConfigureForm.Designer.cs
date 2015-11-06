namespace PAT.GUI.ModuleGUI.KWSNDrawing
{
    partial class WSNConfigForm
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
            this.mGridSensor = new System.Windows.Forms.DataGridView();
            this.mGridChannel = new System.Windows.Forms.DataGridView();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnVerify = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.txtFixed = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtNumberOfPackets = new System.Windows.Forms.TextBox();
            this.btnApply = new System.Windows.Forms.Button();
            this.cmxBufferType = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtSenrMaxBSize = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtSenrMaxQSize = new System.Windows.Forms.TextBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.txtChanlMaxBSize = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.mGridSensor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mGridChannel)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // mGridSensor
            // 
            this.mGridSensor.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.mGridSensor.Location = new System.Drawing.Point(35, 108);
            this.mGridSensor.Name = "mGridSensor";
            this.mGridSensor.Size = new System.Drawing.Size(662, 171);
            this.mGridSensor.TabIndex = 0;
            // 
            // mGridChannel
            // 
            this.mGridChannel.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.mGridChannel.Location = new System.Drawing.Point(23, 19);
            this.mGridChannel.Name = "mGridChannel";
            this.mGridChannel.Size = new System.Drawing.Size(662, 164);
            this.mGridChannel.TabIndex = 1;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(624, 55);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(73, 23);
            this.btnSave.TabIndex = 10;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnVerify
            // 
            this.btnVerify.Location = new System.Drawing.Point(624, 10);
            this.btnVerify.Name = "btnVerify";
            this.btnVerify.Size = new System.Drawing.Size(73, 41);
            this.btnVerify.TabIndex = 8;
            this.btnVerify.Text = "Check initial params";
            this.btnVerify.UseVisualStyleBackColor = true;
            this.btnVerify.Click += new System.EventHandler(this.btnVerify_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Location = new System.Drawing.Point(12, 89);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(696, 195);
            this.groupBox2.TabIndex = 6;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Sensor list";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.mGridChannel);
            this.groupBox3.Location = new System.Drawing.Point(12, 301);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(696, 190);
            this.groupBox3.TabIndex = 0;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Channel list";
            // 
            // txtFixed
            // 
            this.txtFixed.Location = new System.Drawing.Point(52, 52);
            this.txtFixed.Name = "txtFixed";
            this.txtFixed.Size = new System.Drawing.Size(43, 20);
            this.txtFixed.TabIndex = 2;
            this.txtFixed.Text = "10";
            this.txtFixed.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtMaxSizeOfSensor_KeyPress);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(498, 37);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(46, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "Packets";
            // 
            // txtNumberOfPackets
            // 
            this.txtNumberOfPackets.Location = new System.Drawing.Point(550, 34);
            this.txtNumberOfPackets.Name = "txtNumberOfPackets";
            this.txtNumberOfPackets.Size = new System.Drawing.Size(49, 20);
            this.txtNumberOfPackets.TabIndex = 5;
            this.txtNumberOfPackets.Text = "10";
            this.txtNumberOfPackets.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtTimeOfProcessing_KeyPress);
            // 
            // btnApply
            // 
            this.btnApply.Location = new System.Drawing.Point(110, 49);
            this.btnApply.Name = "btnApply";
            this.btnApply.Size = new System.Drawing.Size(55, 23);
            this.btnApply.TabIndex = 11;
            this.btnApply.Text = "Apply";
            this.btnApply.UseVisualStyleBackColor = true;
            this.btnApply.Click += new System.EventHandler(this.btn_apply_Click);
            // 
            // cmxBufferType
            // 
            this.cmxBufferType.FormattingEnabled = true;
            this.cmxBufferType.Location = new System.Drawing.Point(17, 21);
            this.cmxBufferType.Name = "cmxBufferType";
            this.cmxBufferType.Size = new System.Drawing.Size(148, 21);
            this.cmxBufferType.TabIndex = 12;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(14, 55);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(34, 13);
            this.label3.TabIndex = 18;
            this.label3.Text = "Value";
            // 
            // txtSenrMaxBSize
            // 
            this.txtSenrMaxBSize.Location = new System.Drawing.Point(6, 19);
            this.txtSenrMaxBSize.Name = "txtSenrMaxBSize";
            this.txtSenrMaxBSize.Size = new System.Drawing.Size(56, 20);
            this.txtSenrMaxBSize.TabIndex = 20;
            this.txtSenrMaxBSize.Text = "50";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtSenrMaxQSize);
            this.groupBox1.Controls.Add(this.txtSenrMaxBSize);
            this.groupBox1.Location = new System.Drawing.Point(304, 10);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(71, 73);
            this.groupBox1.TabIndex = 22;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Sensor";
            // 
            // txtSenrMaxQSize
            // 
            this.txtSenrMaxQSize.Location = new System.Drawing.Point(6, 48);
            this.txtSenrMaxQSize.Name = "txtSenrMaxQSize";
            this.txtSenrMaxQSize.Size = new System.Drawing.Size(56, 20);
            this.txtSenrMaxQSize.TabIndex = 21;
            this.txtSenrMaxQSize.Text = "50";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.txtChanlMaxBSize);
            this.groupBox4.Location = new System.Drawing.Point(381, 10);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(71, 73);
            this.groupBox4.TabIndex = 23;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Channel";
            // 
            // txtChanlMaxBSize
            // 
            this.txtChanlMaxBSize.Location = new System.Drawing.Point(6, 19);
            this.txtChanlMaxBSize.Name = "txtChanlMaxBSize";
            this.txtChanlMaxBSize.Size = new System.Drawing.Size(56, 20);
            this.txtChanlMaxBSize.TabIndex = 20;
            this.txtChanlMaxBSize.Text = "50";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(220, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 13);
            this.label1.TabIndex = 24;
            this.label1.Text = "Max buffer size";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(217, 61);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(81, 13);
            this.label2.TabIndex = 25;
            this.label2.Text = "Max queue size";
            // 
            // WSNConfigForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(720, 503);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cmxBufferType);
            this.Controls.Add(this.btnApply);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.txtNumberOfPackets);
            this.Controls.Add(this.btnVerify);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.txtFixed);
            this.Controls.Add(this.mGridSensor);
            this.Controls.Add(this.groupBox2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.Name = "WSNConfigForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Sensor Configurate Form";
            ((System.ComponentModel.ISupportInitialize)(this.mGridSensor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mGridChannel)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView mGridSensor;
        private System.Windows.Forms.DataGridView mGridChannel;
        private System.Windows.Forms.Button btnVerify;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.TextBox txtFixed;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtNumberOfPackets;
        private System.Windows.Forms.Button btnApply;
        private System.Windows.Forms.ComboBox cmxBufferType;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtSenrMaxBSize;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtSenrMaxQSize;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.TextBox txtChanlMaxBSize;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}
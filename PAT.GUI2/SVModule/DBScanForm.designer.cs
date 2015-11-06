namespace PAT.GUI.SVModule
{
    partial class DBScanForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.EpsBox = new System.Windows.Forms.TextBox();
            this.PtsBox = new System.Windows.Forms.TextBox();
            this.DBScanFormOk = new System.Windows.Forms.Button();
            this.DBScanFormCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(27, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Epsilon";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(27, 69);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Min pts";
            // 
            // EpsBox
            // 
            this.EpsBox.Location = new System.Drawing.Point(88, 30);
            this.EpsBox.Name = "EpsBox";
            this.EpsBox.Size = new System.Drawing.Size(100, 20);
            this.EpsBox.TabIndex = 2;
            this.EpsBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.EpsBox_KeyPress);
            // 
            // PtsBox
            // 
            this.PtsBox.Location = new System.Drawing.Point(88, 66);
            this.PtsBox.Name = "PtsBox";
            this.PtsBox.Size = new System.Drawing.Size(100, 20);
            this.PtsBox.TabIndex = 3;
            this.PtsBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.PtsBox_KeyPress);
            // 
            // DBScanFormOk
            // 
            this.DBScanFormOk.Location = new System.Drawing.Point(30, 105);
            this.DBScanFormOk.Name = "DBScanFormOk";
            this.DBScanFormOk.Size = new System.Drawing.Size(75, 23);
            this.DBScanFormOk.TabIndex = 4;
            this.DBScanFormOk.Text = "Ok";
            this.DBScanFormOk.UseVisualStyleBackColor = true;
            this.DBScanFormOk.Click += new System.EventHandler(this.DBScanFormOk_Click);
            // 
            // DBScanFormCancel
            // 
            this.DBScanFormCancel.Location = new System.Drawing.Point(113, 105);
            this.DBScanFormCancel.Name = "DBScanFormCancel";
            this.DBScanFormCancel.Size = new System.Drawing.Size(75, 23);
            this.DBScanFormCancel.TabIndex = 5;
            this.DBScanFormCancel.Text = "Cancel";
            this.DBScanFormCancel.UseVisualStyleBackColor = true;
            this.DBScanFormCancel.Click += new System.EventHandler(this.DBScanFormCancel_Click);
            // 
            // DBScanForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(224, 159);
            this.Controls.Add(this.DBScanFormCancel);
            this.Controls.Add(this.DBScanFormOk);
            this.Controls.Add(this.PtsBox);
            this.Controls.Add(this.EpsBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "DBScanForm";
            this.Text = "DBScanForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        public System.Windows.Forms.TextBox EpsBox;
        public System.Windows.Forms.TextBox PtsBox;
        private System.Windows.Forms.Button DBScanFormOk;
        private System.Windows.Forms.Button DBScanFormCancel;
    }
}
namespace PAT.GUI.SVModule
{
    partial class ClusteringForm
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
            this.ClusteringFormOk = new System.Windows.Forms.Button();
            this.ClusteringFormCancel = new System.Windows.Forms.Button();
            this.methodBox = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // ClusteringFormOk
            // 
            this.ClusteringFormOk.Enabled = false;
            this.ClusteringFormOk.Location = new System.Drawing.Point(35, 77);
            this.ClusteringFormOk.Name = "ClusteringFormOk";
            this.ClusteringFormOk.Size = new System.Drawing.Size(75, 23);
            this.ClusteringFormOk.TabIndex = 1;
            this.ClusteringFormOk.Text = "Ok";
            this.ClusteringFormOk.UseVisualStyleBackColor = true;
            this.ClusteringFormOk.Click += new System.EventHandler(this.ClusteringFormOk_Click);
            // 
            // ClusteringFormCancel
            // 
            this.ClusteringFormCancel.Location = new System.Drawing.Point(147, 77);
            this.ClusteringFormCancel.Name = "ClusteringFormCancel";
            this.ClusteringFormCancel.Size = new System.Drawing.Size(75, 23);
            this.ClusteringFormCancel.TabIndex = 2;
            this.ClusteringFormCancel.Text = "Cancel";
            this.ClusteringFormCancel.UseVisualStyleBackColor = true;
            this.ClusteringFormCancel.Click += new System.EventHandler(this.ClusteringFormCancel_Click);
            // 
            // methodBox
            // 
            this.methodBox.FormattingEnabled = true;
            this.methodBox.Items.AddRange(new object[] {
            "KMeanClustering",
            "DBScan"});
            this.methodBox.Location = new System.Drawing.Point(101, 21);
            this.methodBox.Name = "methodBox";
            this.methodBox.Size = new System.Drawing.Size(121, 21);
            this.methodBox.TabIndex = 3;
            this.methodBox.SelectedIndexChanged += new System.EventHandler(this.methodBox_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(32, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "METHOD";
            // 
            // ClusteringForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(257, 124);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.methodBox);
            this.Controls.Add(this.ClusteringFormCancel);
            this.Controls.Add(this.ClusteringFormOk);
            this.Name = "ClusteringForm";
            this.Text = "Clustering Form";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button ClusteringFormOk;
        private System.Windows.Forms.Button ClusteringFormCancel;
        private System.Windows.Forms.ComboBox methodBox;
        private System.Windows.Forms.Label label1;
    }
}
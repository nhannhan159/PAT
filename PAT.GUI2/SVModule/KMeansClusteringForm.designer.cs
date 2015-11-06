namespace PAT.GUI.SVModule
{
    partial class KMeansClusteringForm
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
            this.textBoxKvalue = new System.Windows.Forms.TextBox();
            this.KMeanClusteringFormOk = new System.Windows.Forms.Button();
            this.KMeanClusteringFormCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(32, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "K value";
            // 
            // textBoxKvalue
            // 
            this.textBoxKvalue.Location = new System.Drawing.Point(81, 26);
            this.textBoxKvalue.Name = "textBoxKvalue";
            this.textBoxKvalue.Size = new System.Drawing.Size(100, 20);
            this.textBoxKvalue.TabIndex = 1;
            // 
            // KMeanClusteringFormOk
            // 
            this.KMeanClusteringFormOk.Location = new System.Drawing.Point(26, 73);
            this.KMeanClusteringFormOk.Name = "KMeanClusteringFormOk";
            this.KMeanClusteringFormOk.Size = new System.Drawing.Size(75, 23);
            this.KMeanClusteringFormOk.TabIndex = 2;
            this.KMeanClusteringFormOk.Text = "Ok";
            this.KMeanClusteringFormOk.UseVisualStyleBackColor = true;
            this.KMeanClusteringFormOk.Click += new System.EventHandler(this.KMeanClusteringFormOk_Click);
            // 
            // KMeanClusteringFormCancel
            // 
            this.KMeanClusteringFormCancel.Location = new System.Drawing.Point(128, 73);
            this.KMeanClusteringFormCancel.Name = "KMeanClusteringFormCancel";
            this.KMeanClusteringFormCancel.Size = new System.Drawing.Size(75, 23);
            this.KMeanClusteringFormCancel.TabIndex = 3;
            this.KMeanClusteringFormCancel.Text = "Cancel";
            this.KMeanClusteringFormCancel.UseVisualStyleBackColor = true;
            this.KMeanClusteringFormCancel.Click += new System.EventHandler(this.KMeanClusteringFormCancel_Click);
            // 
            // KMeanClusteringForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(226, 123);
            this.Controls.Add(this.KMeanClusteringFormCancel);
            this.Controls.Add(this.KMeanClusteringFormOk);
            this.Controls.Add(this.textBoxKvalue);
            this.Controls.Add(this.label1);
            this.Name = "KMeanClusteringForm";
            this.Text = "KMeanClusteringForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxKvalue;
        private System.Windows.Forms.Button KMeanClusteringFormOk;
        private System.Windows.Forms.Button KMeanClusteringFormCancel;
    }
}
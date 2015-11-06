namespace PAT.GUI.SVModule
{
    partial class ConfirmForm
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
            this.ConfirmFormYes = new System.Windows.Forms.Button();
            this.ConfirmFormNo = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // ConfirmFormYes
            // 
            this.ConfirmFormYes.Location = new System.Drawing.Point(12, 122);
            this.ConfirmFormYes.Name = "ConfirmFormYes";
            this.ConfirmFormYes.Size = new System.Drawing.Size(75, 23);
            this.ConfirmFormYes.TabIndex = 0;
            this.ConfirmFormYes.Text = "Yes";
            this.ConfirmFormYes.UseVisualStyleBackColor = true;
            this.ConfirmFormYes.Click += new System.EventHandler(this.ConfirmFormYes_Click);
            // 
            // ConfirmFormNo
            // 
            this.ConfirmFormNo.Location = new System.Drawing.Point(142, 122);
            this.ConfirmFormNo.Name = "ConfirmFormNo";
            this.ConfirmFormNo.Size = new System.Drawing.Size(75, 23);
            this.ConfirmFormNo.TabIndex = 1;
            this.ConfirmFormNo.Text = "No";
            this.ConfirmFormNo.UseVisualStyleBackColor = true;
            this.ConfirmFormNo.Click += new System.EventHandler(this.ConfirmFormNo_Click);
            // 
            // ConfirmForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(229, 170);
            this.Controls.Add(this.ConfirmFormNo);
            this.Controls.Add(this.ConfirmFormYes);
            this.Name = "ConfirmForm";
            this.Text = "ConfirmForm";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button ConfirmFormYes;
        private System.Windows.Forms.Button ConfirmFormNo;
    }
}
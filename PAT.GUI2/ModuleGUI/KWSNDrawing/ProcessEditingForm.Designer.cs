﻿namespace PAT.GUI.KWSNDrawing
{
    partial class ProcessEditingForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ProcessEditingForm));
            this.Label_Name = new System.Windows.Forms.Label();
            this.TextBox_Name = new System.Windows.Forms.TextBox();
            this.Button_OK = new System.Windows.Forms.Button();
            this.Button_Cancel = new System.Windows.Forms.Button();
            this.TextBox_Paramater = new System.Windows.Forms.TextBox();
            this.Label_Parameters = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // Label_Name
            // 
            resources.ApplyResources(this.Label_Name, "Label_Name");
            this.Label_Name.Name = "Label_Name";
            // 
            // TextBox_Name
            // 
            resources.ApplyResources(this.TextBox_Name, "TextBox_Name");
            this.TextBox_Name.Name = "TextBox_Name";
            // 
            // Button_OK
            // 
            this.Button_OK.DialogResult = System.Windows.Forms.DialogResult.OK;
            resources.ApplyResources(this.Button_OK, "Button_OK");
            this.Button_OK.Name = "Button_OK";
            this.Button_OK.UseVisualStyleBackColor = true;
            this.Button_OK.Click += new System.EventHandler(this.Button_OK_Click);
            // 
            // Button_Cancel
            // 
            this.Button_Cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            resources.ApplyResources(this.Button_Cancel, "Button_Cancel");
            this.Button_Cancel.Name = "Button_Cancel";
            this.Button_Cancel.UseVisualStyleBackColor = true;
            // 
            // TextBox_Paramater
            // 
            resources.ApplyResources(this.TextBox_Paramater, "TextBox_Paramater");
            this.TextBox_Paramater.Name = "TextBox_Paramater";
            // 
            // Label_Parameters
            // 
            resources.ApplyResources(this.Label_Parameters, "Label_Parameters");
            this.Label_Parameters.Name = "Label_Parameters";
            // 
            // ProcessEditingForm
            // 
            this.AcceptButton = this.Button_OK;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.Button_Cancel;
            this.Controls.Add(this.TextBox_Paramater);
            this.Controls.Add(this.Label_Parameters);
            this.Controls.Add(this.Button_Cancel);
            this.Controls.Add(this.Button_OK);
            this.Controls.Add(this.TextBox_Name);
            this.Controls.Add(this.Label_Name);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ProcessEditingForm";
            this.ShowIcon = false;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label Label_Name;
        private System.Windows.Forms.TextBox TextBox_Name;
        private System.Windows.Forms.Button Button_OK;
        private System.Windows.Forms.Button Button_Cancel;
        private System.Windows.Forms.TextBox TextBox_Paramater;
        private System.Windows.Forms.Label Label_Parameters;
    }
}
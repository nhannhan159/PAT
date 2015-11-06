namespace PAT.GUI
{
    partial class OpenClustersForm
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
            this.CloseBtn = new System.Windows.Forms.Button();
            this.openClusterBtn = new System.Windows.Forms.Button();
            this.listViewAfter = new System.Windows.Forms.ListView();
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.groupAfterClusters = new System.Windows.Forms.GroupBox();
            this.groupBeforeClusters = new System.Windows.Forms.GroupBox();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.listViewBefore = new System.Windows.Forms.ListView();
            this.groupAfterClusters.SuspendLayout();
            this.groupBeforeClusters.SuspendLayout();
            this.SuspendLayout();
            // 
            // CloseBtn
            // 
            this.CloseBtn.Location = new System.Drawing.Point(422, 395);
            this.CloseBtn.Name = "CloseBtn";
            this.CloseBtn.Size = new System.Drawing.Size(75, 23);
            this.CloseBtn.TabIndex = 0;
            this.CloseBtn.Text = "Close";
            this.CloseBtn.UseVisualStyleBackColor = true;
            this.CloseBtn.Click += new System.EventHandler(this.CloseBtn_Click);
            // 
            // openClusterBtn
            // 
            this.openClusterBtn.Image = global::PAT.GUI.Properties.Resources.open_spec;
            this.openClusterBtn.Location = new System.Drawing.Point(444, 333);
            this.openClusterBtn.Name = "openClusterBtn";
            this.openClusterBtn.Size = new System.Drawing.Size(32, 29);
            this.openClusterBtn.TabIndex = 1;
            this.openClusterBtn.UseVisualStyleBackColor = true;
            this.openClusterBtn.Click += new System.EventHandler(this.openClusterBtn_Click);
            // 
            // listViewAfter
            // 
            this.listViewAfter.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader2});
            this.listViewAfter.GridLines = true;
            this.listViewAfter.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.listViewAfter.Location = new System.Drawing.Point(11, 31);
            this.listViewAfter.MultiSelect = false;
            this.listViewAfter.Name = "listViewAfter";
            this.listViewAfter.Size = new System.Drawing.Size(374, 370);
            this.listViewAfter.TabIndex = 0;
            this.listViewAfter.UseCompatibleStateImageBehavior = false;
            this.listViewAfter.View = System.Windows.Forms.View.Details;
            this.listViewAfter.SelectedIndexChanged += new System.EventHandler(this.listViewAfter_SelectedIndexChanged);
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "After Clusters";
            this.columnHeader2.Width = 369;
            // 
            // groupAfterClusters
            // 
            this.groupAfterClusters.Controls.Add(this.listViewAfter);
            this.groupAfterClusters.Location = new System.Drawing.Point(513, 17);
            this.groupAfterClusters.Name = "groupAfterClusters";
            this.groupAfterClusters.Size = new System.Drawing.Size(395, 425);
            this.groupAfterClusters.TabIndex = 5;
            this.groupAfterClusters.TabStop = false;
            this.groupAfterClusters.Text = "After clusters";
            // 
            // groupBeforeClusters
            // 
            this.groupBeforeClusters.Controls.Add(this.listViewBefore);
            this.groupBeforeClusters.Location = new System.Drawing.Point(12, 17);
            this.groupBeforeClusters.Name = "groupBeforeClusters";
            this.groupBeforeClusters.Size = new System.Drawing.Size(395, 425);
            this.groupBeforeClusters.TabIndex = 4;
            this.groupBeforeClusters.TabStop = false;
            this.groupBeforeClusters.Text = "Before clusters";
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Before Clusters";
            this.columnHeader1.Width = 369;
            // 
            // listViewBefore
            // 
            this.listViewBefore.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1});
            this.listViewBefore.GridLines = true;
            this.listViewBefore.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.listViewBefore.Location = new System.Drawing.Point(10, 31);
            this.listViewBefore.MultiSelect = false;
            this.listViewBefore.Name = "listViewBefore";
            this.listViewBefore.Size = new System.Drawing.Size(374, 370);
            this.listViewBefore.TabIndex = 3;
            this.listViewBefore.UseCompatibleStateImageBehavior = false;
            this.listViewBefore.View = System.Windows.Forms.View.Details;
            this.listViewBefore.SelectedIndexChanged += new System.EventHandler(this.listViewBefore_SelectedIndexChanged);
            // 
            // OpenClustersForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(924, 461);
            this.Controls.Add(this.openClusterBtn);
            this.Controls.Add(this.CloseBtn);
            this.Controls.Add(this.groupAfterClusters);
            this.Controls.Add(this.groupBeforeClusters);
            this.MaximumSize = new System.Drawing.Size(940, 500);
            this.MinimumSize = new System.Drawing.Size(940, 500);
            this.Name = "OpenClustersForm";
            this.Text = "Open Clusters Form";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.OpenClustersForm_FormClosed);
            this.groupAfterClusters.ResumeLayout(false);
            this.groupBeforeClusters.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button CloseBtn;
        private System.Windows.Forms.Button openClusterBtn;
        private System.Windows.Forms.ListView listViewAfter;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.GroupBox groupAfterClusters;
        private System.Windows.Forms.GroupBox groupBeforeClusters;
        private System.Windows.Forms.ListView listViewBefore;
        private System.Windows.Forms.ColumnHeader columnHeader1;



    }
}
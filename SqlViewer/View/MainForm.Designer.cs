namespace SqlViewer.View
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.twServer = new System.Windows.Forms.TreeView();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsbSelect = new System.Windows.Forms.ToolStripButton();
            this.tsbXML = new System.Windows.Forms.ToolStripButton();
            this.tbContent = new System.Windows.Forms.TextBox();
            this.tbDisplayOnly = new System.Windows.Forms.TextBox(); // New TextBox for displaying data
            this.btnExecute = new System.Windows.Forms.Button(); // New Execute Button
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // twServer
            // 
            this.twServer.Location = new System.Drawing.Point(22, 73);
            this.twServer.Margin = new System.Windows.Forms.Padding(1);
            this.twServer.Name = "twServer";
            this.twServer.Size = new System.Drawing.Size(396, 823);
            this.twServer.TabIndex = 0;
            this.twServer.AfterCollapse += new System.Windows.Forms.TreeViewEventHandler(this.TwServer_AfterCollapse);
            this.twServer.BeforeExpand += new System.Windows.Forms.TreeViewCancelEventHandler(this.TwServer_BeforeExpand);
            // 
            // toolStrip1
            // 
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(40, 40);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbSelect,
            this.tsbXML});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Padding = new System.Windows.Forms.Padding(0);
            this.toolStrip1.Size = new System.Drawing.Size(1114, 47);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tsbSelect
            // 
            this.tsbSelect.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbSelect.Image = ((System.Drawing.Image)(resources.GetObject("tsbSelect.Image")));
            this.tsbSelect.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbSelect.Name = "tsbSelect";
            this.tsbSelect.Size = new System.Drawing.Size(44, 44);
            this.tsbSelect.Text = "Select";
            this.tsbSelect.Click += new System.EventHandler(this.TsbSelect_Click);
            // 
            // tsbXML
            // 
            this.tsbXML.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbXML.Image = ((System.Drawing.Image)(resources.GetObject("tsbXML.Image")));
            this.tsbXML.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbXML.Name = "tsbXML";
            this.tsbXML.Size = new System.Drawing.Size(44, 44);
            this.tsbXML.Text = "XML";
            this.tsbXML.Click += new System.EventHandler(this.TsbXML_Click);
            // 
            // tbContent
            // 
            this.tbContent.Location = new System.Drawing.Point(442, 73);
            this.tbContent.Margin = new System.Windows.Forms.Padding(1);
            this.tbContent.Multiline = true;
            this.tbContent.Name = "tbContent";
            this.tbContent.Size = new System.Drawing.Size(660, 569);
            this.tbContent.TabIndex = 2;
            this.tbContent.BackColor = System.Drawing.SystemColors.Window; // Ensure white background
            // 
            // tbDisplayOnly
            // 
            this.tbDisplayOnly.Location = new System.Drawing.Point(442, 723); // Adjusted location to make room for button
            this.tbDisplayOnly.Margin = new System.Windows.Forms.Padding(1);
            this.tbDisplayOnly.Multiline = true;
            this.tbDisplayOnly.Name = "tbDisplayOnly";
            this.tbDisplayOnly.ReadOnly = true; // Set ReadOnly to make it display-only
            this.tbDisplayOnly.Size = new System.Drawing.Size(660, 150); // Adjust size as needed
            this.tbDisplayOnly.TabIndex = 3;
            this.tbDisplayOnly.BackColor = System.Drawing.SystemColors.Window; // Set white background
            // 
            // btnExecute
            // 
            this.btnExecute.Location = new System.Drawing.Point(442, 648); // Positioned between the two textboxes
            this.btnExecute.Margin = new System.Windows.Forms.Padding(1);
            this.btnExecute.Name = "btnExecute";
            this.btnExecute.Size = new System.Drawing.Size(660, 40); // Adjust size as needed
            this.btnExecute.TabIndex = 4;
            this.btnExecute.Text = "Execute";
            this.btnExecute.UseVisualStyleBackColor = true;
            this.btnExecute.Click += new System.EventHandler(this.BtnExecute_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1114, 928);
            this.Controls.Add(this.btnExecute); // Add Execute Button to the form
            this.Controls.Add(this.tbDisplayOnly);
            this.Controls.Add(this.tbContent);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.twServer);
            this.Margin = new System.Windows.Forms.Padding(1);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SSMS";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainForm_FormClosed);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.TreeView twServer;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tsbSelect;
        private System.Windows.Forms.ToolStripButton tsbXML;
        private System.Windows.Forms.TextBox tbContent;
        private System.Windows.Forms.TextBox tbDisplayOnly; // New TextBox field
        private System.Windows.Forms.Button btnExecute; // New Execute Button
    }
}

namespace RayTrace
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
            this.worldBox = new System.Windows.Forms.PictureBox();
            this.thetaBar = new System.Windows.Forms.TrackBar();
            this.phiBar = new System.Windows.Forms.TrackBar();
            this.thetaLabel = new System.Windows.Forms.Label();
            this.phiLabel = new System.Windows.Forms.Label();
            this.cameraBar = new System.Windows.Forms.TrackBar();
            this.cameraLabel = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.runTestToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.worldBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.thetaBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.phiBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cameraBar)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // worldBox
            // 
            this.worldBox.BackColor = System.Drawing.SystemColors.ControlDark;
            this.worldBox.Location = new System.Drawing.Point(12, 27);
            this.worldBox.Name = "worldBox";
            this.worldBox.Size = new System.Drawing.Size(600, 600);
            this.worldBox.TabIndex = 0;
            this.worldBox.TabStop = false;
            this.worldBox.Paint += new System.Windows.Forms.PaintEventHandler(this.worldBox_Paint);
            // 
            // thetaBar
            // 
            this.thetaBar.Location = new System.Drawing.Point(640, 500);
            this.thetaBar.Maximum = 6;
            this.thetaBar.Name = "thetaBar";
            this.thetaBar.Size = new System.Drawing.Size(104, 45);
            this.thetaBar.TabIndex = 1;
            this.thetaBar.Value = 3;
            this.thetaBar.Scroll += new System.EventHandler(this.thetaBar_Scroll);
            // 
            // phiBar
            // 
            this.phiBar.Location = new System.Drawing.Point(640, 551);
            this.phiBar.Maximum = 6;
            this.phiBar.Name = "phiBar";
            this.phiBar.Size = new System.Drawing.Size(104, 45);
            this.phiBar.TabIndex = 2;
            this.phiBar.Value = 3;
            this.phiBar.Scroll += new System.EventHandler(this.phiBar_Scroll);
            // 
            // thetaLabel
            // 
            this.thetaLabel.AutoSize = true;
            this.thetaLabel.Location = new System.Drawing.Point(738, 532);
            this.thetaLabel.Name = "thetaLabel";
            this.thetaLabel.Size = new System.Drawing.Size(59, 13);
            this.thetaLabel.TabIndex = 3;
            this.thetaLabel.Text = "Theta: 180";
            // 
            // phiLabel
            // 
            this.phiLabel.AutoSize = true;
            this.phiLabel.Location = new System.Drawing.Point(750, 551);
            this.phiLabel.Name = "phiLabel";
            this.phiLabel.Size = new System.Drawing.Size(46, 13);
            this.phiLabel.TabIndex = 4;
            this.phiLabel.Text = "Phi: 180";
            // 
            // cameraBar
            // 
            this.cameraBar.Location = new System.Drawing.Point(640, 612);
            this.cameraBar.Maximum = -1;
            this.cameraBar.Minimum = -100;
            this.cameraBar.Name = "cameraBar";
            this.cameraBar.Size = new System.Drawing.Size(104, 45);
            this.cameraBar.TabIndex = 5;
            this.cameraBar.Value = -5;
            this.cameraBar.Scroll += new System.EventHandler(this.cameraBar_Scroll);
            // 
            // cameraLabel
            // 
            this.cameraLabel.AutoSize = true;
            this.cameraLabel.Location = new System.Drawing.Point(741, 564);
            this.cameraLabel.Name = "cameraLabel";
            this.cameraLabel.Size = new System.Drawing.Size(65, 13);
            this.cameraLabel.TabIndex = 6;
            this.cameraLabel.Text = "CameraY: -5";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(818, 24);
            this.menuStrip1.TabIndex = 7;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.runTestToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // runTestToolStripMenuItem
            // 
            this.runTestToolStripMenuItem.Name = "runTestToolStripMenuItem";
            this.runTestToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.runTestToolStripMenuItem.Text = "Run Test";
            this.runTestToolStripMenuItem.Click += new System.EventHandler(this.runTestToolStripMenuItem_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(818, 676);
            this.Controls.Add(this.cameraLabel);
            this.Controls.Add(this.cameraBar);
            this.Controls.Add(this.phiLabel);
            this.Controls.Add(this.thetaLabel);
            this.Controls.Add(this.phiBar);
            this.Controls.Add(this.thetaBar);
            this.Controls.Add(this.worldBox);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.worldBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.thetaBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.phiBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cameraBar)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox worldBox;
        private System.Windows.Forms.TrackBar thetaBar;
        private System.Windows.Forms.TrackBar phiBar;
        private System.Windows.Forms.Label thetaLabel;
        private System.Windows.Forms.Label phiLabel;
        private System.Windows.Forms.TrackBar cameraBar;
        private System.Windows.Forms.Label cameraLabel;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem runTestToolStripMenuItem;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
    }
}


namespace Life {
    partial class Form1 {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.components = new System.ComponentModel.Container();
            this.worldBox = new System.Windows.Forms.PictureBox();
            this.resetB = new System.Windows.Forms.Button();
            this.startstop = new System.Windows.Forms.Button();
            this.advanceB = new System.Windows.Forms.Button();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.speedBar = new System.Windows.Forms.TrackBar();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.sizeText = new System.Windows.Forms.TextBox();
            this.sizeButton = new System.Windows.Forms.Button();
            this.zoomBar = new System.Windows.Forms.VScrollBar();
            this.populationLabel = new System.Windows.Forms.Label();
            this.donutBox = new System.Windows.Forms.ComboBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.quitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.runTestToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.displayGridToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.threadedToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.prefabsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.spaceshipsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gliderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lightWeightSpaceShipToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gunsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gosperGliderGunToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.oscillatorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lineToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.methusToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dieHardToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.worldBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.speedBar)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // worldBox
            // 
            this.worldBox.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.worldBox.Location = new System.Drawing.Point(2, 27);
            this.worldBox.Name = "worldBox";
            this.worldBox.Size = new System.Drawing.Size(1000, 1000);
            this.worldBox.TabIndex = 0;
            this.worldBox.TabStop = false;
            this.worldBox.Paint += new System.Windows.Forms.PaintEventHandler(this.worldBox_Paint);
            this.worldBox.MouseClick += new System.Windows.Forms.MouseEventHandler(this.worldBox_MouseClick);
            this.worldBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.worldBox_MouseDown);
            this.worldBox.MouseEnter += new System.EventHandler(this.worldBox_MouseEnter);
            this.worldBox.MouseMove += new System.Windows.Forms.MouseEventHandler(this.worldBox_MouseMove);
            this.worldBox.MouseUp += new System.Windows.Forms.MouseEventHandler(this.worldBox_MouseUp);
            // 
            // resetB
            // 
            this.resetB.Location = new System.Drawing.Point(1097, 138);
            this.resetB.Name = "resetB";
            this.resetB.Size = new System.Drawing.Size(75, 23);
            this.resetB.TabIndex = 1;
            this.resetB.Text = "Reset";
            this.resetB.UseVisualStyleBackColor = true;
            this.resetB.Click += new System.EventHandler(this.resetB_Click);
            // 
            // startstop
            // 
            this.startstop.Location = new System.Drawing.Point(1097, 167);
            this.startstop.Name = "startstop";
            this.startstop.Size = new System.Drawing.Size(75, 23);
            this.startstop.TabIndex = 2;
            this.startstop.Text = "Start";
            this.startstop.UseVisualStyleBackColor = true;
            this.startstop.Click += new System.EventHandler(this.startstop_Click);
            // 
            // advanceB
            // 
            this.advanceB.Location = new System.Drawing.Point(1095, 109);
            this.advanceB.Name = "advanceB";
            this.advanceB.Size = new System.Drawing.Size(75, 23);
            this.advanceB.TabIndex = 3;
            this.advanceB.Text = "Advance";
            this.advanceB.UseVisualStyleBackColor = true;
            this.advanceB.Click += new System.EventHandler(this.advanceB_Click);
            // 
            // timer
            // 
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // speedBar
            // 
            this.speedBar.LargeChange = 100;
            this.speedBar.Location = new System.Drawing.Point(1097, 196);
            this.speedBar.Maximum = 1000;
            this.speedBar.Minimum = 1;
            this.speedBar.Name = "speedBar";
            this.speedBar.Size = new System.Drawing.Size(77, 45);
            this.speedBar.SmallChange = 10;
            this.speedBar.TabIndex = 4;
            this.speedBar.Value = 500;
            this.speedBar.Scroll += new System.EventHandler(this.speedBar_Scroll);
            // 
            // openFileDialog
            // 
            this.openFileDialog.FileName = "openFileDialog";
            // 
            // sizeText
            // 
            this.sizeText.Location = new System.Drawing.Point(1097, 56);
            this.sizeText.Name = "sizeText";
            this.sizeText.Size = new System.Drawing.Size(75, 20);
            this.sizeText.TabIndex = 7;
            this.sizeText.Text = "50";
            // 
            // sizeButton
            // 
            this.sizeButton.Location = new System.Drawing.Point(1097, 27);
            this.sizeButton.Name = "sizeButton";
            this.sizeButton.Size = new System.Drawing.Size(75, 23);
            this.sizeButton.TabIndex = 8;
            this.sizeButton.Text = "Set size";
            this.sizeButton.UseVisualStyleBackColor = true;
            this.sizeButton.Click += new System.EventHandler(this.sizeButton_Click);
            // 
            // zoomBar
            // 
            this.zoomBar.Location = new System.Drawing.Point(1005, 27);
            this.zoomBar.Minimum = 2;
            this.zoomBar.Name = "zoomBar";
            this.zoomBar.Size = new System.Drawing.Size(17, 500);
            this.zoomBar.TabIndex = 9;
            this.zoomBar.Value = 10;
            this.zoomBar.Scroll += new System.Windows.Forms.ScrollEventHandler(this.zoomBar_Scroll);
            // 
            // populationLabel
            // 
            this.populationLabel.AutoSize = true;
            this.populationLabel.Location = new System.Drawing.Point(1008, 527);
            this.populationLabel.Name = "populationLabel";
            this.populationLabel.Size = new System.Drawing.Size(88, 13);
            this.populationLabel.TabIndex = 10;
            this.populationLabel.Text = "Population things";
            // 
            // donutBox
            // 
            this.donutBox.FormattingEnabled = true;
            this.donutBox.Items.AddRange(new object[] {
            "Torus",
            "Flat"});
            this.donutBox.Location = new System.Drawing.Point(1095, 82);
            this.donutBox.Name = "donutBox";
            this.donutBox.Size = new System.Drawing.Size(77, 21);
            this.donutBox.TabIndex = 11;
            this.donutBox.SelectedIndexChanged += new System.EventHandler(this.donutBox_SelectedIndexChanged);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.editToolStripMenuItem,
            this.prefabsToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1184, 24);
            this.menuStrip1.TabIndex = 12;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saveToolStripMenuItem,
            this.loadToolStripMenuItem,
            this.quitToolStripMenuItem,
            this.toolStripSeparator1,
            this.runTestToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(120, 22);
            this.saveToolStripMenuItem.Text = "Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // loadToolStripMenuItem
            // 
            this.loadToolStripMenuItem.Name = "loadToolStripMenuItem";
            this.loadToolStripMenuItem.Size = new System.Drawing.Size(120, 22);
            this.loadToolStripMenuItem.Text = "Load";
            this.loadToolStripMenuItem.Click += new System.EventHandler(this.loadToolStripMenuItem_Click);
            // 
            // quitToolStripMenuItem
            // 
            this.quitToolStripMenuItem.Name = "quitToolStripMenuItem";
            this.quitToolStripMenuItem.Size = new System.Drawing.Size(120, 22);
            this.quitToolStripMenuItem.Text = "Quit";
            this.quitToolStripMenuItem.Click += new System.EventHandler(this.quitToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(117, 6);
            // 
            // runTestToolStripMenuItem
            // 
            this.runTestToolStripMenuItem.Name = "runTestToolStripMenuItem";
            this.runTestToolStripMenuItem.Size = new System.Drawing.Size(120, 22);
            this.runTestToolStripMenuItem.Text = "Run Test";
            this.runTestToolStripMenuItem.Click += new System.EventHandler(this.runTestToolStripMenuItem_Click);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.displayGridToolStripMenuItem,
            this.threadedToolStripMenuItem});
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(39, 20);
            this.editToolStripMenuItem.Text = "Edit";
            // 
            // displayGridToolStripMenuItem
            // 
            this.displayGridToolStripMenuItem.Name = "displayGridToolStripMenuItem";
            this.displayGridToolStripMenuItem.Size = new System.Drawing.Size(159, 22);
            this.displayGridToolStripMenuItem.Text = "Display Grid";
            this.displayGridToolStripMenuItem.Click += new System.EventHandler(this.displayGridToolStripMenuItem_Click);
            // 
            // threadedToolStripMenuItem
            // 
            this.threadedToolStripMenuItem.Checked = true;
            this.threadedToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.threadedToolStripMenuItem.Name = "threadedToolStripMenuItem";
            this.threadedToolStripMenuItem.Size = new System.Drawing.Size(159, 22);
            this.threadedToolStripMenuItem.Text = "Multi Threading";
            this.threadedToolStripMenuItem.Click += new System.EventHandler(this.threadedToolStripMenuItem_Click);
            // 
            // prefabsToolStripMenuItem
            // 
            this.prefabsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.spaceshipsToolStripMenuItem,
            this.gunsToolStripMenuItem,
            this.oscillatorToolStripMenuItem,
            this.methusToolStripMenuItem});
            this.prefabsToolStripMenuItem.Name = "prefabsToolStripMenuItem";
            this.prefabsToolStripMenuItem.Size = new System.Drawing.Size(58, 20);
            this.prefabsToolStripMenuItem.Text = "Prefabs";
            // 
            // spaceshipsToolStripMenuItem
            // 
            this.spaceshipsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.gliderToolStripMenuItem,
            this.lightWeightSpaceShipToolStripMenuItem});
            this.spaceshipsToolStripMenuItem.Name = "spaceshipsToolStripMenuItem";
            this.spaceshipsToolStripMenuItem.Size = new System.Drawing.Size(141, 22);
            this.spaceshipsToolStripMenuItem.Text = "Spaceships";
            // 
            // gliderToolStripMenuItem
            // 
            this.gliderToolStripMenuItem.Name = "gliderToolStripMenuItem";
            this.gliderToolStripMenuItem.Size = new System.Drawing.Size(202, 22);
            this.gliderToolStripMenuItem.Text = "Glider";
            this.gliderToolStripMenuItem.Click += new System.EventHandler(this.gliderToolStripMenuItem_Click);
            // 
            // lightWeightSpaceShipToolStripMenuItem
            // 
            this.lightWeightSpaceShipToolStripMenuItem.Name = "lightWeightSpaceShipToolStripMenuItem";
            this.lightWeightSpaceShipToolStripMenuItem.Size = new System.Drawing.Size(202, 22);
            this.lightWeightSpaceShipToolStripMenuItem.Text = "Light Weight Space Ship";
            this.lightWeightSpaceShipToolStripMenuItem.Click += new System.EventHandler(this.lightWeightSpaceShipToolStripMenuItem_Click);
            // 
            // gunsToolStripMenuItem
            // 
            this.gunsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.gosperGliderGunToolStripMenuItem});
            this.gunsToolStripMenuItem.Name = "gunsToolStripMenuItem";
            this.gunsToolStripMenuItem.Size = new System.Drawing.Size(141, 22);
            this.gunsToolStripMenuItem.Text = "Guns";
            // 
            // gosperGliderGunToolStripMenuItem
            // 
            this.gosperGliderGunToolStripMenuItem.Name = "gosperGliderGunToolStripMenuItem";
            this.gosperGliderGunToolStripMenuItem.Size = new System.Drawing.Size(170, 22);
            this.gosperGliderGunToolStripMenuItem.Text = "Gosper Glider Gun";
            this.gosperGliderGunToolStripMenuItem.Click += new System.EventHandler(this.gosperGliderGunToolStripMenuItem_Click);
            // 
            // oscillatorToolStripMenuItem
            // 
            this.oscillatorToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lineToolStripMenuItem});
            this.oscillatorToolStripMenuItem.Name = "oscillatorToolStripMenuItem";
            this.oscillatorToolStripMenuItem.Size = new System.Drawing.Size(141, 22);
            this.oscillatorToolStripMenuItem.Text = "Oscillators";
            // 
            // lineToolStripMenuItem
            // 
            this.lineToolStripMenuItem.Name = "lineToolStripMenuItem";
            this.lineToolStripMenuItem.Size = new System.Drawing.Size(96, 22);
            this.lineToolStripMenuItem.Text = "Line";
            this.lineToolStripMenuItem.Click += new System.EventHandler(this.lineToolStripMenuItem_Click);
            // 
            // methusToolStripMenuItem
            // 
            this.methusToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.dieHardToolStripMenuItem});
            this.methusToolStripMenuItem.Name = "methusToolStripMenuItem";
            this.methusToolStripMenuItem.Size = new System.Drawing.Size(141, 22);
            this.methusToolStripMenuItem.Text = "Methuselahs";
            // 
            // dieHardToolStripMenuItem
            // 
            this.dieHardToolStripMenuItem.Name = "dieHardToolStripMenuItem";
            this.dieHardToolStripMenuItem.Size = new System.Drawing.Size(120, 22);
            this.dieHardToolStripMenuItem.Text = "Die Hard";
            this.dieHardToolStripMenuItem.Click += new System.EventHandler(this.dieHardToolStripMenuItem_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1184, 1006);
            this.Controls.Add(this.donutBox);
            this.Controls.Add(this.populationLabel);
            this.Controls.Add(this.zoomBar);
            this.Controls.Add(this.sizeButton);
            this.Controls.Add(this.sizeText);
            this.Controls.Add(this.speedBar);
            this.Controls.Add(this.advanceB);
            this.Controls.Add(this.startstop);
            this.Controls.Add(this.resetB);
            this.Controls.Add(this.worldBox);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Life";
            ((System.ComponentModel.ISupportInitialize)(this.worldBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.speedBar)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox worldBox;
        private System.Windows.Forms.Button resetB;
        private System.Windows.Forms.Button startstop;
        private System.Windows.Forms.Button advanceB;
        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.TrackBar speedBar;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
        private System.Windows.Forms.TextBox sizeText;
        private System.Windows.Forms.Button sizeButton;
        private System.Windows.Forms.VScrollBar zoomBar;
        private System.Windows.Forms.Label populationLabel;
        private System.Windows.Forms.ComboBox donutBox;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem quitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem prefabsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem displayGridToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem spaceshipsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem gliderToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem runTestToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem gunsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem gosperGliderGunToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem lightWeightSpaceShipToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem oscillatorToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem lineToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem methusToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dieHardToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem threadedToolStripMenuItem;
    }
}


namespace PacMan
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
            this.components = new System.ComponentModel.Container();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.optionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.restartToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.playlistToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dubThemeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dubTheme2ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.metalToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pauseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.soundONOFFToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 40;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.Black;
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(631, 24);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // optionsToolStripMenuItem
            // 
            this.optionsToolStripMenuItem.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.optionsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.restartToolStripMenuItem,
            this.playlistToolStripMenuItem});
            this.optionsToolStripMenuItem.ForeColor = System.Drawing.SystemColors.Control;
            this.optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
            this.optionsToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.optionsToolStripMenuItem.Text = "Options";
            // 
            // restartToolStripMenuItem
            // 
            this.restartToolStripMenuItem.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.restartToolStripMenuItem.ForeColor = System.Drawing.SystemColors.Control;
            this.restartToolStripMenuItem.Name = "restartToolStripMenuItem";
            this.restartToolStripMenuItem.Size = new System.Drawing.Size(111, 22);
            this.restartToolStripMenuItem.Text = "Restart";
            // 
            // playlistToolStripMenuItem
            // 
            this.playlistToolStripMenuItem.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.playlistToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.dubThemeToolStripMenuItem,
            this.dubTheme2ToolStripMenuItem,
            this.metalToolStripMenuItem});
            this.playlistToolStripMenuItem.ForeColor = System.Drawing.SystemColors.Control;
            this.playlistToolStripMenuItem.Name = "playlistToolStripMenuItem";
            this.playlistToolStripMenuItem.Size = new System.Drawing.Size(111, 22);
            this.playlistToolStripMenuItem.Text = "Playlist";
            // 
            // dubThemeToolStripMenuItem
            // 
            this.dubThemeToolStripMenuItem.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.dubThemeToolStripMenuItem.Checked = true;
            this.dubThemeToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.dubThemeToolStripMenuItem.ForeColor = System.Drawing.SystemColors.Control;
            this.dubThemeToolStripMenuItem.Name = "dubThemeToolStripMenuItem";
            this.dubThemeToolStripMenuItem.Size = new System.Drawing.Size(145, 22);
            this.dubThemeToolStripMenuItem.Text = "Dub Theme";
            // 
            // dubTheme2ToolStripMenuItem
            // 
            this.dubTheme2ToolStripMenuItem.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.dubTheme2ToolStripMenuItem.Checked = true;
            this.dubTheme2ToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.dubTheme2ToolStripMenuItem.ForeColor = System.Drawing.SystemColors.Control;
            this.dubTheme2ToolStripMenuItem.Name = "dubTheme2ToolStripMenuItem";
            this.dubTheme2ToolStripMenuItem.Size = new System.Drawing.Size(145, 22);
            this.dubTheme2ToolStripMenuItem.Text = "Dub Theme 2";
            // 
            // metalToolStripMenuItem
            // 
            this.metalToolStripMenuItem.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.metalToolStripMenuItem.Checked = true;
            this.metalToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.metalToolStripMenuItem.ForeColor = System.Drawing.SystemColors.Control;
            this.metalToolStripMenuItem.Name = "metalToolStripMenuItem";
            this.metalToolStripMenuItem.Size = new System.Drawing.Size(145, 22);
            this.metalToolStripMenuItem.Text = "Metal";
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.exitToolStripMenuItem.ForeColor = System.Drawing.SystemColors.Control;
            this.exitToolStripMenuItem.Image = global::PacMan.Properties.Resources.redX;
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(28, 20);
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // pauseToolStripMenuItem
            // 
            this.pauseToolStripMenuItem.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.pauseToolStripMenuItem.ForeColor = System.Drawing.SystemColors.Control;
            this.pauseToolStripMenuItem.Image = global::PacMan.Properties.Resources.pause;
            this.pauseToolStripMenuItem.Name = "pauseToolStripMenuItem";
            this.pauseToolStripMenuItem.Size = new System.Drawing.Size(28, 20);
            this.pauseToolStripMenuItem.Click += new System.EventHandler(this.pauseToolStripMenuItem_Click);
            // 
            // soundONOFFToolStripMenuItem
            // 
            this.soundONOFFToolStripMenuItem.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.soundONOFFToolStripMenuItem.Image = global::PacMan.Properties.Resources.soundON;
            this.soundONOFFToolStripMenuItem.Name = "soundONOFFToolStripMenuItem";
            this.soundONOFFToolStripMenuItem.Size = new System.Drawing.Size(28, 20);
            this.soundONOFFToolStripMenuItem.Click += new System.EventHandler(this.soundONOFFToolStripMenuItem_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(55, 419);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 13);
            this.label1.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Orange;
            this.label2.Location = new System.Drawing.Point(11, 651);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 25);
            this.label2.TabIndex = 4;
            this.label2.Text = "SCORE";
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Orange;
            this.label3.Location = new System.Drawing.Point(103, 651);
            this.label3.Name = "label3";
            this.label3.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label3.Size = new System.Drawing.Size(55, 25);
            this.label3.TabIndex = 5;
            this.label3.Text = "0";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::PacMan.Properties.Resources.pacmanOrangeLeft1;
            this.pictureBox1.Location = new System.Drawing.Point(578, 647);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(32, 29);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 6;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::PacMan.Properties.Resources.pacmanOrangeLeft1;
            this.pictureBox2.Location = new System.Drawing.Point(549, 647);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(32, 29);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 7;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = global::PacMan.Properties.Resources.pacmanOrangeLeft1;
            this.pictureBox3.Location = new System.Drawing.Point(520, 647);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(32, 29);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox3.TabIndex = 8;
            this.pictureBox3.TabStop = false;
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Orange;
            this.label4.Location = new System.Drawing.Point(161, 177);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(316, 216);
            this.label4.TabIndex = 9;
            this.label4.Text = "label4";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label4.Visible = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(631, 688);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.menuStrip1);
            this.ForeColor = System.Drawing.Color.Black;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Form1";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem optionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem restartToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem playlistToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dubThemeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dubTheme2ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem metalToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem soundONOFFToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pauseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.Label label4;
    }
}


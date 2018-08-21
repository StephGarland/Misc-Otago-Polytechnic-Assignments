namespace Pong
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
            System.Windows.Forms.MenuStrip menuStrip1;
            this.optionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.playerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.player1MouseControlsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.player1KeyboardControlsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.difficultyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.easyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mediumToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.hardToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.insanityToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.eXITToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pauseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.colorChangeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ballToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.leftPaddleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rightPaddleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.redToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.yellowToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.greenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.redToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.yellowToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.greenToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.redToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.yellowToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.greenToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.restartToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            menuStrip1 = new System.Windows.Forms.MenuStrip();
            menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            menuStrip1.ImeMode = System.Windows.Forms.ImeMode.Disable;
            menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.optionsToolStripMenuItem,
            this.eXITToolStripMenuItem,
            this.pauseToolStripMenuItem});
            menuStrip1.Location = new System.Drawing.Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Padding = new System.Windows.Forms.Padding(7, 2, 0, 2);
            menuStrip1.Size = new System.Drawing.Size(800, 24);
            menuStrip1.TabIndex = 0;
            menuStrip1.Text = "menuStrip1";
            // 
            // optionsToolStripMenuItem
            // 
            this.optionsToolStripMenuItem.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.optionsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.restartToolStripMenuItem,
            this.playerToolStripMenuItem,
            this.difficultyToolStripMenuItem,
            this.colorChangeToolStripMenuItem});
            this.optionsToolStripMenuItem.Font = new System.Drawing.Font("OCR-A", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.optionsToolStripMenuItem.ForeColor = System.Drawing.SystemColors.Control;
            this.optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
            this.optionsToolStripMenuItem.Size = new System.Drawing.Size(68, 20);
            this.optionsToolStripMenuItem.Text = "Options";
            // 
            // playerToolStripMenuItem
            // 
            this.playerToolStripMenuItem.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.playerToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.player1MouseControlsToolStripMenuItem,
            this.player1KeyboardControlsToolStripMenuItem});
            this.playerToolStripMenuItem.Font = new System.Drawing.Font("OCR-A", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.playerToolStripMenuItem.ForeColor = System.Drawing.SystemColors.Control;
            this.playerToolStripMenuItem.Name = "playerToolStripMenuItem";
            this.playerToolStripMenuItem.Size = new System.Drawing.Size(158, 22);
            this.playerToolStripMenuItem.Text = "2 Player";
            // 
            // player1MouseControlsToolStripMenuItem
            // 
            this.player1MouseControlsToolStripMenuItem.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.player1MouseControlsToolStripMenuItem.ForeColor = System.Drawing.SystemColors.Control;
            this.player1MouseControlsToolStripMenuItem.Name = "player1MouseControlsToolStripMenuItem";
            this.player1MouseControlsToolStripMenuItem.Size = new System.Drawing.Size(263, 22);
            this.player1MouseControlsToolStripMenuItem.Text = "Player1 = Mouse Controls";
            // 
            // player1KeyboardControlsToolStripMenuItem
            // 
            this.player1KeyboardControlsToolStripMenuItem.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.player1KeyboardControlsToolStripMenuItem.ForeColor = System.Drawing.SystemColors.Control;
            this.player1KeyboardControlsToolStripMenuItem.Name = "player1KeyboardControlsToolStripMenuItem";
            this.player1KeyboardControlsToolStripMenuItem.Size = new System.Drawing.Size(263, 22);
            this.player1KeyboardControlsToolStripMenuItem.Text = "Player1 = Keyboard Controls";
            // 
            // difficultyToolStripMenuItem
            // 
            this.difficultyToolStripMenuItem.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.difficultyToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.easyToolStripMenuItem,
            this.mediumToolStripMenuItem,
            this.hardToolStripMenuItem,
            this.insanityToolStripMenuItem});
            this.difficultyToolStripMenuItem.Font = new System.Drawing.Font("OCR-A", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.difficultyToolStripMenuItem.ForeColor = System.Drawing.SystemColors.Control;
            this.difficultyToolStripMenuItem.Name = "difficultyToolStripMenuItem";
            this.difficultyToolStripMenuItem.Size = new System.Drawing.Size(158, 22);
            this.difficultyToolStripMenuItem.Text = "Difficulty";
            // 
            // easyToolStripMenuItem
            // 
            this.easyToolStripMenuItem.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.easyToolStripMenuItem.ForeColor = System.Drawing.SystemColors.Control;
            this.easyToolStripMenuItem.Name = "easyToolStripMenuItem";
            this.easyToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.easyToolStripMenuItem.Text = "Easy";
            // 
            // mediumToolStripMenuItem
            // 
            this.mediumToolStripMenuItem.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.mediumToolStripMenuItem.ForeColor = System.Drawing.SystemColors.Control;
            this.mediumToolStripMenuItem.Name = "mediumToolStripMenuItem";
            this.mediumToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.mediumToolStripMenuItem.Text = "Medium";
            // 
            // hardToolStripMenuItem
            // 
            this.hardToolStripMenuItem.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.hardToolStripMenuItem.ForeColor = System.Drawing.SystemColors.Control;
            this.hardToolStripMenuItem.Name = "hardToolStripMenuItem";
            this.hardToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.hardToolStripMenuItem.Text = "Hard";
            // 
            // insanityToolStripMenuItem
            // 
            this.insanityToolStripMenuItem.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.insanityToolStripMenuItem.ForeColor = System.Drawing.SystemColors.Control;
            this.insanityToolStripMenuItem.Name = "insanityToolStripMenuItem";
            this.insanityToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.insanityToolStripMenuItem.Text = "Insanity";
            // 
            // eXITToolStripMenuItem
            // 
            this.eXITToolStripMenuItem.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.eXITToolStripMenuItem.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.eXITToolStripMenuItem.Font = new System.Drawing.Font("OCR-A", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.eXITToolStripMenuItem.ForeColor = System.Drawing.SystemColors.Control;
            this.eXITToolStripMenuItem.Image = global::Pong.Properties.Resources.redX;
            this.eXITToolStripMenuItem.Name = "eXITToolStripMenuItem";
            this.eXITToolStripMenuItem.Size = new System.Drawing.Size(28, 20);
            this.eXITToolStripMenuItem.Click += new System.EventHandler(this.eXITToolStripMenuItem_Click);
            // 
            // pauseToolStripMenuItem
            // 
            this.pauseToolStripMenuItem.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.pauseToolStripMenuItem.Font = new System.Drawing.Font("OCR-A", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pauseToolStripMenuItem.ForeColor = System.Drawing.SystemColors.Control;
            this.pauseToolStripMenuItem.Image = global::Pong.Properties.Resources.pause;
            this.pauseToolStripMenuItem.Name = "pauseToolStripMenuItem";
            this.pauseToolStripMenuItem.Size = new System.Drawing.Size(28, 20);
            this.pauseToolStripMenuItem.Click += new System.EventHandler(this.pauseToolStripMenuItem_Click);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 1;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // colorChangeToolStripMenuItem
            // 
            this.colorChangeToolStripMenuItem.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.colorChangeToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ballToolStripMenuItem,
            this.leftPaddleToolStripMenuItem,
            this.rightPaddleToolStripMenuItem});
            this.colorChangeToolStripMenuItem.ForeColor = System.Drawing.SystemColors.Control;
            this.colorChangeToolStripMenuItem.Name = "colorChangeToolStripMenuItem";
            this.colorChangeToolStripMenuItem.Size = new System.Drawing.Size(158, 22);
            this.colorChangeToolStripMenuItem.Text = "Color Change";
            // 
            // ballToolStripMenuItem
            // 
            this.ballToolStripMenuItem.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ballToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.redToolStripMenuItem,
            this.yellowToolStripMenuItem,
            this.greenToolStripMenuItem});
            this.ballToolStripMenuItem.ForeColor = System.Drawing.SystemColors.Control;
            this.ballToolStripMenuItem.Name = "ballToolStripMenuItem";
            this.ballToolStripMenuItem.Size = new System.Drawing.Size(158, 22);
            this.ballToolStripMenuItem.Text = "Ball";
            // 
            // leftPaddleToolStripMenuItem
            // 
            this.leftPaddleToolStripMenuItem.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.leftPaddleToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.redToolStripMenuItem1,
            this.yellowToolStripMenuItem1,
            this.greenToolStripMenuItem1});
            this.leftPaddleToolStripMenuItem.ForeColor = System.Drawing.SystemColors.Control;
            this.leftPaddleToolStripMenuItem.Name = "leftPaddleToolStripMenuItem";
            this.leftPaddleToolStripMenuItem.Size = new System.Drawing.Size(158, 22);
            this.leftPaddleToolStripMenuItem.Text = "Left Paddle";
            // 
            // rightPaddleToolStripMenuItem
            // 
            this.rightPaddleToolStripMenuItem.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.rightPaddleToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.redToolStripMenuItem2,
            this.yellowToolStripMenuItem2,
            this.greenToolStripMenuItem2});
            this.rightPaddleToolStripMenuItem.ForeColor = System.Drawing.SystemColors.Control;
            this.rightPaddleToolStripMenuItem.Name = "rightPaddleToolStripMenuItem";
            this.rightPaddleToolStripMenuItem.Size = new System.Drawing.Size(158, 22);
            this.rightPaddleToolStripMenuItem.Text = "Right Paddle";
            // 
            // redToolStripMenuItem
            // 
            this.redToolStripMenuItem.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.redToolStripMenuItem.ForeColor = System.Drawing.SystemColors.Control;
            this.redToolStripMenuItem.Name = "redToolStripMenuItem";
            this.redToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.redToolStripMenuItem.Text = "Red";
            this.redToolStripMenuItem.Click += new System.EventHandler(this.redToolStripMenuItem_Click);
            // 
            // yellowToolStripMenuItem
            // 
            this.yellowToolStripMenuItem.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.yellowToolStripMenuItem.ForeColor = System.Drawing.SystemColors.Control;
            this.yellowToolStripMenuItem.Name = "yellowToolStripMenuItem";
            this.yellowToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.yellowToolStripMenuItem.Text = "Yellow";
            this.yellowToolStripMenuItem.Click += new System.EventHandler(this.yellowToolStripMenuItem_Click);
            // 
            // greenToolStripMenuItem
            // 
            this.greenToolStripMenuItem.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.greenToolStripMenuItem.ForeColor = System.Drawing.SystemColors.Control;
            this.greenToolStripMenuItem.Name = "greenToolStripMenuItem";
            this.greenToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.greenToolStripMenuItem.Text = "Green";
            this.greenToolStripMenuItem.Click += new System.EventHandler(this.greenToolStripMenuItem_Click);
            // 
            // redToolStripMenuItem1
            // 
            this.redToolStripMenuItem1.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.redToolStripMenuItem1.ForeColor = System.Drawing.SystemColors.Control;
            this.redToolStripMenuItem1.Name = "redToolStripMenuItem1";
            this.redToolStripMenuItem1.Size = new System.Drawing.Size(152, 22);
            this.redToolStripMenuItem1.Text = "Red";
            // 
            // yellowToolStripMenuItem1
            // 
            this.yellowToolStripMenuItem1.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.yellowToolStripMenuItem1.ForeColor = System.Drawing.SystemColors.Control;
            this.yellowToolStripMenuItem1.Name = "yellowToolStripMenuItem1";
            this.yellowToolStripMenuItem1.Size = new System.Drawing.Size(152, 22);
            this.yellowToolStripMenuItem1.Text = "Yellow";
            // 
            // greenToolStripMenuItem1
            // 
            this.greenToolStripMenuItem1.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.greenToolStripMenuItem1.ForeColor = System.Drawing.SystemColors.Control;
            this.greenToolStripMenuItem1.Name = "greenToolStripMenuItem1";
            this.greenToolStripMenuItem1.Size = new System.Drawing.Size(152, 22);
            this.greenToolStripMenuItem1.Text = "Green";
            // 
            // redToolStripMenuItem2
            // 
            this.redToolStripMenuItem2.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.redToolStripMenuItem2.ForeColor = System.Drawing.SystemColors.Control;
            this.redToolStripMenuItem2.Name = "redToolStripMenuItem2";
            this.redToolStripMenuItem2.Size = new System.Drawing.Size(152, 22);
            this.redToolStripMenuItem2.Text = "Red";
            // 
            // yellowToolStripMenuItem2
            // 
            this.yellowToolStripMenuItem2.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.yellowToolStripMenuItem2.ForeColor = System.Drawing.SystemColors.Control;
            this.yellowToolStripMenuItem2.Name = "yellowToolStripMenuItem2";
            this.yellowToolStripMenuItem2.Size = new System.Drawing.Size(152, 22);
            this.yellowToolStripMenuItem2.Text = "Yellow";
            // 
            // greenToolStripMenuItem2
            // 
            this.greenToolStripMenuItem2.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.greenToolStripMenuItem2.ForeColor = System.Drawing.SystemColors.Control;
            this.greenToolStripMenuItem2.Name = "greenToolStripMenuItem2";
            this.greenToolStripMenuItem2.Size = new System.Drawing.Size(152, 22);
            this.greenToolStripMenuItem2.Text = "Green";
            // 
            // restartToolStripMenuItem
            // 
            this.restartToolStripMenuItem.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.restartToolStripMenuItem.ForeColor = System.Drawing.SystemColors.Control;
            this.restartToolStripMenuItem.Name = "restartToolStripMenuItem";
            this.restartToolStripMenuItem.Size = new System.Drawing.Size(158, 22);
            this.restartToolStripMenuItem.Text = "Restart";
            this.restartToolStripMenuItem.Click += new System.EventHandler(this.restartToolStripMenuItem_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ClientSize = new System.Drawing.Size(800, 600);
            this.Controls.Add(menuStrip1);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("OCR-A", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MainMenuStrip = menuStrip1;
            this.Name = "Form1";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Pong";
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Form1_Paint);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseMove);
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStripMenuItem optionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem playerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem difficultyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem easyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mediumToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem hardToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem insanityToolStripMenuItem;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.ToolStripMenuItem pauseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem eXITToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem player1KeyboardControlsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem player1MouseControlsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem colorChangeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ballToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem redToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem yellowToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem greenToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem leftPaddleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem redToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem yellowToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem greenToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem rightPaddleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem redToolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem yellowToolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem greenToolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem restartToolStripMenuItem;
    }
}


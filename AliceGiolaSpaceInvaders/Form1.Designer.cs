namespace AliceGiolaSpaceInvaders
{
    partial class Form1
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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            pctTitle = new PictureBox();
            pctStart = new PictureBox();
            pctRP1 = new PictureBox();
            timer1 = new System.Windows.Forms.Timer(components);
            pctBlack = new PictureBox();
            timer2 = new System.Windows.Forms.Timer(components);
            timer3 = new System.Windows.Forms.Timer(components);
            timer4 = new System.Windows.Forms.Timer(components);
            pctSkip = new PictureBox();
            pctAlienA = new PictureBox();
            timer5 = new System.Windows.Forms.Timer(components);
            timer6 = new System.Windows.Forms.Timer(components);
            lblScore = new Label();
            lblScoreboardTitle = new Label();
            lblScoreboard = new Label();
            timer7 = new System.Windows.Forms.Timer(components);
            pctGameOver = new PictureBox();
            btnYes = new Button();
            btnNo = new Button();
            pctQuestionmark = new PictureBox();
            pctYouWin = new PictureBox();
            pctPlayAgain = new PictureBox();
            lblStoryline = new Label();
            ((System.ComponentModel.ISupportInitialize)pctTitle).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pctStart).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pctRP1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pctBlack).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pctSkip).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pctAlienA).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pctGameOver).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pctQuestionmark).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pctYouWin).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pctPlayAgain).BeginInit();
            SuspendLayout();
            // 
            // pctTitle
            // 
            pctTitle.Image = (Image)resources.GetObject("pctTitle.Image");
            pctTitle.Location = new Point(293, 12);
            pctTitle.Name = "pctTitle";
            pctTitle.Size = new Size(652, 300);
            pctTitle.SizeMode = PictureBoxSizeMode.Zoom;
            pctTitle.TabIndex = 0;
            pctTitle.TabStop = false;
            pctTitle.Click += pctTitle_Click;
            // 
            // pctStart
            // 
            pctStart.Image = (Image)resources.GetObject("pctStart.Image");
            pctStart.Location = new Point(332, 123);
            pctStart.Name = "pctStart";
            pctStart.Size = new Size(742, 339);
            pctStart.SizeMode = PictureBoxSizeMode.Zoom;
            pctStart.TabIndex = 1;
            pctStart.TabStop = false;
            pctStart.Click += pctStart_Click;
            // 
            // pctRP1
            // 
            pctRP1.BackColor = Color.Transparent;
            pctRP1.Image = Properties.Resources.ReadyPlayerOne21;
            pctRP1.Location = new Point(977, 12);
            pctRP1.Name = "pctRP1";
            pctRP1.Size = new Size(633, 565);
            pctRP1.SizeMode = PictureBoxSizeMode.CenterImage;
            pctRP1.TabIndex = 2;
            pctRP1.TabStop = false;
            // 
            // timer1
            // 
            timer1.Interval = 900;
            timer1.Tick += timer1_Tick;
            // 
            // pctBlack
            // 
            pctBlack.BackColor = Color.Black;
            pctBlack.Image = Properties.Resources.Black;
            pctBlack.Location = new Point(664, -465);
            pctBlack.Name = "pctBlack";
            pctBlack.Size = new Size(628, 563);
            pctBlack.SizeMode = PictureBoxSizeMode.Zoom;
            pctBlack.TabIndex = 3;
            pctBlack.TabStop = false;
            // 
            // timer2
            // 
            timer2.Interval = 4000;
            timer2.Tick += timer2_Tick;
            // 
            // timer3
            // 
            timer3.Interval = 3000;
            timer3.Tick += timer3_Tick;
            // 
            // timer4
            // 
            timer4.Interval = 1000;
            timer4.Tick += timer4_Tick;
            // 
            // pctSkip
            // 
            pctSkip.BackColor = Color.Transparent;
            pctSkip.Image = (Image)resources.GetObject("pctSkip.Image");
            pctSkip.Location = new Point(210, 445);
            pctSkip.Name = "pctSkip";
            pctSkip.Size = new Size(213, 84);
            pctSkip.SizeMode = PictureBoxSizeMode.Zoom;
            pctSkip.TabIndex = 7;
            pctSkip.TabStop = false;
            pctSkip.Click += pctSkip_Click;
            // 
            // pctAlienA
            // 
            pctAlienA.Image = Properties.Resources.Alien1;
            pctAlienA.Location = new Point(50, 337);
            pctAlienA.Name = "pctAlienA";
            pctAlienA.Size = new Size(208, 199);
            pctAlienA.TabIndex = 8;
            pctAlienA.TabStop = false;
            // 
            // timer5
            // 
            timer5.Interval = 20;
            timer5.Tick += timer5_Tick;
            // 
            // timer6
            // 
            timer6.Interval = 1000;
            timer6.Tick += timer6_Tick;
            // 
            // lblScore
            // 
            lblScore.AutoSize = true;
            lblScore.Font = new Font("Microsoft Sans Serif", 24F, FontStyle.Regular, GraphicsUnit.Point);
            lblScore.ForeColor = Color.Yellow;
            lblScore.Location = new Point(143, 18);
            lblScore.Name = "lblScore";
            lblScore.Size = new Size(100, 37);
            lblScore.TabIndex = 10;
            lblScore.Text = "label1";
            // 
            // lblScoreboardTitle
            // 
            lblScoreboardTitle.AutoSize = true;
            lblScoreboardTitle.Font = new Font("Impact", 60F, FontStyle.Regular, GraphicsUnit.Point);
            lblScoreboardTitle.ForeColor = Color.Yellow;
            lblScoreboardTitle.Location = new Point(71, 86);
            lblScoreboardTitle.Name = "lblScoreboardTitle";
            lblScoreboardTitle.Size = new Size(239, 98);
            lblScoreboardTitle.TabIndex = 11;
            lblScoreboardTitle.Text = "label1";
            // 
            // lblScoreboard
            // 
            lblScoreboard.AutoSize = true;
            lblScoreboard.Font = new Font("Cascadia Code", 36F, FontStyle.Bold, GraphicsUnit.Point);
            lblScoreboard.ForeColor = Color.Yellow;
            lblScoreboard.ImageAlign = ContentAlignment.TopCenter;
            lblScoreboard.Location = new Point(107, 231);
            lblScoreboard.Name = "lblScoreboard";
            lblScoreboard.Size = new Size(195, 63);
            lblScoreboard.TabIndex = 12;
            lblScoreboard.Text = "label1";
            // 
            // timer7
            // 
            timer7.Interval = 2000;
            timer7.Tick += timer7_Tick;
            // 
            // pctGameOver
            // 
            pctGameOver.Image = Properties.Resources.GameOverTryAgain;
            pctGameOver.Location = new Point(429, 61);
            pctGameOver.Name = "pctGameOver";
            pctGameOver.Size = new Size(490, 516);
            pctGameOver.TabIndex = 14;
            pctGameOver.TabStop = false;
            // 
            // btnYes
            // 
            btnYes.BackColor = Color.Black;
            btnYes.BackgroundImage = Properties.Resources.Yes2;
            btnYes.BackgroundImageLayout = ImageLayout.Zoom;
            btnYes.FlatAppearance.BorderSize = 0;
            btnYes.FlatStyle = FlatStyle.Flat;
            btnYes.ForeColor = Color.Transparent;
            btnYes.Location = new Point(78, 388);
            btnYes.Name = "btnYes";
            btnYes.Size = new Size(205, 74);
            btnYes.TabIndex = 15;
            btnYes.TabStop = false;
            btnYes.UseVisualStyleBackColor = false;
            btnYes.Click += btnYes_Click;
            // 
            // btnNo
            // 
            btnNo.BackColor = Color.Black;
            btnNo.BackgroundImage = Properties.Resources.No2;
            btnNo.BackgroundImageLayout = ImageLayout.Zoom;
            btnNo.FlatAppearance.BorderSize = 0;
            btnNo.FlatStyle = FlatStyle.Flat;
            btnNo.Location = new Point(78, 468);
            btnNo.Name = "btnNo";
            btnNo.Size = new Size(191, 74);
            btnNo.TabIndex = 16;
            btnNo.TabStop = false;
            btnNo.UseVisualStyleBackColor = false;
            btnNo.Click += btnNo_Click;
            // 
            // pctQuestionmark
            // 
            pctQuestionmark.Image = Properties.Resources.Questionmark;
            pctQuestionmark.Location = new Point(8, 8);
            pctQuestionmark.Name = "pctQuestionmark";
            pctQuestionmark.Size = new Size(49, 46);
            pctQuestionmark.SizeMode = PictureBoxSizeMode.Zoom;
            pctQuestionmark.TabIndex = 17;
            pctQuestionmark.TabStop = false;
            // 
            // pctYouWin
            // 
            pctYouWin.Image = Properties.Resources.YouWin;
            pctYouWin.Location = new Point(18, 248);
            pctYouWin.Name = "pctYouWin";
            pctYouWin.Size = new Size(613, 294);
            pctYouWin.SizeMode = PictureBoxSizeMode.Zoom;
            pctYouWin.TabIndex = 18;
            pctYouWin.TabStop = false;
            // 
            // pctPlayAgain
            // 
            pctPlayAgain.Image = (Image)resources.GetObject("pctPlayAgain.Image");
            pctPlayAgain.Location = new Point(24, 143);
            pctPlayAgain.Name = "pctPlayAgain";
            pctPlayAgain.Size = new Size(419, 239);
            pctPlayAgain.SizeMode = PictureBoxSizeMode.Zoom;
            pctPlayAgain.TabIndex = 19;
            pctPlayAgain.TabStop = false;
            // 
            // lblStoryline
            // 
            lblStoryline.Dock = DockStyle.Fill;
            lblStoryline.Font = new Font("Sylfaen", 39F, FontStyle.Regular, GraphicsUnit.Point);
            lblStoryline.Location = new Point(0, 0);
            lblStoryline.Name = "lblStoryline";
            lblStoryline.Size = new Size(1060, 619);
            lblStoryline.TabIndex = 13;
            lblStoryline.Text = "label1";
            lblStoryline.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSizeMode = AutoSizeMode.GrowAndShrink;
            BackColor = Color.Black;
            ClientSize = new Size(1060, 619);
            Controls.Add(pctYouWin);
            Controls.Add(pctQuestionmark);
            Controls.Add(btnNo);
            Controls.Add(btnYes);
            Controls.Add(lblScoreboard);
            Controls.Add(lblScoreboardTitle);
            Controls.Add(lblScore);
            Controls.Add(pctAlienA);
            Controls.Add(pctSkip);
            Controls.Add(pctBlack);
            Controls.Add(pctTitle);
            Controls.Add(pctRP1);
            Controls.Add(pctStart);
            Controls.Add(pctGameOver);
            Controls.Add(lblStoryline);
            Controls.Add(pctPlayAgain);
            DoubleBuffered = true;
            ForeColor = Color.White;
            MinimumSize = new Size(800, 600);
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Space Invaders";
            Load += Form1_Load;
            KeyDown += Form1_KeyDown;
            KeyUp += Form1_KeyUp;
            ((System.ComponentModel.ISupportInitialize)pctTitle).EndInit();
            ((System.ComponentModel.ISupportInitialize)pctStart).EndInit();
            ((System.ComponentModel.ISupportInitialize)pctRP1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pctBlack).EndInit();
            ((System.ComponentModel.ISupportInitialize)pctSkip).EndInit();
            ((System.ComponentModel.ISupportInitialize)pctAlienA).EndInit();
            ((System.ComponentModel.ISupportInitialize)pctGameOver).EndInit();
            ((System.ComponentModel.ISupportInitialize)pctQuestionmark).EndInit();
            ((System.ComponentModel.ISupportInitialize)pctYouWin).EndInit();
            ((System.ComponentModel.ISupportInitialize)pctPlayAgain).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pctTitle;
        private PictureBox pctStart;
        private PictureBox pctRP1;
        private System.Windows.Forms.Timer timer1;
        private PictureBox pctBlack;
        private System.Windows.Forms.Timer timer2;
        private System.Windows.Forms.Timer timer3;
        private System.Windows.Forms.Timer timer4;
        private PictureBox pctSkip;
        private PictureBox pctAlienA;
        private System.Windows.Forms.Timer timer5;
        private System.Windows.Forms.Timer timer6;
        private Label lblScore;
        private Label lblScoreboardTitle;
        private Label lblScoreboard;
        private System.Windows.Forms.Timer timer7;
        private PictureBox pctGameOver;
        private Button btnYes;
        private Button btnNo;
        private PictureBox pctQuestionmark;
        private PictureBox pctYouWin;
        private PictureBox pctPlayAgain;
        private Label lblStoryline;
    }
}
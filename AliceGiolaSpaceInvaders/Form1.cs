// Alice Giola
// Space Invaders Final Project
// CS 2263
// 07/6/2023

using System.Diagnostics;
using System.Security.Cryptography;
using System.Windows.Forms;

namespace AliceGiolaSpaceInvaders
{
    public partial class Form1 : Form
    {
        #region global variables
        // Form and visuals
        private const int FormWidth = 800;
        private const int FormHeight = 800;
        private const int PlayerWidth = 60;
        private const int PlayerHeight = 60;
        private const int InvaderColumns = 10;
        private const int InvaderRows = 4;
        private const int InvaderSpacing = 10;
        public int screenWidth, screenHeight;
        public int maxscore = 1000;
        public HUD HUD = new HUD();
        Slot slot;
        Designer designer;
        Storyline sl = new Storyline();

        // Controls
        private const int ProjectileSpeed = 5;
        public bool canShoot = true;
        public bool invaderAttack = true;
        public bool left, right, shoot;
        Random rnd = new Random();

        // Players, invaders, projectiles
        public Player player;
        public List<Player> players = new List<Player>();
        public int playersn;
        public List<Invader> invaders;
        public List<Projectile> playerProjectiles;
        public List<Projectile> invaderProjectiles;
        public List<Projectile> projectiles = new List<Projectile>();
        public int score;

        // Music
        System.Media.SoundPlayer music = new System.Media.SoundPlayer();
        #endregion

        public Form1()
        {
            InitializeComponent();
        }
        
        private void Form1_Load(object sender, EventArgs e)
        {
            openMenu();
        }

        #region game menu
        // openMenu: opens up the game menu
        public void openMenu()
        {
            // Visuals
            sl = new Storyline();
            this.WindowState = FormWindowState.Maximized;
            screenWidth = this.Width;
            screenHeight = this.Height;
            slot = new Slot(this.Width, this.Height);
            designer = new Designer(slot);
            ClientSize = new Size(this.Width, this.Height);
            DoubleBuffered = true;
            pctTitle.Visible = true;
            pctStart.Visible = true;
            pctBlack.Visible = true;
            lblScoreboardTitle.Visible = true;
            lblScoreboard.Visible = true;
            pctRP1.Visible = false;
            lblStoryline.Visible = false;
            pctSkip.Visible = false;
            pctAlienA.Visible = false;
            lblScore.Visible = false;
            pctGameOver.Visible = false;
            btnYes.Visible = false;
            btnNo.Visible = false;
            pctQuestionmark.Visible = false;
            pctYouWin.Visible = false;
            pctPlayAgain.Visible = false;
            pctTitle.Location = new Point(designer.getCenterX() - pctTitle.Width / 2, designer.getOneThirdY() - 250);
            pctStart.Location = new Point(designer.getCenterX() - pctStart.Width / 2, designer.getOneThirdY() * 2 - 470);
            pctBlack.Location = new Point(pctStart.Location.Y - 100, pctStart.Location.X);
            lblScoreboardTitle.Location = new Point(designer.getCenterX() - 230, designer.getCenterY() + 130);

            // Music
            music.SoundLocation = "Menu.WAV";
            music.Play();

            // Scoreboard
            lblScoreboardTitle.Text = "SCOREBOARD";
            Scoreboard sb = new Scoreboard(players);
            DisplayScoreboard sbformatted = new DisplayScoreboard(sb.getScoreboard());
            lblScoreboard.Text = "";
            if (players.Count > 0)
            {
                lblScoreboard.Text = sbformatted.getScoreboard();
                lblScoreboard.Location = new Point(designer.getCenterX() - 355, designer.getOneThirdY() * 2);
            }
        }
        #endregion

        #region start
        // Start: when start button is clicked, starts the game
        private void pctStart_Click(object sender, EventArgs e)
        {
            // Visuals
            pctBlack.Visible = false;
            pctTitle.Visible = false;
            pctStart.Visible = false;
            lblScoreboard.Visible = false;
            lblScoreboardTitle.Visible = false;

            // Music
            music.Stop();

            // Asks user for name
            string name = Microsoft.VisualBasic.Interaction.InputBox("What is your name, cadet?").ToString();
            while (name.Length > 12 ^ name.Length == 0)
            {
                name = Microsoft.VisualBasic.Interaction.InputBox("Please enter a name with 12 characters or less.").ToString();
            }

            // If player is new, displays storyline, otherwise shows RP1 screen
            
            if (players.Any(p => p.name == name))
            {
                Player p = players.Find(p => p.name == name);
                player = p;
                Controls.Add(player.PlayerPicture);
                player.PlayerPicture.Visible = false;
                RP1();
            }
            else
            {
                Player p = new Player(name, FormWidth / 2 - (PlayerWidth/2 + PlayerWidth/4 + 3), FormHeight - PlayerHeight - 100);
                players.Add(p);
                playersn++;
                player = p;
                Controls.Add(player.PlayerPicture);
                player.PlayerPicture.Visible = false;
                sl.setName(name);
                lblStoryline.Visible = true;
                pctSkip.Visible = true;
                pctSkip.Location = new Point(designer.getLastX() - 20, designer.getLastY() - 30);
                lblStoryline.Location = new Point(designer.getCenterX() - 286, designer.getCenterY() - 128);
                lblStoryline.Text = sl.storyline[0];
                sl.storyline.RemoveAt(0);
                timer3.Start();
            }
        }
        #endregion

        #region timers
        private void timer1_Tick(object sender, EventArgs e)
        {
            pctBlack.Location = new Point(designer.getCenterX() - 314, pctBlack.Location.Y + 110);
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            timer1.Stop();
            timer2.Stop();
            pctRP1.Visible = false;
            pctBlack.Visible = false;
            InitializeGame();
        }

        private void timer3_Tick(object sender, EventArgs e)
        {
            if (sl.storyline.Count != 0)
            {
                displayStoryline();
            }
            else
            {
                timer3.Stop();
                lblStoryline.Visible = false;
                timer4.Start();
            }
        }

        private void timer4_Tick(object sender, EventArgs e)
        {
            timer4.Stop();
            RP1();
        }

        // timer5: main game timer, runs every 20 milliseconds to update the game screen, activate controls, and check for collisions
        private void timer5_Tick(object sender, EventArgs e)
        {
            // Update score
            lblScore.Text = "SCORE: " + score;
            lblScore.Location = new Point(FormWidth / 2 - lblScore.Width / 2, FormHeight - 100);

            // Update player and invaders movements and controls
            playerControls();

            for (int i = 0; i < invaders.Count; i++)
            {
                invaders[i].Move();
            }

            if (invaderAttack)
            {
                invadersAttack();
            }

            // Update projectiles
            foreach (PlayerProjectile projectile in playerProjectiles)
            {
                projectile.Move();
            }
            foreach (InvaderProjectile projectile in invaderProjectiles)
            {
                projectile.Move();
            }

            // Check for collisions
            CheckCollisions();

            // Redraw sreen
            Invalidate();
        }

        private void timer6_Tick(object sender, EventArgs e)
        {
            canShoot = true;
        }

        private void timer7_Tick(object sender, EventArgs e)
        {
            invaderAttack = true;
        }
        #endregion

        #region pre-game screens
        // displayStoryline: displays the storyline to new players
        public void displayStoryline()
        {
            if (sl.storyline.Count != 0)
            {
                string s = sl.storyline[0];
                if (s.Length > 43)
                {
                    timer3.Interval = 4250;
                }
                else if (s.Length < 27)
                {
                    timer3.Interval = 2000;
                }
                else
                {
                    timer3.Interval = 2400;
                }
                lblStoryline.Text = s;
                sl.storyline.RemoveAt(0);
            }
            else
            {
                timer3.Stop();
                lblStoryline.Visible = false;
                timer4.Start();
            }
        }

        // Skip: skips storyline when skip button is pressed
        private void pctSkip_Click(object sender, EventArgs e)
        {
            pctSkip.Visible = false;
            timer3.Stop();
            RP1();
        }

        // RP1: displays the "ready player one?" screen
        public void RP1()
        {
            lblStoryline.Visible = false;
            pctSkip.Visible = false;
            pctRP1.Visible = true;
            pctRP1.Location = new Point(designer.getCenterX() - 317, designer.getCenterY() - 283);
            pctBlack.Visible = true;
            pctBlack.Location = new Point(designer.getCenterX() - 314, designer.getCenterY() - 45);
            timer1.Start();
            timer2.Start();
        }
        #endregion

        #region set up game
        // InitializeGame: displays controls and tips messagebox and creates the game screen
        private void InitializeGame()
        {
            // Show controls and tips
            MessageBox.Show("Press A and D to move left and right\nSpacebar to shoot\nAvoid enemy projectiles to survive\nKill all the invaders before they reach you to win!\n\nPRO TIPS:\nGreen projectiles will not kill you but reset your score\nYou will need to hit pink invaders twice before you can kill them");

            // Resize the window
            this.Location = new Point(screenWidth / 2 - FormWidth / 2, screenHeight / 2 - FormHeight / 2);
            this.WindowState = FormWindowState.Normal;
            this.StartPosition= FormStartPosition.Manual;
            this.Height = FormHeight;
            this.Width = FormWidth;

            // Show score
            score = 0;
            lblScore.Visible = true;
            lblScore.Location = new Point(FormWidth / 2 - lblScore.Width/2, FormHeight - 100);
            lblScore.Text = HUD.score + score;

            // Create invaders
            invaders = new List<Invader>();
            InvaderArmy army = new InvaderArmy();
            for (int row = 0; row < InvaderRows; row++)
            {
                // Pink invaders
                if (row == 0)
                {
                    for (int column = 0; column < InvaderColumns; column++)
                    {
                        int x = column * (Invader.InvaderWidth + InvaderSpacing);
                        int y = row * (Invader.InvaderHeight + InvaderSpacing) + 50;
                        InvaderP invader = new InvaderP(x, y, army);
                        invaders.Add(invader);
                        Controls.Add(invader.InvaderPicture);
                    }
                }
                // Green invaders
                else if (row == 1)
                {
                    for (int column = 0; column < InvaderColumns; column++)
                    {
                        int x = column * (Invader.InvaderWidth + InvaderSpacing);
                        int y = row * (Invader.InvaderHeight + InvaderSpacing) + 50;
                        InvaderG invader = new InvaderG(x, y, army);
                        invaders.Add(invader);
                        Controls.Add(invader.InvaderPicture);
                    }
                }
                // White invaders
                else
                {
                    for (int column = 0; column < InvaderColumns; column++)
                    {
                        int x = column * (Invader.InvaderWidth + InvaderSpacing);
                        int y = row * (Invader.InvaderHeight + InvaderSpacing) + 50;
                        InvaderW invader = new InvaderW(x, y, army);
                        invaders.Add(invader);
                        Controls.Add(invader.InvaderPicture);
                    }
                }
            }
            army.setInvaders(invaders);

            // Create player
            player.PlayerPicture.Visible = true;

            // Initialize projectile lists
            playerProjectiles = new List<Projectile>();
            invaderProjectiles= new List<Projectile>();

            // Start game loop
            timer5.Start();
        }



        #endregion

        #region game
        // CheckCollisions: checks for collisions
        private void CheckCollisions()
        {
            // Useful variables
            List<Projectile> projectilesToRemove = new List<Projectile>();
            List<Invader> invaderToRemove = new List<Invader>();
            List<Player> playersToRemove = new List<Player>();
            bool pdestroyed = false;
            List<PlayerProjectile> pprojectilesToRemove = new List<PlayerProjectile>();
            List<InvaderProjectile> iprojectilesToRemove = new List<InvaderProjectile>();
            InvaderArmy test = new InvaderArmy();
            InvaderP pink = new InvaderP(0, 0, test);
            pink.InvaderPicture.Visible = false;

            // Player-invader collisions, ends game if a collision is detected
            foreach (Invader invader in invaders)
            {
                if (!invader.IsDestroyed && invader.InvaderPicture.Bounds.IntersectsWith(player.PlayerPicture.Bounds))
                {
                    timer5.Stop();
                    player.setRecord(score);
                    foreach (Player p in players)
                    {
                        if (p.name == player.name)
                        {
                            playersToRemove.Add(p);
                        }
                    }
                    foreach (Player p in playersToRemove)
                    {
                        players.Remove(p);
                    }
                    players.Add(player);
                    gameOver();
                    break;
                }
            }

            // Player projectile-projectile collisions, destroys both projectiles if collision is detected
            foreach (PlayerProjectile pprojectile in playerProjectiles)
            {
                foreach (InvaderProjectile iprojectile in invaderProjectiles)
                {
                    
                    if (pprojectile.ProjectilePicture.Bounds.IntersectsWith(iprojectile.ProjectilePicture.Bounds))
                    {
                        pdestroyed = true;
                        music.SoundLocation = "explosion.WAV";
                        music.Play();
                        pprojectile.Destroy();
                        iprojectile.Destroy();
                        pprojectilesToRemove.Add(pprojectile);
                        iprojectilesToRemove.Add(iprojectile);
                    }
                }
            }

            if (pdestroyed)
            {
                playerProjectiles.Remove(pprojectilesToRemove[0]);
                pprojectilesToRemove.RemoveAt(0);
                invaderProjectiles.Remove(iprojectilesToRemove[0]);
                iprojectilesToRemove.RemoveAt(0);
            }

            // Player projectile-invader collisions, kills invader and destroys projectile if collision is detected
            foreach (PlayerProjectile projectile in playerProjectiles)
            {
                bool projectileDestroyed = false;
                foreach (Invader invader in invaders)
                {
                    if (!invader.IsDestroyed && projectile.ProjectilePicture.Bounds.IntersectsWith(invader.InvaderPicture.Bounds))
                    {
                        if (invader.GetType() == pink.GetType())
                        {
                            // If the invader is of type pink and has never been hit, doesn't kill it but sets candie to true and plays a different sound
                            if (invader.candie == false)
                            {
                                invader.candie = true;
                                projectile.Destroy();
                                projectileDestroyed = true;
                                music.SoundLocation = "invaderkilled.WAV";
                                music.Play();
                                break;
                            }
                            else
                            {
                                invader.Destroy();
                                invaderToRemove.Add(invader);
                                projectile.Destroy();
                                projectileDestroyed = true;
                                score += invader.points;
                                music.SoundLocation = "explosion.WAV";
                                music.Play();
                                break;
                            }
                        }

                        else
                        {
                            invader.Destroy();
                            invaderToRemove.Add(invader);
                            projectile.Destroy();
                            projectileDestroyed = true;
                            score += invader.points;
                            music.SoundLocation = "explosion.WAV";
                            music.Play();
                            break;
                        }
                    }
                }

                if (projectileDestroyed)
                {
                    projectilesToRemove.Add(projectile);

                    if (invaderToRemove.Count != 0)
                    {
                        invaders.Remove(invaderToRemove[0]);
                        invaderToRemove.RemoveAt(0);
                    }
                }
            }

            // Projectile-bottom/top collisions, destroys projectile if collision is detected
            foreach (Projectile projectile in projectiles)
            {
                // Check victory condition
                if (invaders.Count <= 0)
                {
                    timer5.Stop();
                    player.setRecord(score);
                    foreach (Player p in players)
                    {
                        if (p.name == player.name)
                        {
                            playersToRemove.Add(p);
                        }
                    }
                    foreach (Player p in playersToRemove)
                    {
                        players.Remove(p);
                    }
                    players.Add(player);
                    youWin();
                    break;
                }
                
                if (projectile.ProjectilePicture.Top <= invaders.MinBy(o=>o.InvaderPicture.Top).InvaderPicture.Top || projectile.ProjectilePicture.Bottom >= ClientSize.Height - 50)
                {
                    projectile.Destroy();
                    projectilesToRemove.Add(projectile);
                    if (playerProjectiles.Contains(projectile))
                    {
                        playerProjectiles.Remove(projectile);
                    }
                    else if (invaderProjectiles.Contains(projectile))
                    {
                        invaderProjectiles.Remove(projectile);
                    }
                }
            }

            // Invader projectile-player collisions, ends game if collision is detected
            foreach (InvaderProjectile projectile in invaderProjectiles)
            {
                if (projectile.ProjectilePicture.Bounds.IntersectsWith(player.PlayerPicture.Bounds))
                {
                    // If projectile is of type green, doesn't end game but resets score
                    if (projectile.greenprojectile)
                    {
                        score = 0;
                    }
                    else
                    {
                        timer5.Stop();
                        music.SoundLocation = "explosion.WAV";
                        music.Play();
                        player.setRecord(score);
                        foreach (Player p in players)
                        {
                            if (p.name == player.name)
                            {
                                playersToRemove.Add(p);
                            }
                        }
                        foreach (Player p in playersToRemove)
                        {
                            players.Remove(p);
                        }
                        players.Add(player);
                        gameOver();
                        break;
                    }
                }
            }

            foreach (Projectile projectileToRemove in projectilesToRemove)
            {
                playerProjectiles.Remove(projectileToRemove);
                invaderProjectiles.Remove(projectileToRemove);
            }

            // Invader-bottom collisions, ends game if collision is detected
            foreach (Invader invader in invaders)
            {
                if (!invader.IsDestroyed && invader.InvaderPicture.Location.Y >= 700)
                {
                    timer5.Stop();
                    player.setRecord(score);
                    foreach (Player p in players)
                    {
                        if (p.name == player.name)
                        {
                            playersToRemove.Add(p);
                        }
                    }
                    foreach (Player p in playersToRemove)
                    {
                        players.Remove(p);
                    }
                    players.Add(player);
                    gameOver();
                    break;
                }
            }

        }

        // playerControls: activates player controls
        public void playerControls()
        {
            if (left && !right) { player.MoveLeft(); }
            if (right && !left) { player.MoveRight(); }
            if (shoot && canShoot && playerProjectiles.Count < 4)
            {
                int projectileX = player.PlayerPicture.Left + PlayerWidth / 2 - PlayerProjectile.ProjectileWidth / 2;
                int projectileY = player.PlayerPicture.Top - PlayerProjectile.ProjectileHeight;
                PlayerProjectile projectile = new PlayerProjectile(projectileX, projectileY);
                playerProjectiles.Add(projectile);
                projectiles.Add(projectile);
                Controls.Add(projectile.ProjectilePicture);
                canShoot = false;
                music.SoundLocation = "shoot.WAV";
                music.Play();
                timer6.Start();
            }

        }

        // invadersAttack: controls the invaders attack
        public void invadersAttack()
        {
            InvaderArmy test = new InvaderArmy();
            InvaderG green = new InvaderG(0, 0, test);
            green.InvaderPicture.Visible = false;
            invaderAttack = false;
            timer7.Start();
            int invaderindex = rnd.Next(invaders.Count);
            Invader attackingInvader = invaders[invaderindex];
            int projectileX = attackingInvader.InvaderPicture.Left + attackingInvader.InvaderPicture.Width / 2 - InvaderProjectile.ProjectileWidth / 2;
            int projectileY = attackingInvader.InvaderPicture.Top - InvaderProjectile.ProjectileHeight;
            InvaderProjectile invaderProjectile = new InvaderProjectile(projectileX, projectileY);
            if (attackingInvader.GetType() == green.GetType())
            {
                invaderProjectile.isGreen();
            }
            invaderProjectiles.Add(invaderProjectile);
            projectiles.Add(invaderProjectile);
            Controls.Add(invaderProjectile.ProjectilePicture);
        }

        // gameOver: displays game over screen
        public void gameOver()
        {
            // Visuals
            foreach (Invader invader in invaders)
            {
                invader.InvaderPicture.Visible = false;
            }

            foreach (Projectile projectile in projectiles)
            {
                projectile.ProjectilePicture.Visible = false;
            }

            player.PlayerPicture.Visible = false;
            lblScore.Visible = false;
            pctGameOver.Visible = true;
            pctGameOver.SizeMode = PictureBoxSizeMode.Zoom;
            pctGameOver.Size = new Size(600, 600);
            pctGameOver.Location = new Point(FormWidth / 2 - pctGameOver.Width / 2, FormHeight / 2 - pctGameOver.Height / 2 - 100);
            btnYes.Visible = true;
            btnNo.Visible = true;
            pctQuestionmark.Visible = true;
            pctQuestionmark.SizeMode = PictureBoxSizeMode.Zoom;
            pctQuestionmark.Size = new Size(25, 25);
            pctQuestionmark.Location = new Point(FormWidth / 2 + 80, pctGameOver.Bottom - pctQuestionmark.Height / 2 - 123);
            btnYes.Location = new Point(FormWidth/2 - btnYes.Width/2 - 150, FormHeight/2 + 150);
            btnNo.Location = new Point(FormWidth / 2 - btnNo.Width / 2 + 150, FormHeight / 2 + 150);

            // Music
            music.SoundLocation = "GameOver.WAV";
            music.Play();
        }

        // youWin: displays youwin screen
        public void youWin()
        {
            // Visuals
            foreach (Invader invader in invaders)
            {
                invader.InvaderPicture.Visible = false;
            }

            player.PlayerPicture.Visible = false;

            foreach (Projectile projectile in projectiles)
            {
                projectile.ProjectilePicture.Visible = false;
            }

            lblScore.Visible = false;
            pctYouWin.Visible = true;
            pctYouWin.Location = new Point(FormWidth/2 - pctYouWin.Width/2, FormHeight/2 - pctYouWin.Height/2 - 150);
            pctPlayAgain.Visible = true; 
            pctPlayAgain.Location = new Point(FormWidth / 2 - pctPlayAgain.Width / 2, FormHeight / 2 - 50);
            btnYes.Visible = true;
            btnNo.Visible = true;
            btnYes.Location = new Point(FormWidth / 2 - btnYes.Width / 2 - 150, FormHeight / 2 + 150);
            btnNo.Location = new Point(FormWidth / 2 - btnNo.Width / 2 + 150, FormHeight / 2 + 150);

            // Music
            music.SoundLocation = "YouWin.WAV";
            music.Play();
        }
        #endregion

        #region controls
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            // Move player left on A press and right on D press
            e.SuppressKeyPress = true;
            if (e.KeyData == Keys.A)
            {
                left = true;
            }

            if (e.KeyData == Keys.D) 
            {
                right = true;
            }

            // Fire player projectile on Spacebar press
            if (e.KeyCode == Keys.Space) 
            {
                shoot = true;
            }
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.A) { left = false; }
            if (e.KeyCode == Keys.D) { right = false; }
            if (e.KeyCode == Keys.Space) { shoot = false; }
        }

        // btnYes: starts a new game for current player if pressed
        private void btnYes_Click(object sender, EventArgs e)
        {
            pctQuestionmark.Visible = false;
            pctGameOver.Visible = false;
            btnNo.Visible = false;
            btnYes.Visible = false;
            pctPlayAgain.Visible = false;
            pctYouWin.Visible = false;
            InitializeGame();
        }

        // btnNo: takes user back to main menu if pressed
        private void btnNo_Click(object sender, EventArgs e)
        {
            openMenu();
        }

        #endregion

        #region useless
        private void rtxtScoreboard_TextChanged(object sender, EventArgs e)
        {

        }

        private void pctTitle_Click(object sender, EventArgs e)
        {

        }

        #endregion
    }
}
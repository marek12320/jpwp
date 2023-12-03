namespace jpwp
{
    public partial class Form1 : Form
    {
        int score, alienLine, cannonAngle = 0, cannonY = 45, bulletSpeed, alienSpeed;
        bool moveRight, moveLeft, Reload, isRoundOver, isGameOver;
        PictureBox[] AlienNumbers = null!;
        public Form1()
        {
            InitializeComponent();
            gameSetup();
        }

        private void MainGameTimer(object sender, EventArgs e)
        {

            scoreScreen.Text = "Wynik: " + score;
            if (moveLeft == true && cannonAngle > -45)
            {
                cannonAngle -= 2;
            }
            if (moveRight == true && cannonAngle < 45)
            {
                cannonAngle += 2;
            }

            foreach (Control x in this.Controls)
            {
                if (x is PictureBox && (string)x.Tag == "alien")
                {
                    x.Top += 1;
                    alienLine += 1;

                    if (x.Top == 500)
                    {
                        gameOver();
                    }
                    foreach (Control b in this.Controls)
                    {
                        if (b is PictureBox && (string)b.Tag == "bullet")
                        {
                            if (b.Bounds.IntersectsWith(x.Bounds))
                            {
                                this.Controls.Remove(b);
                                this.Controls.Remove(x);
                                score += 1;
                                Reload = false;
                            }
                        }


                    }
                }
                if (x is PictureBox && (string)x.Tag == "bullet")
                {
                    x.Top -= 15 - Math.Abs(cannonAngle) / 2;
                    x.Left -= 0 - cannonAngle;

                    if (x.Top < 10 || x.Left < 0 || x.Left > 1280)
                    {
                        this.Controls.Remove(x);
                        Reload = false;

                    }


                }
            }
        }

        private void KeyIsDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left && Reload == false)
            {
                moveLeft = true;
            }
            if (e.KeyCode == Keys.Right && Reload == false)
            {
                moveRight = true;
            }

        }
        private void KeyIsUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left)
            {
                moveLeft = false;
            }
            if (e.KeyCode == Keys.Right)
            {
                moveRight = false;
            }
            if (e.KeyCode == Keys.Space && Reload == false)
            {
                Reload = true;
                createBullet();
            }
            if (e.KeyCode == Keys.Enter && isGameOver == true)
            {
                Reload = true;
                clearAll();
                gameSetup();
            }
        }
        private void gameSetup()
        {
            
            score = 0;
            scoreScreen.Text = "Wynik: " + score;
            isGameOver = false;
            Reload = false;

            player.SizeMode = PictureBoxSizeMode.StretchImage;
            makeAliens();
            gameTimer.Start();
        }
        private void gameOver()
        {
            isGameOver = true;
            gameTimer.Stop();


        }
        private void makeAliens()
        {
            int startX = 150;
            AlienNumbers = new PictureBox[6];
            for (int i = 0; i < AlienNumbers.Length; i++)
            {
                AlienNumbers[i] = new PictureBox();
                AlienNumbers[i].Size = new Size(60, 60);
                AlienNumbers[i].Image = Properties.Resources.ship1;
                AlienNumbers[i].Top = 10;
                AlienNumbers[i].Tag = "alien";
                AlienNumbers[i].Left = startX;
                //AlienNumbers[i].BackColor = Color.White;
                AlienNumbers[i].SizeMode = PictureBoxSizeMode.StretchImage;
                this.Controls.Add(AlienNumbers[i]);
                startX += 170;
            }
        }
        private void createBullet()
        {
            PictureBox bullet = new PictureBox();
            //bullet.Image
            bullet.Size = new Size(6, 8);
            bullet.Left = player.Left + player.Width / 2;
            bullet.Top = player.Top - 15;
            bullet.Tag = "bullet";
            bullet.BackColor = Color.OrangeRed;
            this.Controls.Add(bullet);
            bullet.BringToFront();
        }
        private void clearAll()
        {
            foreach (Control i in AlienNumbers)
            {
                //System.Diagnostics.Debug.WriteLine(i.Tag);
                this.Controls.Remove(i);
            }
            foreach (Control i in this.Controls.OfType<PictureBox>())
            {
                if ((string)i.Tag == "bullet")
                {
                    this.Controls.Remove(i);
                    Reload = false;
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void player_Click(object sender, EventArgs e)
        {

        }
    }
}
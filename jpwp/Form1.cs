namespace jpwp
{
    public partial class Form1 : Form
    {
        int score, alienLine, cannonY = 45, bulletSpeed, alienSpeed, can;
        double cannonAngle = 0;
        bool moveRight, moveLeft, Reload, isRoundOver, isGameOver;
        PictureBox[] AlienNumbers = null!;
        public Form1()
        {
            InitializeComponent();
            gameSetup();
        }

        private void MainGameTimer(object sender, EventArgs e)
        {
            Refresh();
            scoreScreen.Text = "Wynik: " + score;
            if (moveLeft == true && cannonAngle > -20)
            {
                cannonAngle -= 2;
            }
            if (moveRight == true && cannonAngle < 20)
            {
                cannonAngle += 2;
            }

            foreach (Control x in this.Controls)
            {
                if (x is PictureBox && (string)x.Tag == "alien")
                {
                    x.Top += 1;
                    alienLine += 1;

                    if (x.Top == 560)
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
                                //Reload = false;
                            }
                        }


                    }
                }
                if (x is PictureBox && (string)x.Tag == "bullet")
                {
                    x.Top -= (int)(18 * Math.Cos(cannonAngle / 18));
                    x.Left += (int)(18 * Math.Sin(cannonAngle / 18));

                    if (x.Top < 10 || x.Left < 0 || x.Left > 1280)
                    {
                        this.Controls.Remove(x);
                        //Reload = false;

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
                //Reload = true;
                createBullet();
            }
            if (e.KeyCode == Keys.Enter && isGameOver == true)
            {
                //Reload = true;
                clearAll();
                gameSetup();
            }
        }
        private void makePlayer()
        {






        }
        private void gameSetup()
        {

            score = 0;
            scoreScreen.Text = "Wynik: " + score;
            isGameOver = false;
            //Reload = false;


            makePlayer();
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
            bullet.Left = 500;// player_panel.Width / 2;
            bullet.Top = 660;
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
                    //Reload = false;
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void player_Click(object sender, EventArgs e)
        {

        }

        private void player_Paint(object sender, PaintEventArgs e)
        {

        }

        private void player_panel_Paint(object sender, PaintEventArgs e)
        {
            Image playerImage = Properties.Resources.Spaceship1;
            Bitmap bitmap = new Bitmap(playerImage.Width * 2, playerImage.Height * 2);
            Graphics g = Graphics.FromImage(bitmap);

            g.TranslateTransform(32, 32);
            g.RotateTransform((int)((cannonAngle) * (85 / 20)));
            g.TranslateTransform(-32, -32);

            g.DrawImage(playerImage, 0, 0);
            //e.Graphics.TranslateTransform(this.Width / 2, this.Height / 2);
            e.Graphics.DrawImage(bitmap, 0, 0);
        }
    }
}
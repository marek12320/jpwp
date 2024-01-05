namespace jpwp
{

    public partial class Form1 : Form
    {
        int score, alienLine;
        double cannonAngle = 0, Angle = 0;
        bool moveRight, moveLeft, Reload, isRoundOver, isGameOver;
        PictureBox[] AlienNumbers = null!;

        String lvl1ObjectNumber = "3";
        string[] level1ShipNumbers = { "1", "4", "-2", "5", "6", "-7" };
        string[] level1GivenNumbers = { "-1", "-3", "-2", "+2", "+5", "+10" };
        int[] level1Order = { 1, 4, 3, 0, 2, 5 };
        public Form1()
        {
            InitializeComponent();
            gameSetup();
        }

        private void MainGameTimer(object sender, EventArgs e)
        {
            Refresh();
            scoreScreen.Text = "Wynik: " + score;
            if (moveLeft == true && cannonAngle > -27)
            {
                cannonAngle -= 1;
            }
            if (moveRight == true && cannonAngle < 27)
            {
                cannonAngle += 1;
            }

            foreach (Control x in this.Controls)
            {
                if (x is PictureBox && (string)x.Tag == "alien")
                {
                    x.Top += 1;
                    alienLine += 1;

                    foreach (Control b in this.Controls)
                    {
                        if (b is PictureBox && (string)b.Tag == "bullet")
                        {
                            if (b.Bounds.IntersectsWith(x.Bounds) && x == AlienNumbers[level1Order[score]])
                            {
                                this.Controls.Remove(b);
                                this.Controls.Remove(x);
                                score += 1;
                                Reload = false;
                                foreach (Control o in this.Controls)
                                {
                                    if ((string)o.Tag == "GivenNumber")
                                    {
                                        this.Controls.Remove(o);
                                    }
                                }
                                if (x.Top == 560 || score == 6)
                                {
                                    scoreScreen.Text = "Wynik: " + score;
                                    gameOver();
                                }
                                if (isGameOver == false)
                                {
                                    addGivenNumber(level1GivenNumbers[score]);
                                }

                            }
                        }
                    }

                }
                if (Reload == false)
                {
                    Angle = cannonAngle;
                }
                if (x is PictureBox && (string)x.Tag == "bullet")
                {
                    x.Top -= (int)(32 * Math.Cos(Angle / 17));
                    x.Left += (int)(32 * Math.Sin(Angle / 17));
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

            if (e.KeyCode == Keys.Left)
            {
                moveLeft = true;
            }
            if (e.KeyCode == Keys.Right)
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

            addGivenNumber(level1GivenNumbers[score]);
            addObjectNumber(lvl1ObjectNumber);
            makeAliens();
            gameTimer.Start();
        }
        private void gameOver()
        {
            isGameOver = true;
            gameTimer.Stop();


        }
        private Image writeOnImage(Image img, String text)
        {

            Font font = new Font("TimesNewRoman", 200, FontStyle.Bold, GraphicsUnit.Pixel);
            Graphics graphics = Graphics.FromImage(img);
            if (text.Length == 2)
            {
                graphics.DrawString(text, font, Brushes.Yellow, new Point(10, 0));
            }
            else
            {
                graphics.DrawString(text, font, Brushes.Yellow, new Point(50, 0));
            }
            return img;
        }
        private void makeAliens()
        {
            int startX = 100;
            AlienNumbers = new PictureBox[6];

            for (int i = 0; i < AlienNumbers.Length; i++)
            {
                Image image = writeOnImage(Properties.Resources.ship1, level1ShipNumbers[i]);
                AlienNumbers[i] = new PictureBox();
                AlienNumbers[i].Size = new Size(60, 60);
                AlienNumbers[i].Image = image;
                AlienNumbers[i].Top = 10;
                AlienNumbers[i].Tag = "alien";
                AlienNumbers[i].Left = startX;
                //AlienNumbers[i].BackColor = Color.White;
                AlienNumbers[i].SizeMode = PictureBoxSizeMode.StretchImage;
                this.Controls.Add(AlienNumbers[i]);
                startX += 170;
            }
        }
        private void addObjectNumber(string lvlObjectNumber)
        {

            Label objectNum = new Label();
            objectNum.Text = lvlObjectNumber;
            objectNum.Font = new Font("TimesNewRoman", 50, FontStyle.Bold, GraphicsUnit.Pixel);
            objectNum.Left = 20;
            objectNum.Top = 860;
            objectNum.ForeColor = Color.Red;
            objectNum.AutoSize = true;
            this.Controls.Add((objectNum));

        }
        private void addGivenNumber(string lvlgivenNumber)
        {

            Label givenNum = new Label();
            givenNum.Text = lvlgivenNumber;
            givenNum.Font = new Font("TimesNewRoman", 50, FontStyle.Bold, GraphicsUnit.Pixel);
            givenNum.Left = 555;
            givenNum.Top = 900;
            givenNum.ForeColor = Color.Red;
            givenNum.AutoSize = true;
            givenNum.Tag = "GivenNumber";
            this.Controls.Add((givenNum));

        }
        private void createBullet()
        {
            PictureBox bullet = new PictureBox();
            //bullet.Image
            bullet.Size = new Size(6, 8);
            bullet.Left = 593 ;// player_panel.Width / 2;
            bullet.Top = 860;
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


        private void playerPaint(object sender, PaintEventArgs e)
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
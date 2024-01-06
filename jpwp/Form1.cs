using System.Runtime.Intrinsics.X86;

namespace jpwp
{

    public partial class Form1 : Form
    {
        int score = 0, scoreMissed = 0, alienSpeed=4, speedoMeter;
        double cannonAngle = 0, Angle = 0;
        bool moveRight, moveLeft, Reload, isRoundOneOver = true, isRoundTwoOver = true, isGameOver = true,isLoser = false;

        PictureBox[] AlienNumbers = null!;

        String lvl1ObjectNumber = "3";
        string[] level1ShipNumbers = { "1", "4", "-2", "5", "6", "-7" };
        string[] level1GivenNumbers = { "-1", "-3", "-2", "+2", "+5", "+10" };
        int[] level1Order = { 1, 4, 3, 0, 2, 5 };

        String lvl2ObjectNumber = "3";
        string[] level2ShipNumbers = { "1", "4", "-2", "5", "6", "-7", "-7" };
        string[] level2GivenNumbers = { "-1", "-3", "-2", "+2", "+5", "+10", "-7" };
        int[] level2Order = { 1, 4, 3, 0, 2, 5 , 6};

        String lvl3ObjectNumber = "3";
        string[] level3ShipNumbers = { "1", "4", "-2", "5", "6", "-7", "-7", "-7" };
        string[] level3GivenNumbers = { "-1", "-3", "-2", "+2", "+5", "+10", "-7", "-7" };
        int[] level3Order = { 1, 4, 3, 0, 2, 5, 6, 7};
        public Form1()
        {
            InitializeComponent();
            gameSetup();

        }

        private void MainGameTimer(object sender, EventArgs e)
        {
            Refresh();
            scoreScreen.Text = "Wynik: " + score;

            if (isRoundOneOver == false)
            {
                GameLogic(level1Order, 0, level1GivenNumbers,6);
                
            }
            else if (isRoundTwoOver == false)
            {
                GameLogic(level2Order, 6, level2GivenNumbers,7);
            }
            else if (isGameOver == false)
            {
                GameLogic(level3Order, 13, level3GivenNumbers,8);
            }
            else
            {
                //gameOver();
            }
            
            speedoMeter += 1;
            if (speedoMeter == alienSpeed)
            {
                speedoMeter = 0;
            }

        }

        private void GameLogic(int[] levelOrder, int roundStartScore, String[] levelGivenNumbers,int roundShipNum)
        {
            if (moveLeft == true && cannonAngle > -54)
            {
                cannonAngle -= 1;
            }
            if (moveRight == true && cannonAngle < 54)
            {
                cannonAngle += 1;
            }
            foreach (Control x in this.Controls)
            {
                if (x is PictureBox && (string)x.Tag == "alien")
                {
                    if (speedoMeter == 0)
                    {
                        x.Top += 1;
                    }
                   

                    foreach (Control b in this.Controls)
                    {
                        if (b is PictureBox && (string)b.Tag == "bullet")
                        {
                            if (b.Bounds.IntersectsWith(x.Bounds) && x == AlienNumbers[levelOrder[score - roundStartScore]])
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

                                if (score == roundShipNum + roundStartScore)
                                {
                                    scoreScreen.Text = "Wynik: " + score;
                                    roundOver();
                                    
                                }
                                else
                                if (score != roundShipNum + roundStartScore)
                                {
                                    addGivenNumber(levelGivenNumbers[score - roundStartScore]);
                                }

                            }
                        }
                        
                        if (x.Top == 730)
                        {
                            isLoser = true;
                            scoreScreen.Text = "Wynik: " + score;
                            roundOver();
                        }
                    }

                }
                if (Reload == false)
                {
                    Angle = cannonAngle;
                }
                if (x is PictureBox && (string)x.Tag == "bullet")
                {
                    x.Top -= (int)(32 * Math.Cos(Angle / 34));
                    x.Left += (int)(32 * Math.Sin(Angle / 34));
                    if (x.Top < 10 || x.Left < 0 || x.Left > 1280)
                    {
                        this.Controls.Remove(x);
                        scoreMissed += 1; 
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
            if (e.KeyCode == Keys.Enter && ((isRoundOneOver == true || isRoundOneOver == true) && isGameOver == false))
            {
                Reload = true;
                
                clearAll();
                
                gameSetup();
            }
            if (e.KeyCode == Keys.Enter && isGameOver == true)
            {
                Reload = true;
                clearAll();
                score = 0;
                gameSetup();
            }
        }

        private void gameSetup()
        {

            
            scoreScreen.Text = "Wynik: " + score;
            if (score == 0)
            {
                isRoundOneOver = false;
                isRoundTwoOver = false;
                isGameOver = false;
                isLoser = false;
            }
            gameTimer.Start();
            Reload = false;
            
            if (isRoundOneOver == false)
            {
                addGivenNumber(level1GivenNumbers[score]);
                addObjectNumber(lvl1ObjectNumber);
                alienSpeed = 4;
                speedoMeter = 0;
                makeAliens(100, 6, level1ShipNumbers);
            }
            else if (isRoundTwoOver == false)
            {
                addGivenNumber(level2GivenNumbers[score - 6]);
                addObjectNumber(lvl2ObjectNumber);
                alienSpeed = 3;
                speedoMeter = 0;
                makeAliens(100, 7, level2ShipNumbers);
            }
            else if (isGameOver == false)
            {
                addGivenNumber(level3GivenNumbers[score - 13]);
                addObjectNumber(lvl3ObjectNumber);
                alienSpeed = 2;
                speedoMeter = 0;
                makeAliens(100, 8, level3ShipNumbers);
            }
            else
            {
                gameOver();
            }

            
            //Baner();
            gameTimer.Start();

        }
        private void roundOver()
        {
            if (isRoundOneOver == false)
            {
                isRoundOneOver = true;
                Baner("Kliknij Enter aby rozpocz¹æ nastêpny poziom", 130, 450);
                gameTimer.Stop();

            }
            else if (isRoundTwoOver == false)
            {
                isRoundTwoOver = true;
                Baner("Kliknij Enter aby rozpocz¹æ nastêpny poziom", 130, 450);
            }
            else
            {
                gameOver();
            }
        }
        private void gameOver()
        {
            
            isGameOver = true;
            gameTimer.Stop();
            if (isLoser == false)
            {
                clearAll();
                Baner("Uda³o ci siê wygraæ pud³uj¹c tylko " + scoreMissed+ " razy!", 150, 500 );
            }
            else
            {
                clearAll();
                Baner("                 Niestety przegra³eœ", 130, 450);
            }


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
        private void makeAliens(int startX, int alienNum, String[] levelShipNumbers)
        {
            //int startX = 100;
            AlienNumbers = new PictureBox[alienNum];

            for (int i = 0; i < AlienNumbers.Length; i++)
            {
                Image image = writeOnImage(Properties.Resources.ship1, levelShipNumbers[i]);
                AlienNumbers[i] = new PictureBox();
                AlienNumbers[i].Size = new Size(60, 60);
                AlienNumbers[i].Image = image;
                AlienNumbers[i].Top = 10;
                AlienNumbers[i].Tag = "alien";
                AlienNumbers[i].Left = startX;
                //AlienNumbers[i].BackColor = Color.White;
                AlienNumbers[i].SizeMode = PictureBoxSizeMode.StretchImage;
                this.Controls.Add(AlienNumbers[i]);
                startX += 974/(alienNum-1);
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
        private void Baner(String endtext, int posx, int posy)
        {
            
            Label win = new Label();
            win.Text = endtext;
            win.Font = new Font("TimesNewRoman", 50, FontStyle.Bold, GraphicsUnit.Pixel);
            win.Left = posx;
            win.Top = posy;
            win.ForeColor = Color.Red;
            win.AutoSize = true;
            win.Tag = "endBaner";
            this.Controls.Add((win));
        }
        private void createBullet()
        {
            PictureBox bullet = new PictureBox();
            //bullet.Image
            bullet.Size = new Size(6, 8);
            bullet.Left = 593;// player_panel.Width / 2;
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
            foreach (Control i in this.Controls.OfType<Label>())
            {
                if ((string)i.Tag == "endBaner")
                {
                    this.Controls.Remove(i);
                }
            }

        }


        private void playerPaint(object sender, PaintEventArgs e)
        {
            Image playerImage = Properties.Resources.Spaceship1;
            Bitmap bitmap = new Bitmap(playerImage.Width * 2, playerImage.Height * 2);
            Graphics g = Graphics.FromImage(bitmap);

            g.TranslateTransform(32, 32);
            g.RotateTransform((int)((cannonAngle) * (85 / 40)));
            g.TranslateTransform(-32, -32);

            g.DrawImage(playerImage, 0, 0);
            //e.Graphics.TranslateTransform(this.Width / 2, this.Height / 2);
            e.Graphics.DrawImage(bitmap, 0, 0);
        }

        private void button1_MouseClick(object sender, MouseEventArgs e)
        {
            menu.Visible = true;
            gameTimer.Stop();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void QuitButtonClick(object sender, MouseEventArgs e)
        {
            this.Close();
        }

        private void ReturnButtonClick(object sender, MouseEventArgs e)
        {
            menu.Visible = false;
            gameTimer.Start();
        }

        private void RestartButtonClick(object sender, MouseEventArgs e)
        {
            menu.Visible = false;
            clearAll();
            score = 0;
            gameSetup();
        }

        private void MenuButtonClick(object sender, MouseEventArgs e)
        {
            menu.Visible = true;
            gameTimer.Stop();
        }
    }
}
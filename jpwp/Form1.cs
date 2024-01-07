using System.Net.Sockets;
using System.Runtime.Intrinsics.X86;

namespace jpwp
{

    public partial class Form1 : Form
    {

        /// zmienna odpowiadajaca za liczba zestrzelonych przez gracza statkow
        int score = 0;
        /// zmienna odpowiadajaca za liczba nietrafionych pociskow
        int scoreMissed = 0;
        /// zmienna odpowiadajaca za predkosc statkow przeciwnikow
        int alienSpeed = 4;
        /// zmienna pomocnicza odpowiadajaca do sterowania predkoscia przeciwnikow
        int speedoMeter;
        /// zmienna odpowiadajaca za pozycje statku gracza
        double cannonAngle = 0;
        /// zmienna odpowiadajaca za k¹t pocisku
        double Angle = 0;
        /// zmienna odpowiadajaca za obrot gracza w prawo
        bool moveRight;
        /// zmienna odpowiadajaca za obrot gracza w lewo    
        bool moveLeft;
        /// zmienna odpowiadajaca za ograniczanie liczby wystrzelonych pociskow
        bool Reload;
        /// falga czy 1 runda ukonczona
        bool isRoundOneOver = false;
        /// flaga czy 2 runda ukonczona
        bool isRoundTwoOver = false;
        /// flaga czy gra runda ukonczona
        bool isGameOver = true;
        /// flaga czy gracz przegral 
        bool isLoser = false;
        /// tablica na obiekty przeciwnikow przeciwnikami  
        PictureBox[] AlienNumbers = null!;

        /// liczba docelowa 1 poziomu
        String lvl1ObjectNumber = "3";
        /// liczby wyswietlane na poszczegolnych statkach podczas 1 poziomu
        string[] level1ShipNumbers = { "1", "4", "-2", "5", "6", "-7" };
        /// liczby wyswietlane na statku gracza podczas 1 poziomu
        string[] level1GivenNumbers = { "-1", "-3", "-2", "+2", "+5", "+10" };
        /// prawidlowa kolejnosc zestrzelenia statkow podczas 1 poziomu
        int[] level1Order = { 1, 4, 3, 0, 2, 5 };

        /// liczba docelowa 2 poziomu
        String lvl2ObjectNumber = "5";
        /// liczby wyswietlane na poszczegolnych statkach podczas 2 poziomu
        string[] level2ShipNumbers = { "4", "8", "-3", "-4", "1", "-1", "-7" };
        /// liczby wyswietlane na statku gracza podczas 2 poziomu
        string[] level2GivenNumbers = { "+9", "+1", "+4", "+12", "-3", "+8", "+6" };
        /// prawidlowa kolejnosc zestrzelenia statkow podczas 2 poziomu
        int[] level2Order = { 3, 0, 4, 6, 1, 2, 5 };

        /// liczba docelowa 3 poziomu
        String lvl3ObjectNumber = "-4";
        /// liczby wyswietlane na poszczegolnych statkach podczas 3 poziomu
        string[] level3ShipNumbers = { "5", "-9", "-7", "0", "-3", "-4", "1", "2" };
        /// liczby wyswietlane na statku gracza podczas 3 poziomu
        string[] level3GivenNumbers = { "+5", "-4", "-1", "+3", "-9", "-6", "0", "-5" };
        /// prawidlowa kolejnosc zestrzelenia statkow podczas 3 poziomu
        int[] level3Order = { 1, 3, 4, 2, 0, 7, 5, 6 };
        public Form1()
        {
            InitializeComponent();

            gameSetup();

        }

        /// Funkcja jest wywolywana z kazdym tickiem gameTimer`a czyli co 10ms
        private void MainGameTimer(object sender, EventArgs e)
        {
            Refresh();
            scoreScreen.Text = "Wynik: " + score;

            if (isRoundOneOver == false)
            {
                GameLogic(level1Order, 0, level1GivenNumbers, 6);

            }
            else if (isRoundTwoOver == false)
            {
                GameLogic(level2Order, 6, level2GivenNumbers, 7);
            }
            else if (isGameOver == false)
            {
                GameLogic(level3Order, 13, level3GivenNumbers, 8);
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
        /// Funkcja odpowiada za przebieg gry
        private void GameLogic(int[] levelOrder, int roundStartScore, String[] levelGivenNumbers, int roundShipNum)
        {
            if (score == 1)
            {
                instrukcja.Visible = false;
                instrukcja2.Visible = false;
                strzlaInstrukcja.Visible = false;
            }
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
        /// obluga przyciskow
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
        /// obluga przyciskow
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
        /// rozpoczecie nowej rundy wraz z wyborem poziomu
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
                cleargiven();
                addGivenNumber(level1GivenNumbers[score]);
                addObjectNumber(lvl1ObjectNumber);
                alienSpeed = 4;
                speedoMeter = 0;
                makeAliens(100, 6, level1ShipNumbers);
            }
            else if (isRoundTwoOver == false)
            {
                cleargiven();
                addGivenNumber(level2GivenNumbers[score - 6]);
                addObjectNumber(lvl2ObjectNumber);
                alienSpeed = 3;
                speedoMeter = 0;
                makeAliens(100, 7, level2ShipNumbers);
            }
            else if (isGameOver == false)
            {
                cleargiven();
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
            gameTimer.Start();

        }
        /// zakonczenie rundy
        private void roundOver()
        {
            if (isRoundOneOver == false)
            {
                isRoundOneOver = true;
                clearAll();
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
        ///zakonczenie gry
        private void gameOver()
        {

            isGameOver = true;
            gameTimer.Stop();
            if (isLoser == false)
            {
                clearAll();
                Baner("Uda³o ci siê wygraæ pud³uj¹c tylko " + scoreMissed + " razy!", 150, 500);
            }
            else
            {
                clearAll();
                Baner("                 Niestety przegra³eœ", 130, 450);
            }


        }
        /// dodawanie napisu do ograzu
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
        ///tworzeniei wyswietlanie statkow przeciwnikow
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
                AlienNumbers[i].BackColor = Color.Transparent;
                AlienNumbers[i].SizeMode = PictureBoxSizeMode.StretchImage;
                this.Controls.Add(AlienNumbers[i]);
                startX += 974 / (alienNum - 1);
            }
        }
        /// wyswietlanie liczby docelowej w lewym dolnym rogu ekranu 
        private void addObjectNumber(string lvlObjectNumber)
        {

            Label objectNum = new Label();
            objectNum.Text = lvlObjectNumber;
            objectNum.Font = new Font("TimesNewRoman", 50, FontStyle.Bold, GraphicsUnit.Pixel);
            objectNum.Left = 20;
            objectNum.Top = 860;
            objectNum.ForeColor = Color.Red;
            objectNum.AutoSize = true;
            objectNum.Tag = "objectNum";
            objectNum.BackColor = Color.Transparent;
            this.Controls.Add((objectNum));

        }
        /// wyswietlanie liczby pod statkiem gracza  
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
            givenNum.BackColor = Color.Transparent;
            this.Controls.Add((givenNum));

        }
        /// <summary>
        /// wyswietla tekst w wybranym na ekranie miejscu
        /// </summary>
        /// <param name="endtext">tekst do wyswietlenia</param>
        /// <param name="posx">skladowa pozioma poczatku wyœwietlanego tekstu</param>
        /// <param name="posy">skladowa pionowa poczatku wyœwietlanego tekstu</param>
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
        /// tworzenie pocisku
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
        /// usuniecie z ekranu przeciwnikow, pociskow oraz wysietlonych banerow
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
                if ((string)i.Tag == "endBaner" || (string)i.Tag == "GivenNumber")
                {
                    this.Controls.Remove(i);
                }
            }


        }
        /// usuniecie liczby pod statkiem gracza
        private void cleargiven()
        {
            foreach (Control i in this.Controls.OfType<Label>())
            {
                if ((string)i.Tag == "objectNum")
                {
                    this.Controls.Remove(i);
                }
            }
        }

        /// wysietlanie i obrot statku gracza
        private void playerPaint(object sender, PaintEventArgs e)
        {
            Image playerImage = Properties.Resources.Spaceship1;
            this.DoubleBuffered = true;
            Bitmap bitmap = new Bitmap(playerImage.Width * 2, playerImage.Height * 2);
            Graphics g = Graphics.FromImage(bitmap);

            g.TranslateTransform(32, 32);
            g.RotateTransform((int)((cannonAngle) * (85 / 40)));
            g.TranslateTransform(-32, -32);

            g.DrawImage(playerImage, 0, 0);
            //e.Graphics.TranslateTransform(this.Width / 2, this.Height / 2);
            e.Graphics.DrawImage(bitmap, 0, 0);
        }
        /// obsluga przcisku wylaczania gry z graficznego menu
        private void QuitButtonClick(object sender, MouseEventArgs e)
        {
            this.Close();
        }
        /// obsluga przcisku powrotu do gry z graficznego menu
        private void ReturnButtonClick(object sender, MouseEventArgs e)
        {
            menu.Visible = false;
            gameTimer.Start();
        }
        /// obsluga przcisku restartu gry z graficznego menu
        private void RestartButtonClick(object sender, MouseEventArgs e)
        {
            menu.Visible = false;
            clearAll();
            score = 0;
            gameSetup();
        }
        /// obsluga przcisku wlaczenia graficznego menu; gra jest pauzowana
        private void MenuButtonClick(object sender, MouseEventArgs e)
        {
            menu.Visible = true;
            gameTimer.Stop();
        }
    }
}
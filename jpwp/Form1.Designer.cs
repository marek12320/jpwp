namespace jpwp
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
            scoreScreen = new Label();
            gameTimer = new System.Windows.Forms.Timer(components);
            contextMenuStrip1 = new ContextMenuStrip(components);
            player_panel = new Panel();
            menu = new Panel();
            button2 = new Button();
            buttonMenuBackToGame = new Button();
            buttonMenuQuit = new Button();
            label1 = new Label();
            label2 = new Label();
            strzlaInstrukcja = new PictureBox();
            instrukcja = new Label();
            instrukcja2 = new Label();
            menu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)strzlaInstrukcja).BeginInit();
            SuspendLayout();
            // 
            // scoreScreen
            // 
            scoreScreen.AutoSize = true;
            scoreScreen.BackColor = Color.Transparent;
            scoreScreen.Font = new Font("Segoe UI", 12F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point);
            scoreScreen.ForeColor = SystemColors.ActiveCaption;
            scoreScreen.Location = new Point(11, 919);
            scoreScreen.Name = "scoreScreen";
            scoreScreen.Size = new Size(73, 28);
            scoreScreen.TabIndex = 0;
            scoreScreen.Text = "wynik:";
            // 
            // gameTimer
            // 
            gameTimer.Interval = 10;
            gameTimer.Tag = "gameTimer";
            gameTimer.Tick += MainGameTimer;
            // 
            // contextMenuStrip1
            // 
            contextMenuStrip1.ImageScalingSize = new Size(20, 20);
            contextMenuStrip1.Name = "contextMenuStrip1";
            contextMenuStrip1.Size = new Size(61, 4);
            // 
            // player_panel
            // 
            player_panel.BackColor = Color.Transparent;
            player_panel.Location = new Point(559, 826);
            player_panel.Margin = new Padding(3, 4, 3, 4);
            player_panel.Name = "player_panel";
            player_panel.Size = new Size(91, 84);
            player_panel.TabIndex = 3;
            player_panel.Paint += playerPaint;
            // 
            // menu
            // 
            menu.BackColor = Color.MidnightBlue;
            menu.BorderStyle = BorderStyle.FixedSingle;
            menu.Controls.Add(button2);
            menu.Controls.Add(buttonMenuBackToGame);
            menu.Controls.Add(buttonMenuQuit);
            menu.Controls.Add(label1);
            menu.Location = new Point(423, 137);
            menu.Margin = new Padding(3, 4, 3, 4);
            menu.Name = "menu";
            menu.Size = new Size(434, 506);
            menu.TabIndex = 4;
            menu.Visible = false;
            // 
            // button2
            // 
            button2.BackColor = SystemColors.ActiveCaption;
            button2.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            button2.Location = new Point(117, 369);
            button2.Name = "button2";
            button2.Size = new Size(218, 47);
            button2.TabIndex = 3;
            button2.Text = "Zagraj jeszcze raz";
            button2.UseVisualStyleBackColor = false;
            button2.MouseDown += RestartButtonClick;
            // 
            // buttonMenuBackToGame
            // 
            buttonMenuBackToGame.BackColor = SystemColors.ActiveCaption;
            buttonMenuBackToGame.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            buttonMenuBackToGame.Location = new Point(117, 290);
            buttonMenuBackToGame.Name = "buttonMenuBackToGame";
            buttonMenuBackToGame.Size = new Size(218, 47);
            buttonMenuBackToGame.TabIndex = 2;
            buttonMenuBackToGame.Text = "Wróć do gry";
            buttonMenuBackToGame.UseVisualStyleBackColor = false;
            buttonMenuBackToGame.MouseDown += ReturnButtonClick;
            // 
            // buttonMenuQuit
            // 
            buttonMenuQuit.BackColor = SystemColors.ActiveCaption;
            buttonMenuQuit.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            buttonMenuQuit.ForeColor = SystemColors.ActiveCaptionText;
            buttonMenuQuit.Location = new Point(117, 205);
            buttonMenuQuit.Name = "buttonMenuQuit";
            buttonMenuQuit.Size = new Size(218, 47);
            buttonMenuQuit.TabIndex = 1;
            buttonMenuQuit.Text = "Wyjdź z gry";
            buttonMenuQuit.UseVisualStyleBackColor = false;
            buttonMenuQuit.MouseDown += QuitButtonClick;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Black", 26.25F, FontStyle.Bold, GraphicsUnit.Point);
            label1.ForeColor = SystemColors.ActiveCaption;
            label1.Location = new Point(151, 56);
            label1.Name = "label1";
            label1.Size = new Size(149, 60);
            label1.TabIndex = 0;
            label1.Text = "Menu";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.Transparent;
            label2.Font = new Font("Segoe UI", 16.2F, FontStyle.Bold, GraphicsUnit.Point);
            label2.ForeColor = SystemColors.ActiveCaption;
            label2.Location = new Point(1122, 912);
            label2.Name = "label2";
            label2.Size = new Size(101, 38);
            label2.TabIndex = 5;
            label2.Text = "MENU";
            label2.MouseClick += MenuButtonClick;
            // 
            // strzlaInstrukcja
            // 
            strzlaInstrukcja.BackColor = Color.Transparent;
            strzlaInstrukcja.Image = (Image)resources.GetObject("strzlaInstrukcja.Image");
            strzlaInstrukcja.Location = new Point(93, 853);
            strzlaInstrukcja.Name = "strzlaInstrukcja";
            strzlaInstrukcja.Size = new Size(155, 57);
            strzlaInstrukcja.SizeMode = PictureBoxSizeMode.StretchImage;
            strzlaInstrukcja.TabIndex = 6;
            strzlaInstrukcja.TabStop = false;
            // 
            // instrukcja
            // 
            instrukcja.BackColor = Color.Transparent;
            instrukcja.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            instrukcja.ForeColor = SystemColors.ActiveCaption;
            instrukcja.Location = new Point(264, 818);
            instrukcja.Name = "instrukcja";
            instrukcja.Size = new Size(261, 150);
            instrukcja.TabIndex = 7;
            instrukcja.Text = "Aby zestrzelić statek przeciwnika suma liczby pod statkiem gracza i liczby na statku przeciwnika musi wynieść tyle! ";
            // 
            // instrukcja2
            // 
            instrukcja2.BackColor = Color.Transparent;
            instrukcja2.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            instrukcja2.ForeColor = SystemColors.ActiveCaption;
            instrukcja2.Location = new Point(699, 818);
            instrukcja2.Name = "instrukcja2";
            instrukcja2.Size = new Size(241, 69);
            instrukcja2.TabIndex = 8;
            instrukcja2.Text = "Steruj statkiem strzałkami, strzelaj spacją";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Black;
            ClientSize = new Size(1262, 977);
            ControlBox = false;
            Controls.Add(instrukcja2);
            Controls.Add(instrukcja);
            Controls.Add(strzlaInstrukcja);
            Controls.Add(label2);
            Controls.Add(menu);
            Controls.Add(player_panel);
            Controls.Add(scoreScreen);
            KeyPreview = true;
            Margin = new Padding(3, 4, 3, 4);
            MinimizeBox = false;
            Name = "Form1";
            ShowIcon = false;
            ShowInTaskbar = false;
            SizeGripStyle = SizeGripStyle.Show;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "matemars";
            KeyDown += KeyIsDown;
            KeyUp += KeyIsUp;
            menu.ResumeLayout(false);
            menu.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)strzlaInstrukcja).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        /// Label wyswietlajacy wynik w dolnym rogu ekranu
        private Label scoreScreen;
        private System.Windows.Forms.Timer gameTimer;
        /// nieuzywane
        private ContextMenuStrip contextMenuStrip1;
        /// nieuzywane
        private Panel panel1;
        /// panel na ktorym wyswietla sie statek gracza
        private Panel player_panel;
        /// panel menu
        private Panel menu;
        /// napis "menu" w graficznym menu 
        private Label label1;
        /// przycisk wyjscia z gry w graficznym menu
        private Button buttonMenuQuit;
        /// przycisk powrotu do gry w graficznym menu
        private Button buttonMenuBackToGame;
        /// przycisk restartu gry w garficznym menu
        private Button button2;
        /// przycisk menu
        private Label label2;
        /// element instrukcji
        private PictureBox strzlaInstrukcja;
        /// element instrukcji
        private Label instrukcja;
        /// element instrukcji
        private Label instrukcja2;
    }
}
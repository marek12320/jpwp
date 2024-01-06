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
            menu.SuspendLayout();
            SuspendLayout();
            // 
            // scoreScreen
            // 
            scoreScreen.AutoSize = true;
            scoreScreen.Font = new Font("Segoe UI", 12F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point);
            scoreScreen.Location = new Point(11, 919);
            scoreScreen.Name = "scoreScreen";
            scoreScreen.Size = new Size(73, 28);
            scoreScreen.TabIndex = 0;
            scoreScreen.Text = "wynik:";
            // 
            // gameTimer
            // 
            gameTimer.Interval = 20;
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
            player_panel.Location = new Point(559, 826);
            player_panel.Margin = new Padding(3, 4, 3, 4);
            player_panel.Name = "player_panel";
            player_panel.Size = new Size(91, 84);
            player_panel.TabIndex = 3;
            player_panel.Paint += playerPaint;
            // 
            // menu
            // 
            menu.BackColor = SystemColors.GradientInactiveCaption;
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
            button2.Location = new Point(117, 369);
            button2.Name = "button2";
            button2.Size = new Size(218, 47);
            button2.TabIndex = 3;
            button2.Text = "Rozpocznij grę od początku";
            button2.UseVisualStyleBackColor = true;
            button2.MouseDown += RestartButtonClick;
            // 
            // buttonMenuBackToGame
            // 
            buttonMenuBackToGame.Location = new Point(117, 290);
            buttonMenuBackToGame.Name = "buttonMenuBackToGame";
            buttonMenuBackToGame.Size = new Size(218, 47);
            buttonMenuBackToGame.TabIndex = 2;
            buttonMenuBackToGame.Text = "Wróć do gry";
            buttonMenuBackToGame.UseVisualStyleBackColor = true;
            buttonMenuBackToGame.MouseDown += ReturnButtonClick;
            // 
            // buttonMenuQuit
            // 
            buttonMenuQuit.Location = new Point(117, 205);
            buttonMenuQuit.Name = "buttonMenuQuit";
            buttonMenuQuit.Size = new Size(218, 47);
            buttonMenuQuit.TabIndex = 1;
            buttonMenuQuit.Text = "Wyjdź z gry";
            buttonMenuQuit.UseVisualStyleBackColor = true;
            buttonMenuQuit.MouseDown += QuitButtonClick;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Black", 26.25F, FontStyle.Bold, GraphicsUnit.Point);
            label1.ForeColor = Color.IndianRed;
            label1.Location = new Point(151, 56);
            label1.Name = "label1";
            label1.Size = new Size(149, 60);
            label1.TabIndex = 0;
            label1.Text = "Menu";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 16.2F, FontStyle.Bold, GraphicsUnit.Point);
            label2.Location = new Point(1122, 912);
            label2.Name = "label2";
            label2.Size = new Size(101, 38);
            label2.TabIndex = 5;
            label2.Text = "MENU";
            label2.MouseClick += MenuButtonClick;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaption;
            ClientSize = new Size(1262, 977);
            Controls.Add(label2);
            Controls.Add(menu);
            Controls.Add(player_panel);
            Controls.Add(scoreScreen);
            KeyPreview = true;
            Margin = new Padding(3, 4, 3, 4);
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "matemars";
            Load += Form1_Load;
            KeyDown += KeyIsDown;
            KeyUp += KeyIsUp;
            menu.ResumeLayout(false);
            menu.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label scoreScreen;
        private System.Windows.Forms.Timer gameTimer;
        private ContextMenuStrip contextMenuStrip1;
        private Panel panel1;
        private Panel player_panel;
        private Panel menu;
        private Label label1;
        private Button buttonMenuQuit;
        private Button buttonMenuBackToGame;
        private Button button2;
        private Label label2;
    }
}
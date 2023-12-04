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
            player = new PictureBox();
            gameTimer = new System.Windows.Forms.Timer(components);
            button1 = new Button();
            ((System.ComponentModel.ISupportInitialize)player).BeginInit();
            SuspendLayout();
            // 
            // scoreScreen
            // 
            scoreScreen.AutoSize = true;
            scoreScreen.Font = new Font("Segoe UI", 12F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point);
            scoreScreen.Location = new Point(12, 919);
            scoreScreen.Name = "scoreScreen";
            scoreScreen.Size = new Size(73, 28);
            scoreScreen.TabIndex = 0;
            scoreScreen.Text = "wynik:";
            // 
            // player
            // 
            player.BackColor = SystemColors.ActiveCaption;
            player.Image = Properties.Resources.ship5;
            player.Location = new Point(576, 895);
            player.Name = "player";
            player.Size = new Size(60, 60);
            player.TabIndex = 1;
            player.TabStop = false;
            player.Tag = "player";
            player.Click += player_Click;
            // 
            // gameTimer
            // 
            gameTimer.Interval = 20;
            gameTimer.Tag = "gameTimer";
            gameTimer.Tick += MainGameTimer;
            // 
            // button1
            // 
            button1.Font = new Font("Showcard Gothic", 19.8000011F, FontStyle.Regular, GraphicsUnit.Point);
            button1.ForeColor = Color.IndianRed;
            button1.Location = new Point(1099, 895);
            button1.Name = "button1";
            button1.Size = new Size(141, 52);
            button1.TabIndex = 2;
            button1.Text = "MENU";
            button1.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaption;
            ClientSize = new Size(1262, 977);
            Controls.Add(button1);
            Controls.Add(player);
            Controls.Add(scoreScreen);
            Margin = new Padding(3, 4, 3, 4);
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "matemars";
            Load += Form1_Load;
            KeyDown += KeyIsDown;
            KeyUp += KeyIsUp;
            ((System.ComponentModel.ISupportInitialize)player).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label scoreScreen;
        private PictureBox player;
        private System.Windows.Forms.Timer gameTimer;
        private Button button1;
    }
}
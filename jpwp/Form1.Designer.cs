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
            button1 = new Button();
            contextMenuStrip1 = new ContextMenuStrip(components);
            player_panel = new Panel();
            SuspendLayout();
            // 
            // scoreScreen
            // 
            scoreScreen.AutoSize = true;
            scoreScreen.Font = new Font("Segoe UI", 12F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point);
            scoreScreen.Location = new Point(10, 689);
            scoreScreen.Name = "scoreScreen";
            scoreScreen.Size = new Size(60, 21);
            scoreScreen.TabIndex = 0;
            scoreScreen.Text = "wynik:";
            // 
            // gameTimer
            // 
            gameTimer.Interval = 20;
            gameTimer.Tag = "gameTimer";
            gameTimer.Tick += MainGameTimer;
            // 
            // button1
            // 
            button1.Enabled = false;
            button1.Font = new Font("Showcard Gothic", 19.8000011F, FontStyle.Regular, GraphicsUnit.Point);
            button1.ForeColor = Color.IndianRed;
            button1.Location = new Point(962, 671);
            button1.Margin = new Padding(3, 2, 3, 2);
            button1.Name = "button1";
            button1.Size = new Size(123, 39);
            button1.TabIndex = 2;
            button1.Text = "MENU";
            button1.UseVisualStyleBackColor = true;
            button1.Click += player_Click;
            // 
            // contextMenuStrip1
            // 
            contextMenuStrip1.Name = "contextMenuStrip1";
            contextMenuStrip1.Size = new Size(61, 4);
            // 
            // player_panel
            // 
            player_panel.Location = new Point(489, 630);
            player_panel.Name = "player_panel";
            player_panel.Size = new Size(80, 80);
            player_panel.TabIndex = 3;
            player_panel.Paint += player_panel_Paint;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaption;
            ClientSize = new Size(1104, 733);
            Controls.Add(player_panel);
            Controls.Add(button1);
            Controls.Add(scoreScreen);
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "matemars";
            Load += Form1_Load;
            KeyDown += KeyIsDown;
            KeyUp += KeyIsUp;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label scoreScreen;
        private System.Windows.Forms.Timer gameTimer;
        private Button button1;
        private ContextMenuStrip contextMenuStrip1;
        private Panel panel1;
        private Panel player_panel;
    }
}
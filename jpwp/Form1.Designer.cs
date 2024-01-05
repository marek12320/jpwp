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
            panel2 = new Panel();
            label1 = new Label();
            panel2.SuspendLayout();
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
            // button1
            // 
            button1.Enabled = false;
            button1.Font = new Font("Microsoft Sans Serif", 19.8F, FontStyle.Regular, GraphicsUnit.Point);
            button1.ForeColor = Color.IndianRed;
            button1.Location = new Point(1099, 895);
            button1.Name = "button1";
            button1.Size = new Size(141, 52);
            button1.TabIndex = 2;
            button1.Text = "MENU";
            button1.UseVisualStyleBackColor = true;
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
            // panel2
            // 
            panel2.BackColor = SystemColors.GradientInactiveCaption;
            panel2.BorderStyle = BorderStyle.FixedSingle;
            panel2.Controls.Add(label1);
            panel2.Location = new Point(423, 137);
            panel2.Margin = new Padding(3, 4, 3, 4);
            panel2.Name = "panel2";
            panel2.Size = new Size(434, 506);
            panel2.TabIndex = 4;
            panel2.Visible = false;
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
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaption;
            ClientSize = new Size(1262, 977);
            Controls.Add(panel2);
            Controls.Add(player_panel);
            Controls.Add(button1);
            Controls.Add(scoreScreen);
            Margin = new Padding(3, 4, 3, 4);
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "matemars";
            KeyDown += KeyIsDown;
            KeyUp += KeyIsUp;
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
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
        private Panel panel2;
        private Label label1;
    }
}
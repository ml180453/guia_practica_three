namespace guia_practica_three
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
            timermov = new System.Windows.Forms.Timer(components);
            lblGameOver = new Label();
            lblScore = new Label();
            label1 = new Label();
            SuspendLayout();
            // 
            // timermov
            // 
            timermov.Enabled = true;
            // 
            // lblGameOver
            // 
            lblGameOver.AutoSize = true;
            lblGameOver.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblGameOver.Location = new Point(180, 248);
            lblGameOver.Name = "lblGameOver";
            lblGameOver.Size = new Size(140, 32);
            lblGameOver.TabIndex = 0;
            lblGameOver.Text = "Game Over";
            // 
            // lblScore
            // 
            lblScore.AutoSize = true;
            lblScore.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblScore.Location = new Point(570, 25);
            lblScore.Name = "lblScore";
            lblScore.Size = new Size(92, 30);
            lblScore.TabIndex = 1;
            lblScore.Text = "lblScore";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(180, 210);
            label1.Name = "label1";
            label1.Size = new Size(399, 21);
            label1.TabIndex = 1;
            label1.Text = "Para iniciar debes presionar Enter y comenzar a moverte";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(784, 561);
            Controls.Add(label1);
            Controls.Add(lblScore);
            Controls.Add(lblGameOver);
            Name = "Form1";
            Text = "Juego de la Serpiente";
            Paint += Form1_Paint;
            KeyDown += Form1_KeyDown;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Timer timermov;
        private Label lblGameOver;
        private Label lblScore;
        private Label label1;
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pacman
{
    public partial class GameOverForm : Form
    {
        private int currentScore;
        private int highScore;
        private Menu menuForm;

        public GameOverForm(int currentScore, int highScore)
        {
            InitializeComponent();

            this.currentScore = currentScore;
            this.highScore = highScore;

            lblCurrentScore.Text = $"Ваш рахунок: {currentScore}";
            lblHighScore.Text = $"Найвищий рахунок: {highScore}";
            menuForm = new Menu();
            menuForm.Show();
            this.Hide();
        }

        private void OK_Click(object sender, EventArgs e)
        {
            this.Close();

            if (!menuForm.Visible)
            {
                menuForm.ShowDialog();
            }
        }
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GameOverForm));
            this.lblCurrentScore = new System.Windows.Forms.Label();
            this.lblHighScore = new System.Windows.Forms.Label();
            this.OK = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblCurrentScore
            // 
            this.lblCurrentScore.AutoSize = true;
            this.lblCurrentScore.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblCurrentScore.ForeColor = System.Drawing.Color.Yellow;
            this.lblCurrentScore.Location = new System.Drawing.Point(70, 54);
            this.lblCurrentScore.Name = "lblCurrentScore";
            this.lblCurrentScore.Size = new System.Drawing.Size(148, 20);
            this.lblCurrentScore.TabIndex = 0;
            this.lblCurrentScore.Text = "Ваш рахунок: 0";
            // 
            // lblHighScore
            // 
            this.lblHighScore.AutoSize = true;
            this.lblHighScore.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblHighScore.ForeColor = System.Drawing.Color.Yellow;
            this.lblHighScore.Location = new System.Drawing.Point(70, 86);
            this.lblHighScore.Name = "lblHighScore";
            this.lblHighScore.Size = new System.Drawing.Size(204, 20);
            this.lblHighScore.TabIndex = 1;
            this.lblHighScore.Text = "Найвищий рахунок: 0";
            // 
            // OK
            // 
            this.OK.FlatAppearance.BorderColor = System.Drawing.Color.Yellow;
            this.OK.FlatAppearance.BorderSize = 2;
            this.OK.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.OK.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.OK.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.OK.ForeColor = System.Drawing.Color.White;
            this.OK.Location = new System.Drawing.Point(134, 134);
            this.OK.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.OK.Name = "OK";
            this.OK.Size = new System.Drawing.Size(93, 43);
            this.OK.TabIndex = 2;
            this.OK.Text = "OK";
            this.OK.UseVisualStyleBackColor = true;
            this.OK.Click += new System.EventHandler(this.OK_Click);
            // 
            // GameOverForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ClientSize = new System.Drawing.Size(342, 228);
            this.Controls.Add(this.OK);
            this.Controls.Add(this.lblHighScore);
            this.Controls.Add(this.lblCurrentScore);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "GameOverForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Гра завершилась";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

    }
}

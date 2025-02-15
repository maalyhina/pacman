using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;

namespace Pacman
{
    public partial class Menu : Form
    {
        private System.ComponentModel.IContainer components = null;
        private SoundPlayer startmusic;
        private Menu menu;
        public Menu()
        {
            InitializeComponent();
            startmusic = new SoundPlayer(Properties.Resources.pacman_intro);
            startmusic.Play();
            menu = this;
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code
        public void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Menu));
            this.Start = new System.Windows.Forms.Button();
            this.Setting = new System.Windows.Forms.Button();
            this.Exit = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Start
            // 
            this.Start.FlatAppearance.BorderColor = System.Drawing.Color.Yellow;
            this.Start.FlatAppearance.BorderSize = 3;
            this.Start.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.Start.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Start.Font = new System.Drawing.Font("Showcard Gothic", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Start.ForeColor = System.Drawing.Color.White;
            this.Start.Location = new System.Drawing.Point(115, 279);
            this.Start.Name = "Start";
            this.Start.Size = new System.Drawing.Size(274, 62);
            this.Start.TabIndex = 0;
            this.Start.Text = "Грати";
            this.Start.UseVisualStyleBackColor = true;
            this.Start.Click += new System.EventHandler(this.LoadGame);
            // 
            // Setting
            // 
            this.Setting.FlatAppearance.BorderColor = System.Drawing.Color.Yellow;
            this.Setting.FlatAppearance.BorderSize = 3;
            this.Setting.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.Setting.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Setting.Font = new System.Drawing.Font("Showcard Gothic", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Setting.ForeColor = System.Drawing.Color.White;
            this.Setting.Location = new System.Drawing.Point(115, 382);
            this.Setting.Name = "Setting";
            this.Setting.Size = new System.Drawing.Size(274, 62);
            this.Setting.TabIndex = 1;
            this.Setting.Text = "Налаштування";
            this.Setting.UseVisualStyleBackColor = true;
            this.Setting.Click += new System.EventHandler(this.Setting_Click);
            // 
            // Exit
            // 
            this.Exit.FlatAppearance.BorderColor = System.Drawing.Color.Yellow;
            this.Exit.FlatAppearance.BorderSize = 3;
            this.Exit.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.Exit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Exit.Font = new System.Drawing.Font("Showcard Gothic", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Exit.ForeColor = System.Drawing.Color.White;
            this.Exit.Location = new System.Drawing.Point(115, 606);
            this.Exit.Name = "Exit";
            this.Exit.Size = new System.Drawing.Size(274, 62);
            this.Exit.TabIndex = 2;
            this.Exit.Text = "Вихід";
            this.Exit.UseVisualStyleBackColor = true;
            this.Exit.Click += new System.EventHandler(this.ExitGame);
            // 
            // Menu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.Disable;
            this.BackColor = System.Drawing.Color.Black;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ClientSize = new System.Drawing.Size(512, 768);
            this.Controls.Add(this.Exit);
            this.Controls.Add(this.Setting);
            this.Controls.Add(this.Start);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Menu";
            this.RightToLeftLayout = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Pacman";
            this.ResumeLayout(false);

        }

        private void LoadGame(object sender, EventArgs e)
        {
            
            PacmanForms pacmangame = new PacmanForms();

            pacmangame.Show();
            this.Hide();

        }

        private void ExitGame(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Setting_Click(object sender, EventArgs e)
        {
            SoundSettingsForm audioset = new SoundSettingsForm();
            audioset.Show();
        }
        #endregion
    }
}

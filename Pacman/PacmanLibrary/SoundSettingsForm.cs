using System;
using System.Windows.Forms;
using AudioSwitcher.AudioApi.CoreAudio;

namespace Pacman
{
    public partial class SoundSettingsForm : Form
    {
        private CoreAudioDevice defaultPlaybackDevice;
        private float volume;
        public SoundSettingsForm()
        {
            InitializeComponent();

            // Ініціалізація CoreAudioController та отримання пристрою за замовчуванням
            try
            {
                defaultPlaybackDevice = new CoreAudioController().DefaultPlaybackDevice;
                trackBarVolume.Value = (int)(defaultPlaybackDevice.Volume);
                labelVolume.Text = "Volume: " + trackBarVolume.Value;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error initializing audio device: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SoundSettingsForm));
            this.trackBarVolume = new System.Windows.Forms.TrackBar();
            this.labelVolume = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarVolume)).BeginInit();
            this.SuspendLayout();
            // 
            // trackBarVolume
            // 
            this.trackBarVolume.Cursor = System.Windows.Forms.Cursors.Hand;
            this.trackBarVolume.Location = new System.Drawing.Point(61, 181);
            this.trackBarVolume.Maximum = 100;
            this.trackBarVolume.Name = "trackBarVolume";
            this.trackBarVolume.Size = new System.Drawing.Size(297, 56);
            this.trackBarVolume.TabIndex = 0;
            this.trackBarVolume.Scroll += new System.EventHandler(this.trackBarVolume_Scroll);
            // 
            // labelVolume
            // 
            this.labelVolume.AutoSize = true;
            this.labelVolume.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelVolume.ForeColor = System.Drawing.Color.Yellow;
            this.labelVolume.Location = new System.Drawing.Point(147, 97);
            this.labelVolume.Name = "labelVolume";
            this.labelVolume.Size = new System.Drawing.Size(77, 29);
            this.labelVolume.TabIndex = 1;
            this.labelVolume.Text = "Звук ";
            // 
            // btnSave
            // 
            this.btnSave.FlatAppearance.BorderColor = System.Drawing.Color.Yellow;
            this.btnSave.FlatAppearance.BorderSize = 2;
            this.btnSave.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Location = new System.Drawing.Point(132, 372);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(149, 40);
            this.btnSave.TabIndex = 2;
            this.btnSave.Text = "Зберегти зміни";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // SoundSettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(407, 451);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.labelVolume);
            this.Controls.Add(this.trackBarVolume);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "SoundSettingsForm";
            this.Text = "Налаштування";
            ((System.ComponentModel.ISupportInitialize)(this.trackBarVolume)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void trackBarVolume_Scroll(object sender, EventArgs e)
        {
            labelVolume.Text = "Звук " + trackBarVolume.Value;
            if (defaultPlaybackDevice != null)
            {
                defaultPlaybackDevice.Volume = trackBarVolume.Value;
  }
        }
        private void AdjustVolume(float volume)
        {
            defaultPlaybackDevice.Volume = volume * 100;
        }

        private void OpenSoundSettings()
        {
            SoundSettingsForm soundSettingsForm = new SoundSettingsForm();
            soundSettingsForm.ShowDialog();
            AdjustVolume(volume);
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.Volume = trackBarVolume.Value;
            Properties.Settings.Default.Save();
            this.Close();
        }

        private System.Windows.Forms.TrackBar trackBarVolume;
        private System.Windows.Forms.Label labelVolume;
        private System.Windows.Forms.Button btnSave;
    }
}

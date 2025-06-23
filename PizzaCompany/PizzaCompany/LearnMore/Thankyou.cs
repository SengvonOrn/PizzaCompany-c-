using NAudio.Wave;
using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using TagLib;

namespace PizzaCompany.LearnMore
{
    public partial class Thankyou : Form
    {
        private WaveOutEvent outputDevice;
        private AudioFileReader audioFile;

        public Thankyou()
        {
            InitializeComponent();

            // Ensure image resizes nicely
            guna2CirclePictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
        }

        private void Thankyou_Load(object sender, EventArgs e)
        {
            // Hide music button on load
            btnmusic.Visible = false;
        }

        /// <summary>
        /// Hide music button
        /// </summary>
        private void hiden()
        {
            btnmusic.Visible = false;
        }

        /// <summary>
        /// Show music button if it's hidden
        /// </summary>
        private void presettle()
        {
            if (!btnmusic.Visible)
                btnmusic.Visible = true;
        }

        /// <summary>
        /// Show button when user clicks a "Learn More" or similar button
        /// </summary>
        private void guna2Button1_Click(object sender, EventArgs e)
        {
            presettle();
        }

        /// <summary>
        /// Play music and show album art when user clicks the music button
        /// </summary>
        private void btnmusic_Click(object sender, EventArgs e)
        {
            hiden();

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string selectedFile = openFileDialog1.FileName;

                try
                {
                    // Dispose previous audio instances
                    audioFile?.Dispose();
                    outputDevice?.Stop();
                    outputDevice?.Dispose();

                    // Initialize and play new audio
                    audioFile = new AudioFileReader(selectedFile);
                    outputDevice = new WaveOutEvent();
                    outputDevice.Init(audioFile);
                    outputDevice.Play();

                    // Show album art in PictureBox
                    ShowAlbumArt(selectedFile);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error playing audio:\n" + ex.Message, "Playback Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        /// <summary>
        /// Extract and display album art from the selected audio file
        /// </summary>
        private void ShowAlbumArt(string audioPath)
        {
            try
            {
                var file = TagLib.File.Create(audioPath);
                if (file.Tag.Pictures.Length > 0)
                {
                    byte[] picData = file.Tag.Pictures[0].Data.Data;
                    using (MemoryStream ms = new MemoryStream(picData))
                    {
                        guna2CirclePictureBox1.Image = Image.FromStream(ms);
                    }
                }
                else
                {
                    guna2CirclePictureBox1.Image = null; // No image
                }
            }
            catch
            {
                guna2CirclePictureBox1.Image = null; // Error loading image
            }
        }

        /// <summary>
        /// Stop playback and clear album art
        /// </summary>
        private void btnStop_Click(object sender, EventArgs e)
        {
            try
            {
                outputDevice?.Stop();
                audioFile?.Dispose();
                outputDevice?.Dispose();
                guna2CirclePictureBox1.Image = null;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error stopping audio:\n" + ex.Message, "Stop Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Reserved for animation feature (future)
        private void rump3() { }

    
        private void guna2VTrackBar1_Scroll(object sender, ScrollEventArgs e) { }

        private void guna2TrackBar1_MouseMove(object sender, MouseEventArgs e) { }
        private void guna2TrackBar1_MouseDown(object sender, MouseEventArgs e) { }
        private void guna2TrackBar1_MouseUp(object sender, MouseEventArgs e) { }
        private void guna2TrackBar1_MouseLeave(object sender, EventArgs e) { }

        private void btnback_Click(object sender, EventArgs e)
        {
            // TODO: Navigate back to previous screen or form
        }

        private void btnSkip_Click(object sender, EventArgs e)
        {
            // TODO: Skip or next action
        }
    }
}

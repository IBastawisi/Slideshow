namespace Slideshow
{
    public partial class Form1 : Form
    {
        private List<Image> images;
        private int interval = 1000;
        private int index = 0;
        private bool isPlaying = true;
        public Form1()
        {
            InitializeComponent();
            images = new List<Image>
            {
                Properties.Resources.Image1,
                Properties.Resources.Image2,
                Properties.Resources.Image3,
                Properties.Resources.Image4,
                Properties.Resources.Image5,
            };
        }

        private void SetPicture()
        {
            pictureBox1.Image = images[index];
        }

        private void SetTimer(int interval)
        {
            timer1.Interval = this.interval = interval;
            if (isPlaying) timer1.Start(); else timer1.Stop();
        }

        private void TogglePlaying(bool state)
        {
            isPlaying = state;
            button2.Text = isPlaying ? "Pause" : "Play";
            SetTimer(interval);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            SetPicture();
            SetTimer(interval);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (!isPlaying) return;
            index++;
            if (index >= images.Count) index = 0;
            SetPicture();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            SetTimer(500);
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            SetTimer(1000);
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            SetTimer(2000);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            TogglePlaying(false);
            index--;
            if (index < 0) index = images.Count - 1;
            SetPicture();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            TogglePlaying(!isPlaying);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            TogglePlaying(false);
            index++;
            if (index >= images.Count) index = 0;
            SetPicture();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
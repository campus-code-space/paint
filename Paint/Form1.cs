namespace Paint
{
    public partial class Form1 : Form
    {
        Graphics g;
        int x = -1;
        int y = -1;
        bool moving = false;
        Pen pen;

        public Form1()
        {
            InitializeComponent();
            g = panel1.CreateGraphics();
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            pen = new Pen(Color.Black, 5);


        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            PictureBox p = (PictureBox)sender;

            pen.Color = p.BackColor;


        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            moving = true;
            x = e.X; y = e.Y;
            panel1.Cursor = Cursors.Cross;

        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (moving && x != -1 && y != -1)
            {

                g.DrawLine(pen, new Point(x, y), e.Location);
                x = e.X; y = e.Y;


            }
        }

        private void panel1_MouseUp(object sender, MouseEventArgs e)
        {
            moving = false;
            x = -1;
            y = -1;
            panel1.Cursor = Cursors.Default;

        }



        private void exitApplicationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();

            ofd.Filter = ofd.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp;*.gif";

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                panel1.BackgroundImage = Image.FromFile(ofd.FileName);
                panel1.BackgroundImageLayout = ImageLayout.Stretch;

            }
        }

        private void openImageToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void exitApplicationToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}

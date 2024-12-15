

namespace Paint
{
    public partial class Form1 : Form
    {
        Graphics g;
        int x = -1;
        int y = -1;
        bool moving = false;
        Pen pen;

        int sX, sY, cX, cY;
        enum Shape { None, Line, Rectangle, Ellipse }
        Shape currentShape = Shape.None;

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
            x = e.X;
            y = e.Y;

            sX = x;
            sY = y;

            panel1.Cursor = Cursors.Cross;


        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (moving && x != -1 && y != -1)
            {
                if (currentShape == Shape.None)
                {
                    g.DrawLine(pen, new Point(x, y), e.Location);
                    x = e.X; y = e.Y;
                }
                else if (currentShape == Shape.Line)
                {
                    g.DrawLine(pen, new Point(x, y), e.Location);
                }
                else if (currentShape == Shape.Rectangle)
                {
                    cX = e.X;
                    cY = e.Y;
                    g.DrawRectangle(pen, Math.Min(sX, cX), Math.Min(sY, cY), Math.Abs(sX - cX), Math.Abs(sY - cY));
                }
                else if (currentShape == Shape.Ellipse)
                {
                    cX = e.X;
                    cY = e.Y;
                    g.DrawEllipse(pen, Math.Min(sX, cX), Math.Min(sY, cY), Math.Abs(sX - cX), Math.Abs(sY - cY));
                }

            }
        }

        private void panel1_MouseUp(object sender, MouseEventArgs e)
        {
            moving = false;
            x = -1;
            y = -1;
            panel1.Cursor = Cursors.Default;
            if (currentShape == Shape.None)
            {

            }
            else if (currentShape == Shape.Line)
            {
                g.DrawLine(pen, new Point(sX, sY), new Point(cX, cY));
            }
            else if (currentShape == Shape.Rectangle)
            {
                g.DrawRectangle(pen, Math.Min(sX, cX), Math.Min(sY, cY), Math.Abs(sX - cX), Math.Abs(sY - cY));
            }
            else if (currentShape == Shape.Ellipse)
            {
                g.DrawEllipse(pen, Math.Min(sX, cX), Math.Min(sY, cY), Math.Abs(sX - cX), Math.Abs(sY - cY));
            }
        }


        private void exitApplicationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp;*.gif";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                panel1.BackgroundImage = Image.FromFile(ofd.FileName);
                panel1.BackgroundImageLayout = ImageLayout.Stretch;
            }
        }

        private void exitApplicationToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            currentShape = Shape.Ellipse;

        }

        private void button2_Click(object sender, EventArgs e)
        {
            currentShape = Shape.Rectangle;

        }

        private void button3_Click(object sender, EventArgs e)
        {
            currentShape = Shape.Line;

        }

        private void button4_Click(object sender, EventArgs e)
        {
            currentShape = Shape.None;
        }
    }
}


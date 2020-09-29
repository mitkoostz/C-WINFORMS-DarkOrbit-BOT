using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BOT
{
    public partial class Selector : Form
    {
        public Selector()
        {
            InitializeComponent();
            this.BackColor = Color.White;
            this.FormBorderStyle = FormBorderStyle.None;
            this.Bounds = new Rectangle(0, 0, 100, 100);
            this.TopMost = true;
            this.MinimizeBox = false;
            this.MaximizeBox = false;
            this.DoubleBuffered = true;
            this.SetStyle(ControlStyles.ResizeRedraw, true);
            this.ShowIcon = false;

            // this.StartPosition = Form1.MousePosition;
           // this.TransparencyKey = Color.FromArgb(15, 55, 255, 255);
            //this.BackColor = Color.FromArgb(255, 55, 255, 255);



        }

        private const int cGrip = 16;      // Grip size
        private const int cCaption = 32;   // Caption bar height;

        protected override void OnPaint(PaintEventArgs e)
        {
            Rectangle rc = new Rectangle(this.ClientSize.Width - cGrip, this.ClientSize.Height - cGrip, cGrip, cGrip);
            Brush brush = new SolidBrush(Color.FromArgb(255, 55, 235, 255));

            ControlPaint.DrawSizeGrip(e.Graphics, this.BackColor, rc);
            rc = new Rectangle(0, 0, this.ClientSize.Width, cCaption);
            e.Graphics.FillRectangle(brush, rc);
        }

        protected override void WndProc(ref Message m)
        {
            if (m.Msg == 0x84)
            {  // Trap WM_NCHITTEST
                Point pos = new Point(m.LParam.ToInt32());
                pos = this.PointToClient(pos);
                if (pos.Y < cCaption)
                {
                    m.Result = (IntPtr)2;  // HTCAPTION
                    return;
                }
                if (pos.X >= this.ClientSize.Width - cGrip && pos.Y >= this.ClientSize.Height - cGrip)
                {
                    m.Result = (IntPtr)17; // HTBOTTOMRIGHT
                    return;
                }
            }
            base.WndProc(ref m);
        }

        private void Selector_Load(object sender, EventArgs e)
        {
            label2.Text = this.Left.ToString();
            label3.Text = this.Top.ToString();

        }

  

        public void button1_Click(object sender, EventArgs e)
        {
            Console.WriteLine("X1 =   " + this.Left);
            Console.WriteLine("X2 =   " + this.Right);

            Console.WriteLine("Y1 =   " + this.Top);
            Console.WriteLine("Y2 =   " + this.Bottom);

            Console.WriteLine("form width =   " + this.Width);
            Console.WriteLine("form height =   " + this.Height);

            SELECT_VALUES.X1 = this.Left;
            SELECT_VALUES.X2 = this.Right;

            SELECT_VALUES.Y1 = this.Top;
            SELECT_VALUES.Y2 = this.Bottom;

            SELECT_VALUES.WIDTH = this.Width;
            SELECT_VALUES.HEIGHT = this.Height;

            this.Close();

        

        }

        public void Selector_FormClosed(object sender, FormClosedEventArgs e)
        {
          
        }

        private void Selector_DragEnter(object sender, DragEventArgs e)
        {
            label2.Text = this.Left.ToString();
            label3.Text = this.Top.ToString();
        }

        private void Selector_ResizeBegin(object sender, EventArgs e)
        {
            label2.Text = this.Left.ToString();
            label3.Text = this.Top.ToString();
        }
    }
}

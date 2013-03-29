using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        System.IO.StreamWriter file = new System.IO.StreamWriter(@"C:\Users\Ryan\Desktop\Love\points.txt");
        Graphics g=null;
        bool isDown = false;
        public Form1()
        {
            InitializeComponent();
            g = this.CreateGraphics();
            this.MouseDown += Form1_MouseDown;
            this.MouseUp += Form1_MouseUp;
            this.MouseMove += Form1_MouseMove;
        }

        void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            if (isDown) {
                g.FillEllipse(Brushes.Black, e.X, e.Y, 10, 10);
                file.Write(e.X+","+e.Y+"|");
                file.Flush();
            }
        }

        void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            isDown = false;
        }

        void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            isDown = true;
            g.FillEllipse(Brushes.Black, e.X, e.Y, 10, 10);
            file.Write(e.X + "," + e.Y + "|");
            file.Flush();
        }
    }
}

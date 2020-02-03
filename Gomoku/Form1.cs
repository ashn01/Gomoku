using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gomoku
{
    public partial class Form1 : Form
    {
        const int FIELD = 19;
        const int margin = 40;
        const int gridSize = 30;
        const int stoneSize = 27;
        const int dotSize = 10;
        int[,] gomokuField = new int[19,19];
        int turn = 0;

        public Form1()
        {
            InitializeComponent();
            Field.Paint += new PaintEventHandler(DrawingField);
            Field.MouseDown += new MouseEventHandler(PutStone);
            ResizeRedraw = true;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
        }

        private void DrawingField(object sender, PaintEventArgs e)
        {
            Pen p = new Pen(Color.Black, 1);
            for(int i=0;i< FIELD; ++i)
            {
                e.Graphics.DrawLine(p, margin, margin+gridSize*i, gridSize*18+margin, margin+ gridSize * i);
                e.Graphics.DrawLine(p, margin+ gridSize * i, margin, margin+ gridSize * i, gridSize * 18 + margin);
            }
            for(int i=0;i<3;++i)
                for(int j=0;j<3;++j)
                    e.Graphics.FillEllipse(Brushes.Black, i*gridSize*6 + margin + gridSize * 3 - dotSize / 2, j * gridSize * 6 + margin + gridSize * 3 - dotSize / 2, dotSize, dotSize);
        }

        private void PutStone(object sender, MouseEventArgs e)
        {
            Calculate(new Point(e.X - margin, e.Y - margin));
        }

        private bool Calculate(Point p) // position
        {
            p.X += 7;
            p.Y += 7;
            if (p.X <= 0 || p.Y <= 0 || p.X >= 19 * gridSize || p.Y >= 19 * gridSize)
                return false;
            if (p.X % gridSize > gridSize / 2 || p.Y % gridSize > gridSize / 2)
                return false;

            p.X = p.X / gridSize + (p.X % gridSize > gridSize / 2 ? 1 : 0);
            p.Y = p.Y / gridSize + (p.Y % gridSize > gridSize / 2 ? 1 : 0);

            if (gomokuField[p.X, p.Y] != 1)
            { // draw stone
                gomokuField[p.X, p.Y] = 1;
                ++turn;
                Graphics g = this.Field.CreateGraphics();
                g.FillEllipse((turn%2 == 0 ? Brushes.Black : Brushes.White), 
                    margin - stoneSize / 2 + p.X * gridSize, 
                    margin - stoneSize / 2 + p.Y * gridSize, 
                    stoneSize, 
                    stoneSize);
                
                return true;
            }
            else
                return false;
        }


    }
}

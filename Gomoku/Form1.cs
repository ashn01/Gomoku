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
        const int margin = 40;
        const int gridSize = 30;
        const int stoneSize = 27;
        const int dotSize = 10;


        public Form1()
        {
            InitializeComponent();
            Field.Paint += new PaintEventHandler(DrawingField);
            ResizeRedraw = true;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
        }

        private void DrawingField(object sender, PaintEventArgs e)
        {
            Pen p = new Pen(Color.Black, 1);
            for(int i=0;i<19;++i)
            {
                e.Graphics.DrawLine(p, margin, margin+gridSize*i, gridSize*18+margin, margin+ gridSize * i);
                e.Graphics.DrawLine(p, margin+ gridSize * i, margin, margin+ gridSize * i, gridSize * 18 + margin);
            }
            for(int i=0;i<3;++i)
                for(int j=0;j<3;++j)
                    e.Graphics.FillEllipse(Brushes.Black, i*gridSize*6 + margin + gridSize * 3 - dotSize / 2, j * gridSize * 6 + margin + gridSize * 3 - dotSize / 2, dotSize, dotSize);
        }

        private void newGameMenu_Click(object sender, EventArgs e)
        {
            this.Field.Invalidate();
        }
    }
}

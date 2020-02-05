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
        enum Player{ BLACK=0,WHITE=1 }
        const int FIELD = 19;
        const int margin = 40;
        const int gridSize = 30;
        const int stoneSize = 27;
        const int dotSize = 10;
        int[,] gomokuField = new int[19, 19];
        int turn = 0;
        bool gameSet = false;

        public Form1()
        {
            InitializeComponent(); 
            Init();
        }

        private void Init()
        {
            this.Field.Invalidate();
            Array.Clear(gomokuField, 0, gomokuField.Length);
            turn = 0;
            gameSet = false;
            Field.Paint += new PaintEventHandler(DrawingField);
            Field.MouseDown += new MouseEventHandler(PutStone);
            ResizeRedraw = true;

            lTurn.Text = (turn % 2 == 0 ? "Black" : "White") + " turn";
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
        }

        private void DrawingField(object sender, PaintEventArgs e)
        {
            Pen p = new Pen(Color.Black, 1);
            for (int i = 0; i < FIELD; ++i)
            {
                e.Graphics.DrawLine(p, margin, margin + gridSize * i, gridSize * 18 + margin, margin + gridSize * i);
                e.Graphics.DrawLine(p, margin + gridSize * i, margin, margin + gridSize * i, gridSize * 18 + margin);
            }
            for (int i = 0; i < 3; ++i)
                for (int j = 0; j < 3; ++j)
                    e.Graphics.FillEllipse(Brushes.Black, i * gridSize * 6 + margin + gridSize * 3 - dotSize / 2, j * gridSize * 6 + margin + gridSize * 3 - dotSize / 2, dotSize, dotSize);
        }

        private void PutStone(object sender, MouseEventArgs e)
        {
            if (gameSet) // stop game if anyone wins.
                return;

            Point p = new Point(e.X - margin, e.Y - margin);
            if (Calculate(p))
            {
                if (CheckWin(p))
                {
                    int who = WhosTurn();
                    if (who == (int)Player.BLACK)
                        lBlackScore.Text = (Convert.ToInt32(lBlackScore.Text)+1).ToString();
                    else
                        lWhiteScore.Text = (Convert.ToInt32(lWhiteScore.Text + 1)+1).ToString();

                    lTurn.Text = (who == (int)Player.BLACK ? "Black" : "White") + " Win!!";

                    gameSet = true; // game over
                }
                ++turn;
            }
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

            if (gomokuField[p.X, p.Y] == 0)
            { // draw stone
                gomokuField[p.X, p.Y] = turn % 2 == 0 ? 1 : 2; // 1 black, 2 white
                Graphics g = this.Field.CreateGraphics();
                g.FillEllipse((turn % 2 == 0 ? Brushes.Black : Brushes.White),
                    margin - stoneSize / 2 + p.X * gridSize,
                    margin - stoneSize / 2 + p.Y * gridSize,
                    stoneSize,
                    stoneSize);


                return true;
            }
            else
                return false;
        }

        private bool CheckWin(Point p) // check if any player wins.
        {
            int cntVertical = 0, cntHorizontal = 0, cntDiagonalNE = 0, cntDiagonalSE = 0;
            p.X = p.X / gridSize + (p.X % gridSize > gridSize / 2 ? 1 : 0);
            p.Y = p.Y / gridSize + (p.Y % gridSize > gridSize / 2 ? 1 : 0);
            int who = WhosTurn()+1;
            // check vertically
            for (int i = 0; p.Y-i >= 0; i++)
            {
                if (gomokuField[p.X, p.Y - i] == who)
                    ++cntVertical;
                else
                    break;
            }

            for (int i = 1; p.Y+i < FIELD; i++)
            {
                if (gomokuField[p.X, p.Y + i] == who)
                    ++cntVertical;
                else
                    break;
            }
            if (cntVertical == 5)
                return true;

            // check horizontally
            for (int i = 0; p.X-i >= 0; i++)
            {
                if (gomokuField[p.X - i, p.Y] == who)
                    ++cntHorizontal;
                else
                    break;
            }

            for (int i = 1; p.X+i < FIELD; i++)
            {
                if (gomokuField[p.X + i, p.Y] == who)
                    ++cntHorizontal;
                else
                    break;
            }

            if (cntHorizontal == 5)
                return true;

            // check diagonal NE
            for (int i = 0; p.Y-i >= 0 && p.X+i < FIELD; i++)
            {
                if (gomokuField[p.X + i, p.Y - i] == who)
                    ++cntDiagonalNE;
                else
                    break;
            }

            for (int i = 1; p.Y+i < FIELD && p.X-i >= 0; i++)
            {
                if (gomokuField[p.X - i, p.Y + i] == who)
                    ++cntDiagonalNE;
                else
                    break;
            }
            if (cntDiagonalNE == 5)
                return true;

            // check diagonal SE
            for (int i = 0; p.Y-i >= 0 && p.X-i >= 0; i++)
            {
                if (gomokuField[p.X - i, p.Y - i] == who)
                    ++cntDiagonalSE;
                else
                    break;
            }

            for (int i = 1; p.Y+i < FIELD && p.X+i < FIELD; i++)
            {
                if (gomokuField[p.X + i, p.Y + i] == who)
                    ++cntDiagonalSE;
                else
                    break;
            }
            if (cntDiagonalSE == 5)
                return true;

            return false;
        }

        private int WhosTurn()
        {
            int who = turn % 2 ;
            lTurn.Text = (who != (int)Player.BLACK ? "Black" : "White") + " turn";

            return who;
        }

        private void bRestart_Click(object sender, EventArgs e)
        {
            Init();
        }
    }
}

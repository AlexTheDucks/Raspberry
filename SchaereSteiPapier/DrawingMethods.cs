using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using Explorer700Library;

namespace SchaereSteiPapier
{
    static class DrawingMethods
    {
        public static Graphics drawStateAttack(Explorer700 board, int playerPoint, int opPoint)
        {
            Graphics g = board.Display.Graphics;
            g.Clear(default);

            Pen pen = new Pen(Brushes.Blue);
            Brush brush = Brushes.Blue;
            PointF[] pointsLeft = new PointF[3];
            pointsLeft[0] = new PointF(30, 20);
            pointsLeft[1] = new PointF(30, 30);
            pointsLeft[2] = new PointF(25, 25);

            PointF[] pointsRight = new PointF[3];
            pointsRight[0] = new PointF(98, 20);
            pointsRight[1] = new PointF(98, 30);
            pointsRight[2] = new PointF(103, 25);

            g.DrawRectangle(pen, new Rectangle(39, 0, 50, 50));
            g.FillPolygon(brush, pointsLeft);
            g.FillPolygon(brush, pointsRight);
            g.DrawString("You: " + playerPoint, new Font(new FontFamily("arial"), 8, FontStyle.Bold), Brushes.Blue, new PointF(5, 50));
            g.DrawString("Op.: " + opPoint, new Font(new FontFamily("arial"), 8, FontStyle.Bold), Brushes.Blue, new PointF(90, 50));
            board.Display.Update();
            return g;
        }


     
    }
}

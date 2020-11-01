using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using Explorer700Library;

namespace SchaereSteiPapier
{
    static class DrawPattern
    {

        public static void drawScore(Graphics g, int playerPoint, int opPoint)
        {
            g.DrawString("You: " + playerPoint, new Font(new FontFamily("arial"), 8, FontStyle.Bold), Brushes.Blue, new PointF(5, 50));
            g.DrawString("Op.: " + opPoint, new Font(new FontFamily("arial"), 8, FontStyle.Bold), Brushes.Blue, new PointF(90, 50));

        }

        public static void drawTimer(Graphics g, int TimeLeft)
        {
            if (TimeLeft != -1)
            {
                g.DrawString(TimeLeft.ToString(), new Font(new FontFamily("arial"), 8, FontStyle.Bold), Brushes.Blue, new PointF(61, 50));
            }
        }

        public static void drawAttackCoose(Graphics g)
        {
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
        }


        public static void drawBattleGraphic(Graphics g)
        {
            Pen pen = new Pen(Brushes.Blue);
            Brush brush = Brushes.Blue;            

            g.DrawRectangle(pen, new Rectangle(10, 10, 40, 40));
            g.DrawRectangle(pen, new Rectangle(78, 10, 40, 40));
            g.DrawString("VS", new Font(new FontFamily("arial"), 8, FontStyle.Bold), Brushes.Blue, new PointF(56, 25));

        }

        public static void drawFinalGraphic(Graphics g, bool b)
        {
            Pen pen = new Pen(Brushes.Blue);
            Brush brush = Brushes.Blue;

            if (b)
            {
                g.DrawString("Victory", new Font(new FontFamily("arial"), 15, FontStyle.Bold), Brushes.Blue, new PointF(33, 15));
            }
            else
            {
                g.DrawString("Lost", new Font(new FontFamily("arial"), 15, FontStyle.Bold), Brushes.Blue, new PointF(40, 15));
            }
            

        }


    }

}


using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using Explorer700Library;
using System.Threading;

namespace SchaereSteiPapier
{
    static class DrawPattern
    {

        public static void drawScore(Graphics g, int playerPoint, int opPoint)
        {
            g.DrawString("You: " + playerPoint, new Font(new FontFamily("arial"), 8, FontStyle.Bold), Brushes.Blue, new PointF(5, 50));
            g.DrawString("Op.: " + opPoint, new Font(new FontFamily("arial"), 8, FontStyle.Bold), Brushes.Blue, new PointF(90, 50));

        }

        public static void drawTimerBottom(Graphics g, int TimeLeft)
        {
            if (TimeLeft != -1)
            {
                g.DrawString(TimeLeft.ToString(), new Font(new FontFamily("arial"), 8, FontStyle.Bold), Brushes.Blue, new PointF(61, 50));
            }
        }

        public static void drawTimerBottomRight(Graphics g, int TimeLeft)
        {
            if (TimeLeft != -1)
            {
                g.DrawString(TimeLeft.ToString(), new Font(new FontFamily("arial"), 8, FontStyle.Bold), Brushes.Blue, new PointF(120, 50));
            }
        }



        public static void drawAttackCoose(Graphics g, Auswahl auswahl)
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

            if((int)auswahl == 0)
            {
                g.DrawImage(Image.FromFile("/home/pi/netcore/SchaereSteiPapier/Ressources/Auswahl/Schere.png"), 42, 8);
            }
            else if((int)auswahl == 1){
                g.DrawImage(Image.FromFile("/home/pi/netcore/SchaereSteiPapier/Ressources/Auswahl/Stein.png"), 43, 7);
            }
            else
            {
                g.DrawImage(Image.FromFile("/home/pi/netcore/SchaereSteiPapier/Ressources/Auswahl/Papier.png"), 44, 4);
            }

        }


        public static void drawBattleGraphic(Graphics g, Auswahl playerWahl, Auswahl opWahl)
        {
            Pen pen = new Pen(Brushes.Blue);
            Brush brush = Brushes.Blue;            

            g.DrawRectangle(pen, new Rectangle(10, 10, 40, 40));
            g.DrawRectangle(pen, new Rectangle(78, 10, 40, 40));
            g.DrawString("VS", new Font(new FontFamily("arial"), 8, FontStyle.Bold), Brushes.Blue, new PointF(56, 25));

            if ((int)playerWahl == 0)
            {
                g.DrawImage(Image.FromFile("/home/pi/netcore/SchaereSteiPapier/Ressources/Ergebniss/Schere.png"), 12, 12);
            }
            else if ((int)playerWahl == 1)
            {
                g.DrawImage(Image.FromFile("/home/pi/netcore/SchaereSteiPapier/Ressources/Ergebniss/Stein.png"), 12, 12);
            }
            else
            {
                g.DrawImage(Image.FromFile("/home/pi/netcore/SchaereSteiPapier/Ressources/Ergebniss/Papier.png"), 12, 12);
            }

            if ((int)opWahl == 0)
            {
                g.DrawImage(Image.FromFile("/home/pi/netcore/SchaereSteiPapier/Ressources/Ergebniss/Schere.png"), 80, 12);
            }
            else if ((int)opWahl == 1)
            {
                g.DrawImage(Image.FromFile("/home/pi/netcore/SchaereSteiPapier/Ressources/Ergebniss/Stein.png"), 80, 12);
            }
            else
            {
                g.DrawImage(Image.FromFile("/home/pi/netcore/SchaereSteiPapier/Ressources/Ergebniss/Papier.png"), 80, 12);
            }

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

        public static void drawLodingGraphic(Graphics g, Explorer700 board)
        {
            Pen pen = new Pen(Brushes.Blue);
            Pen penRed = new Pen(Brushes.Red);
            g.DrawImage(Image.FromFile("/home/pi/netcore/SchaereSteiPapier/Ressources/Auswahl/Schere.png"), 0, 0);
            board.Display.Update();
            Thread.Sleep(500);
            g.DrawImage(Image.FromFile("/home/pi/netcore/SchaereSteiPapier/Ressources/Auswahl/Stein.png"), 36, 26);
            board.Display.Update();
            Thread.Sleep(500);
            g.DrawImage(Image.FromFile("/home/pi/netcore/SchaereSteiPapier/Ressources/Auswahl/Papier.png"), 82, 0);
            

        }

        public static void drawMaxPointGraphic(Graphics g, int maxPoint)
        {

            g.DrawString("Wähle anzahl Siege:", new Font(new FontFamily("arial"), 8, FontStyle.Bold), Brushes.Red, new PointF(10, 10));
            g.DrawString(maxPoint.ToString(), new Font(new FontFamily("arial"), 8, FontStyle.Bold), Brushes.White, new PointF(57, 25));

        }


        public static void drawReplayGraphic(Graphics g)
        {

            g.DrawString("Press \"Center\"", new Font(new FontFamily("arial"), 8, FontStyle.Bold), Brushes.Red, new PointF(10, 20));
            g.DrawString("for Replay", new Font(new FontFamily("arial"), 8, FontStyle.Bold), Brushes.Red, new PointF(10, 40));


        }


    }

}


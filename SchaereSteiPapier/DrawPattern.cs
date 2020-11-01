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

        public static void drawTimerBottom(Graphics g, int TimeLeft)
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
       //     g.DrawImage(Image.FromFile("/home/pi/netcore/SchaereSteiPapier/Ressources/Auswahl/Schere.png"), 42, 8);
            g.DrawImage(Image.FromFile("/home/pi/netcore/SchaereSteiPapier/Ressources/Auswahl/Stein.png"), 42, 3);
      //      g.DrawImage(Image.FromFile("/home/pi/netcore/SchaereSteiPapier/Ressources/Auswahl/Papier.png"), 41, 1);
            g.FillPolygon(brush, pointsLeft);
            g.FillPolygon(brush, pointsRight);
        }


        public static void drawBattleGraphic(Graphics g)
        {
            Pen pen = new Pen(Brushes.Blue);
            Brush brush = Brushes.Blue;            

            g.DrawRectangle(pen, new Rectangle(10, 10, 40, 40));
             //    g.DrawImage(Image.FromFile("/home/pi/netcore/SchaereSteiPapier/Ressources/Ergebniss/Schere.png"), 12, 12);
            //      g.DrawImage(Image.FromFile("/home/pi/netcore/SchaereSteiPapier/Ressources/Ergebniss/Stein.png"), 12, 12);
                  g.DrawImage(Image.FromFile("/home/pi/netcore/SchaereSteiPapier/Ressources/Ergebniss/Papier.png"), 12, 12);
            g.DrawRectangle(pen, new Rectangle(78, 10, 40, 40));
            //     g.DrawImage(Image.FromFile("/home/pi/netcore/SchaereSteiPapier/Ressources/Ergebniss/Schere.png"), 80, 12);
            //      g.DrawImage(Image.FromFile("/home/pi/netcore/SchaereSteiPapier/Ressources/Ergebniss/Stein.png"), 80, 12);
                  g.DrawImage(Image.FromFile("/home/pi/netcore/SchaereSteiPapier/Ressources/Ergebniss/Papier.png"), 80, 12);
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

        public static void drawLodingGraphic(Graphics g)
        {
            Pen pen = new Pen(Brushes.Blue);
            Pen penRed = new Pen(Brushes.Red);
            g.DrawImage(Image.FromFile("/home/pi/netcore/SchaereSteiPapier/Ressources/Auswahl/Schere.png"), 0, 0);
            g.DrawImage(Image.FromFile("/home/pi/netcore/SchaereSteiPapier/Ressources/Auswahl/Stein.png"), 36, 26);
            g.DrawImage(Image.FromFile("/home/pi/netcore/SchaereSteiPapier/Ressources/Auswahl/Papier.png"), 82, 0);

        }

        public static void drawMaxPointGraphic(Graphics g, int maxPoint)
        {

            g.DrawString("Wähle anzahl Siege:", new Font(new FontFamily("arial"), 8, FontStyle.Bold), Brushes.Red, new PointF(10, 50));
            g.DrawString(maxPoint.ToString(), new Font(new FontFamily("arial"), 8, FontStyle.Bold), Brushes.White, new PointF(57, 25));

        }





    }

}


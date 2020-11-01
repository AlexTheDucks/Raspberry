using System;
using System.Threading;
using Explorer700Library;
using System.Drawing;
using System.Security.Cryptography.X509Certificates;

namespace SchaereSteiPapier
{
    class Program
    {

        public static int maxpoit = 3;
        static Explorer700 board = new Explorer700();


        static void Main(string[] args)
        {
            Console.WriteLine("Fuck Git-.-");

            

            
            Graphics g = board.Display.Graphics;
            //g.DrawImage(Image.FromFile(".Explorer700Library/Explorer700-Demo/Ressources/test.png"), 0, 0);
            Pen pen = new Pen(Brushes.Blue);
            Pen penRed = new Pen(Brushes.Red);
            g.DrawEllipse(pen, -10, -10, 30, 30);
            g.DrawEllipse(penRed, 30, 10, 10, 10);
            pen.Width = 2;
            g.DrawBezier(pen, new Point(10, 30), new Point(30, 30), new Point(70, 40), new Point(75, 5));
            g.DrawString("Fuck Git-.-", new Font(new FontFamily("arial"), 3, FontStyle.Bold), Brushes.Blue, new PointF(5, 50));
            board.Display.Update();
            Thread.Sleep(3000);
            g.Clear(default);
            board.Display.Update();
            
            int x = 5;
            for (int i = 0; i < 5; i++)
            {
                g.DrawString("Wähle anzahl Siege in", new Font(new FontFamily("arial"), 8, FontStyle.Bold), Brushes.Red, new PointF(5, 10));
                g.DrawString(" " + x, new Font(new FontFamily("arial"), 8, FontStyle.Bold), Brushes.White, new PointF(57, 25));
                board.Display.Update();
                Thread.Sleep(1000);
                g.Clear(default);
                board.Display.Update();
                x--;
            }


            board.Joystick.JoystickChanged += Joystick_MaxPoint;
            Thread.Sleep(5000);

            
            board.Joystick.JoystickChanged -= Joystick_MaxPoint;
            Game play = new Game(maxpoit,board);
            play.battle();
           
        }



        private static void Joystick_MaxPoint(object sender, KeyEventArgs e)
        {
            if ((e.Keys & Keys.Left) != 0)
            {
                maxpoit--;
                Console.WriteLine(maxpoit);
            }
            if ((e.Keys & Keys.Right) != 0)
            {
                maxpoit++;
                Console.WriteLine(maxpoit);
            }

            Graphics g = board.Display.Graphics;
            g.Clear(default);
            board.Display.Update();
            g.DrawString("Anzahl Siege : " + maxpoit.ToString(), new Font(new FontFamily("arial"), 8, FontStyle.Bold), Brushes.Blue, new PointF(10, 50));
            board.Display.Update();
        }
    }
}

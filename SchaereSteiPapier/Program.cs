using System;
using System.Threading;
using Explorer700Library;
using System.Drawing;
using System.Security.Cryptography.X509Certificates;

namespace SchaereSteiPapier
{
    class Program
    {

        public static int maxpoint = 3;
        static Explorer700 board = new Explorer700();


        static void Main(string[] args)
        {
            Console.WriteLine("Fuck Git-.-");

            

            
            Graphics g = board.Display.Graphics;
            Pen pen = new Pen(Brushes.Blue);
            Pen penRed = new Pen(Brushes.Red);
            g.DrawImage(Image.FromFile("/home/pi/netcore/SchaereSteiPapier/Ressources/Ergebniss/Schere.png"), 0, 0);
            g.DrawImage(Image.FromFile("/home/pi/netcore/SchaereSteiPapier/Ressources/Ergebniss/Stein.png"), 36, 26);
            g.DrawImage(Image.FromFile("/home/pi/netcore/SchaereSteiPapier/Ressources/Ergebniss/Papier.png"), 82, 0);
            board.Display.Update();
            Thread.Sleep(3000);
            g.Clear(default);
            board.Display.Update();
            
            int x = 5;
            for (int i = 0; i < 1; i++)
            {
                g.DrawString("Wähle anzahl Siege in", new Font(new FontFamily("arial"), 8, FontStyle.Bold), Brushes.Red, new PointF(5, 10));
                g.DrawString(" " + x, new Font(new FontFamily("arial"), 8, FontStyle.Bold), Brushes.White, new PointF(57, 25));
                board.Display.Update();
                Thread.Sleep(1000);
                g.Clear(default);
                board.Display.Update();
                x--;
            }

            g.Clear(default);
            board.Display.Update();
            g.DrawString("Anzahl Siege : ", new Font(new FontFamily("arial"), 8, FontStyle.Bold), Brushes.Blue, new PointF(10, 50));
            board.Display.Update();

            board.Joystick.JoystickChanged += Joystick_MaxPoint;
            // g.DrawString(" " + maxpoint.ToString(), new Font(new FontFamily("arial"), 8, FontStyle.Bold), Brushes.Blue, new PointF(50, 50));
            Thread.Sleep(5000);

            
            board.Joystick.JoystickChanged -= Joystick_MaxPoint;
            Game play = new Game(maxpoint,board);
            play.battle();
           
        }



        private static void Joystick_MaxPoint(object sender, KeyEventArgs e)
        {
            Graphics g = board.Display.Graphics;
            if ((e.Keys & Keys.Left) != 0)
            {
                maxpoint--;
                Console.WriteLine(maxpoint);
              //  g.DrawString(" " + maxpoint, new Font(new FontFamily("arial"), 8, FontStyle.Bold), Brushes.Blue, new PointF(40, 50));
            }
            if ((e.Keys & Keys.Right) != 0)
            {
                maxpoint++;
                Console.WriteLine(maxpoint);
               // g.DrawString(" " + maxpoint, new Font(new FontFamily("arial"), 8, FontStyle.Bold), Brushes.Blue, new PointF(40, 50));
            }

        }
    }
}

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


            DrawingMethods.drawLoadingScreen(board);
            
            
            
            
            for (int i = 5; i >= 0; i--)
            {
                DrawingMethods.drawMaxPointScreen(board,maxpoint,i);
            }


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

            DrawingMethods.drawMaxPointScreen(board, maxpoint, -1);

        }
    }
}

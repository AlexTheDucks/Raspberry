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

            board.Joystick.JoystickChanged += Joystick_MaxPoint;


            for (int i = 5; i >= 0; i--)
            {
                DrawingMethods.drawMaxPointScreen(board,maxpoint,i);
                Thread.Sleep(1000);
            }            
            
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
            }
            if ((e.Keys & Keys.Right) != 0)
            {
                maxpoint++;
                Console.WriteLine(maxpoint);                
               
            }

            DrawingMethods.drawMaxPointScreen(board, maxpoint, -1);

        }
    }
}

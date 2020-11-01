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
        static int timeLeft;
        static bool replay;


        static void Main(string[] args)
        {
           
            DrawingMethods.drawLoadingScreen(board);

            do
            {
                playerSetMaxPoint();

                Game play = new Game(maxpoint, board);

                play.battle();

                replay = false;
                board.Joystick.JoystickChanged += Joystick_Replay;
                for (int i = 5; i >= 0; i--)
                {
                    if (!replay)
                    {
                        timeLeft = i;
                        DrawingMethods.drawReplayScreen(board, timeLeft);
                        Thread.Sleep(1000);
                    }
                    else
                    {
                        break;
                    }
                    
                }
                board.Joystick.JoystickChanged -= Joystick_Replay;
            } while (replay);

            DrawingMethods.clearScreen(board);
           
            
           
        }


        static private void playerSetMaxPoint()
        {
            board.Joystick.JoystickChanged += Joystick_MaxPoint;


            for (int i = 5; i >= 0; i--)
            {
                timeLeft = i;
                DrawingMethods.drawMaxPointScreen(board, maxpoint, timeLeft);
                Thread.Sleep(1000);
            }

            board.Joystick.JoystickChanged -= Joystick_MaxPoint;
        }



        private static void Joystick_MaxPoint(object sender, KeyEventArgs e)
        {
            
            if ((e.Keys & Keys.Left) != 0)
            {
                if (maxpoint>1)
                {
                    maxpoint--;
                }
                
                Console.WriteLine(maxpoint);
            }
            if ((e.Keys & Keys.Right) != 0)
            {
                maxpoint++;
                Console.WriteLine(maxpoint);                
               
            }

            DrawingMethods.drawMaxPointScreen(board, maxpoint, timeLeft);

        }

        private static void Joystick_Replay(object sender, KeyEventArgs e)
        {
                      
            if ((e.Keys & Keys.Center) != 0)
            {
                replay = true;                                
            }

        }
    }
}

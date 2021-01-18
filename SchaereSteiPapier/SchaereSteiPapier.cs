using System;
using System.Threading;
using Explorer700Library;
using System.Drawing;
using System.Security.Cryptography.X509Certificates;

namespace SchaereSteiPapier
{
    class SchaereSteiPapier
    {

        public static int maxpoint = 3;
        static Explorer700 board = new Explorer700();
        static int timeLeft;
        static bool replay;


        static void Main(string[] args)
        {
            
            // Loding Screen
            DrawingMethods.drawLoadingScreen(board);

            // do while for replaying the game
            do
            {
                playerSetMaxPoint();

                //Create and Start the game
                Game play = new Game(maxpoint, board);
                play.start();

                //Restet replay Variable
                replay = false;

                //Register Event Handler
                board.Joystick.JoystickChanged += Joystick_Replay;

                Console.WriteLine("Press \"Center\" for Replay");

                //For loop to controll the timer
                for (int i = 5; i >= 0; i--)
                {
                    //Checking to breake the waiting Screen for replay 
                    if (!replay)
                    {
                        
                        timeLeft = i;
                        DrawingMethods.drawReplayScreen(board, timeLeft);
                        Thread.Sleep(1000);
                    }
                    else
                    {
                        break;
                        Console.WriteLine("--> Replay");
                    }
                    
                }
                board.Joystick.JoystickChanged -= Joystick_Replay;
            } while (replay);

            DrawingMethods.clearScreen(board);
           
            
           
        }

        // Set max point Screen
        static private void playerSetMaxPoint()
        {
            board.Joystick.JoystickChanged += Joystick_MaxPoint;
            Console.WriteLine("Maxpoint is: " + maxpoint);

            for (int i = 5; i >= 0; i--)
            {
                timeLeft = i;
                DrawingMethods.drawMaxPointScreen(board, maxpoint, timeLeft);
                Thread.Sleep(1000);
            }

            board.Joystick.JoystickChanged -= Joystick_MaxPoint;
        }


        // Checking for chainging the points to winn
        private static void Joystick_MaxPoint(object sender, KeyEventArgs e)
        {
            
            if ((e.Keys & Keys.Left) != 0)
            {
                // blocking max point lesser then 1
                if (maxpoint>1)
                {
                    maxpoint--;
                }
                
                Console.WriteLine("Maxpoint set to: "+maxpoint);
            }
            if ((e.Keys & Keys.Right) != 0)
            {
                maxpoint++;
                Console.WriteLine("Maxpoint set to: " + maxpoint);                
               
            }
            // Change picture on the Screen
            DrawingMethods.drawMaxPointScreen(board, maxpoint, timeLeft);

        }

        private static void Joystick_Replay(object sender, KeyEventArgs e)
        {
            
            // if center butten is presst the Replay variable is set to true
            if ((e.Keys & Keys.Center) != 0)
            {
                replay = true;                                
            }

        }
    }
}

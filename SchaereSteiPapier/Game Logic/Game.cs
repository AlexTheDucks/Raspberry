using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.Reflection.Emit;
using System.Text;
using System.Threading;
using Explorer700Library;
using System.Drawing;

namespace SchaereSteiPapier
{
    class Game
    {

        //static variables to be accessed by event handler
        static Explorer700 board;
        AIOponent op = new AIOponent();
        int maxPoint;
        static int opPoint = 0;
        static int playerPoint = 0;
        static Auswahl playerWahl = (Auswahl)0;
        static int timeLeft;

        public Game(int maxPoint, Explorer700 boardgiven)
        {
            board = boardgiven;
            board.Joystick.JoystickChanged += Joystick_ChooseRoundInput;
            this.maxPoint = maxPoint;
            opPoint = 0;
            playerPoint = 0;

        }

        //Starting the Game
        public void start()
        {
            Console.WriteLine("Gamestart");
            while (checkScore())
            {
                round();
            }

            board.Joystick.JoystickChanged -= Joystick_ChooseRoundInput;

            Console.WriteLine("------------");
            Console.WriteLine("------------");

            //load the End Game Screen
            if (playerPoint >= maxPoint)
            {
                DrawingMethods.drawFinalScreen(board,true);
                Console.WriteLine("You have won the Game");
            }
            else
            {
                DrawingMethods.drawFinalScreen(board,false);
                Console.WriteLine("You have Lost the Game");
            }

                       
        }

       //making a Turn
        private void round()
        {
            //Choosing your input
            Console.WriteLine("------------");
            Console.WriteLine("Input is: " + playerWahl);

            for (int i=5; i>=0; i--)
            {
                timeLeft = i;
                DrawingMethods.drawChooseRoundInputScreen(board, playerPoint, opPoint,timeLeft,playerWahl);
                Thread.Sleep(1000);
            }

            

            // AI choose his input
            Auswahl opWahl = op.yourTurn();

            WinnOrLose w = selectWinner(playerWahl, opWahl);

            // just console
            if (w == (WinnOrLose)1)
            {
                playerPoint++;
                Console.WriteLine("You have won this round");
            }
            else if (w == (WinnOrLose)2)
            {
                opPoint++;
                Console.WriteLine("You have lost this rounde");
            }
            else
            {
                Console.WriteLine("It was a draw");
            }

            //Loads the Compare Screan
            DrawingMethods.drawCompareScreen(board,playerPoint,opPoint,playerWahl,opWahl);
            Thread.Sleep(3000);


        }

        //Selects the winner
        private WinnOrLose selectWinner (Auswahl player, Auswahl oponent)
        {
            int w = player - oponent;
            if(w==-2 | w == 1)
            {
                return (WinnOrLose)1;
            }
            if (w == 0)
            {
                return (WinnOrLose)0;
            }
            return (WinnOrLose)2;
        }


        //Checks if the game is finished
        private bool checkScore()
        {
            if(playerPoint>=maxPoint | opPoint >= maxPoint)
            {
                Console.WriteLine("End Game");
                return false;
                
            }
            Console.WriteLine("Score: Player " + playerPoint + ", Oponent " + opPoint);
            
            return true;
         
        }

      

       
        //Event Handler for selecting the Input
        private static void Joystick_ChooseRoundInput(object sender, KeyEventArgs e)
        {


            if ((e.Keys & Keys.Left) != 0)
            {
                // +2 == -1
                int playerint = ((int)playerWahl+2) % 3;
                playerWahl = (Auswahl)playerint;
                Console.WriteLine("Input is changed to: " + playerWahl);
            }
            if ((e.Keys & Keys.Right) != 0)
            {
                int playerint = ((int)playerWahl + 1) % 3;
                playerWahl = (Auswahl)playerint;
                Console.WriteLine("Input is changed to: " + playerWahl);
            }


            DrawingMethods.drawChooseRoundInputScreen(board, playerPoint, opPoint, timeLeft, playerWahl);


        }
    }
}

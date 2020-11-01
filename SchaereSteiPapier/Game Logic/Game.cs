﻿using System;
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
            while (checkScore())
            {
                round();
            }

            board.Joystick.JoystickChanged -= Joystick_ChooseRoundInput;


            //load the End Game Screen
            if (playerPoint >= maxPoint)
            {
                DrawingMethods.drawFinalScreen(board,true);

            }
            else
            {
                DrawingMethods.drawFinalScreen(board,false);
            }

                       
        }

       //making a Turn
        private void round()
        {
            //Choosing your input
            for(int i=5; i>=0; i--)
            {
                timeLeft = i;
                DrawingMethods.drawChooseRoundInputScreen(board, playerPoint, opPoint,timeLeft,playerWahl);
                Thread.Sleep(1000);
            }

            Console.WriteLine("------------");
            Console.WriteLine("Attack");
            
            // AI choose his input
            Auswahl opWahl = op.yourTurn();

            WinnOrLose w = selectWinner(playerWahl, opWahl);

            // just console
            if (w == (WinnOrLose)1)
            {
                playerPoint++;
                Console.WriteLine("Win");
            }
            else if (w == (WinnOrLose)2)
            {
                opPoint++;
                Console.WriteLine("Loose");
            }
            else
            {
                Console.WriteLine("Draw");
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
                Console.WriteLine(playerWahl);
            }
            if ((e.Keys & Keys.Right) != 0)
            {
                int playerint = ((int)playerWahl + 1) % 3;
                playerWahl = (Auswahl)playerint;
                Console.WriteLine(playerWahl);
            }


            DrawingMethods.drawChooseRoundInputScreen(board, playerPoint, opPoint, timeLeft, playerWahl);


        }
    }
}
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
        Explorer700 board;
        AIOponent op = new AIOponent();
        int maxPoint;
        static int opPoint = 0;
        static int playerPoint = 0;
        static Auswahl playerWahl = (Auswahl)0;

        public Game(int maxPoint, Explorer700 boardgiven)
        {
            board = boardgiven;
            board.Joystick.JoystickChanged += Joystick_ChooseAttack;
            this.maxPoint = maxPoint;           
        }

        public WinnOrLose battle()
        {
            while (checkScore())
            {
                attack();
            }

            if (playerPoint >= maxPoint)
            {
                return (WinnOrLose)1;
            }
            else
            {
                return (WinnOrLose)2;
            }


            
        }

        private void attack()
        {
            Console.WriteLine("------------");
            Console.WriteLine("Attack");
            Thread.Sleep(8000);
            Auswahl opWahl = op.yourTurn();

            WinnOrLose w = selectWinner(playerWahl, opWahl);

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


        }

        private WinnOrLose selectWinner (Auswahl player, Auswahl oponent)
        {
            int w = player - oponent;
            if(w==-2 | w == -1)
            {
                return (WinnOrLose)1;
            }
            if (w == 0)
            {
                return (WinnOrLose)0;
            }
            return (WinnOrLose)2;
        }


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

        private static void Joystick_ChooseAttack(object sender, KeyEventArgs e)
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

           
           


        }
    }
}

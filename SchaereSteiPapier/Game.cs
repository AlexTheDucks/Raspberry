using Game;
using System;
using System.Collections.Generic;
using System.Reflection.Emit;
using System.Text;

namespace SchaereSteiPapier
{
    class Game
    {
        AIOponent op = new AIOponent();
        int maxPoint;
        int opPoint = 0;
        int playerPoint = 0;

        public Game(int maxPoint)
        {
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
            //Spieler Auswahl muss implementiert werden
            Auswahl playerWahl = (Auswahl)0;

            Auswahl opWahl = op.yourTurn();

            WinnOrLose w = selectWinner(playerWahl, opWahl);

            if (w == (WinnOrLose)1)
            {
                playerPoint++;
            }
            else if (w == (WinnOrLose)2)
            {
                opPoint++;
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
                return false;
            }
            return true;
        }

    }
}

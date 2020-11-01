using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using Explorer700Library;
using System.Threading;

namespace SchaereSteiPapier
{
    //Constructed Screens with Drawing Patterns
    static class DrawingMethods
    {


        // Super nice loading screean
        public static void drawLoadingScreen(Explorer700 board)
        {

            Graphics g = board.Display.Graphics;

            g.Clear(default);

            DrawPattern.drawLodingGraphic(g, board);

            board.Display.Update();
            Thread.Sleep(2000);

        }

        // Screan to Select the Max Point
        public static void drawMaxPointScreen(Explorer700 board, int maxPoint, int timeLeft)
        {

            Graphics g = board.Display.Graphics;

            g.Clear(default);

            DrawPattern.drawMaxPointGraphic(g, maxPoint);
            DrawPattern.drawTimerBottomRightGraphic(g, timeLeft);

            board.Display.Update();


        }


        //Screen for choosing the input
        public static void drawChooseRoundInputScreen(Explorer700 board, int playerPoint, int opPoint, int TimeLeft, Auswahl auswahl)
        {
            Graphics g = board.Display.Graphics;

            g.Clear(default);

            DrawPattern.drawChosenImputGraphic(g,auswahl);
            DrawPattern.drawTimerBottomCenterGraphic(g, TimeLeft);
            DrawPattern.drawScoreGraphic(g, playerPoint, opPoint);

            board.Display.Update();
            
        }

        //Screen for comparing the input
        public static void drawCompareScreen(Explorer700 board, int playerPoint, int opPoint, Auswahl playerWahl, Auswahl opWahl)
        {
            Graphics g = board.Display.Graphics;

            g.Clear(default);

            DrawPattern.drawCompareGraphic(g,playerWahl,opWahl);            
            DrawPattern.drawScoreGraphic(g, playerPoint, opPoint);

            board.Display.Update();
            
        }

        //Screen for showing the final result (Victory/Lost)
        public static void drawFinalScreen(Explorer700 board, bool WinOrLoose)
        {
            Graphics g = board.Display.Graphics;

            g.Clear(default);

            DrawPattern.drawFinalGraphic(g, WinOrLoose);

            board.Display.Update();
            if (WinOrLoose)
            {
               // Sound.vicorySound(board); 
            }
            
            Thread.Sleep(3000);
           
            
        }
        
        //draws the Replay Screen 
        public static void drawReplayScreen(Explorer700 board, int timeLeft)
        {

            Graphics g = board.Display.Graphics;

            g.Clear(default);

            DrawPattern.drawReplayGraphic(g);
            DrawPattern.drawTimerBottomRightGraphic(g, timeLeft);

            board.Display.Update();


        }

        //clears the screen to close the Programm
        public static void clearScreen(Explorer700 board)
        {
            Graphics g = board.Display.Graphics;

            g.Clear(default);

            board.Display.Update();
        }




    }

}

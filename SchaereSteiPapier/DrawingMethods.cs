using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using Explorer700Library;
using System.Threading;

namespace SchaereSteiPapier
{
    static class DrawingMethods
    {
        public static void drawAttackChooseScreen(Explorer700 board, int playerPoint, int opPoint, int TimeLeft)
        {
            Graphics g = board.Display.Graphics;

            g.Clear(default);

            DrawPattern.drawAttackCoose(g);
            DrawPattern.drawTimer(g, TimeLeft);
            DrawPattern.drawScore(g, playerPoint, opPoint);

            board.Display.Update();
            
        }

        public static void drawBattleScreen(Explorer700 board, int playerPoint, int opPoint)
        {
            Graphics g = board.Display.Graphics;

            g.Clear(default);

            DrawPattern.drawBattleGraphic(g);            
            DrawPattern.drawScore(g, playerPoint, opPoint);

            board.Display.Update();
            
        }


        public static void drawFinalScreen(Explorer700 board, bool WinOrLoose)
        {
            Graphics g = board.Display.Graphics;

            g.Clear(default);

            DrawPattern.drawFinalGraphic(g, WinOrLoose);

            board.Display.Update();
            Thread.Sleep(10000);
            g.Clear(default);
            board.Display.Update();
            
        }


    }
      
}

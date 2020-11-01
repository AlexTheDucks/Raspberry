using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using Explorer700Library;

namespace SchaereSteiPapier
{
    static class DrawingMethods
    {
        public static Graphics drawAttackChooseScreen(Explorer700 board, int playerPoint, int opPoint, int TimeLeft)
        {
            Graphics g = board.Display.Graphics;

            g.Clear(default);

            DrawPattern.drawAttackCoose(g);
            DrawPattern.drawTimer(g, TimeLeft);
            DrawPattern.drawScore(g, playerPoint, playerPoint);

            board.Display.Update();
            return g;
        }

        public static Graphics drawBattleScreen(Explorer700 board, int playerPoint, int opPoint)
        {
            Graphics g = board.Display.Graphics;

            g.Clear(default);

            DrawPattern.drawBattleGraphic(g);            
            DrawPattern.drawScore(g, playerPoint, playerPoint);

            board.Display.Update();
            return g;
        }



    }
      
}

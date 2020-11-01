using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using Explorer700Library;

namespace SchaereSteiPapier
{
    static class Sound
    {
        
        public static void vicorySound(Explorer700 board)
        {
            board.Buzzer.Beep(100);
            Thread.Sleep(80);
            board.Buzzer.Beep(100);
            Thread.Sleep(80);
            board.Buzzer.Beep(100);
            Thread.Sleep(80);
            board.Buzzer.Beep(100);
            Thread.Sleep(250);
            board.Buzzer.Beep(100);
            Thread.Sleep(50);
            board.Buzzer.Beep(200);
            
        }
            

    }
}

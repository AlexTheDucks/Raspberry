using Swan;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace SW04_Explorer700
{
    class Mainclass
    {
        static void Main(string[] args)
        {
            Explorer700 exp = new Explorer700();
            exp.Led2.Toggle();

         //   exp.Display.Test_();

            for (int i = 0; i < 10; i++)
            {
                exp.Led1.Toggle();
                exp.Led2.Toggle();
                Thread.Sleep(500);

            }

            exp.Led1.Toggle();

            Thread.Sleep(2000);

            exp.Buzzer.Beep(100);

            exp.Led1.Enabled = false;
            exp.Led2.Enabled = true;

            exp.Joystick.JoystickChanged += Joystick_JoystickChanged;

            Console.ReadKey();
          
        }


        private static void Joystick_JoystickChanged(object sender, KeyEventArgs e)
        {
            Console.WriteLine("Joystick: " + e.Keys);

        }
    }
}

using System;
using Explorer700Library;

namespace SchaereSteiPapier
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            Random rand = new Random();

            Explorer700 board = new Explorer700();

            board.Joystick.JoystickChanged += Joystick_JoystickChanged;

            Game play = new Game(3);
           
        }



        private static void Joystick_JoystickChanged(object sender, KeyEventArgs e)
        {
            Console.WriteLine("Joystick: " + e.Keys);

            if ((e.Keys & Keys.Up) != 0)
            {
                Console.WriteLine("Up");
            }

            if ((e.Keys & Keys.Up) == Keys.Up)
            {

            }

        }
    }
}

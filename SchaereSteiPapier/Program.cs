using System;
using System.Threading;
using Explorer700Library;

namespace SchaereSteiPapier
{
    class Program
    {

        public static int maxpoit = 3;


        static void Main(string[] args)
        {
            Console.WriteLine("Fuck Git-.-");
            Random rand = new Random();

            Explorer700 board = new Explorer700();

            board.Joystick.JoystickChanged += Joystick_MaxPoint;
            Thread.Sleep(5000);
            board.Joystick.JoystickChanged -= Joystick_MaxPoint;
            Game play = new Game(maxpoit,board);
            play.battle();
           
        }



        private static void Joystick_MaxPoint(object sender, KeyEventArgs e)
        {

            


            if ((e.Keys & Keys.Left) != 0)
            {
                maxpoit--;
                Console.WriteLine(maxpoit);
            }
            if ((e.Keys & Keys.Right) != 0)
            {
                maxpoit++;
                Console.WriteLine(maxpoit);
            }

            // Display Val

           


        }
    }
}

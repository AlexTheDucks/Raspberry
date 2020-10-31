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

            Explorer700 Board = new Explorer700();

            Game play = new Game(3);
        }
    }
}

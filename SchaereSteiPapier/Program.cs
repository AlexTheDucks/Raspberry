using System;
using Explorer700Library;

namespace Game
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            Random rand = new Random();
            for(int i = 0; i<10; i++)
            {
                Console.WriteLine(rand.Next(3));
            }
        }
    }
}

using System;

    class Program
    {
        static void RemoveScrollBars()
        {
            Console.BufferWidth = Console.WindowWidth;
            Console.BufferHeight = Console.WindowHeight;
        }

        static void Main()
        {
            RemoveScrollBars();
      
        }
    }


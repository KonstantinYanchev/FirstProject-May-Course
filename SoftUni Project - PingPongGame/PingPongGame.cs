using System;
using System.Threading;

class Program
{
    static int firstPlayerPlankSize = 6;
    static int secondPlayerPlankSize = 6;
    static int ballPositionX = 0;
    static int ballPositionY = 0;
    static int firstPlayerPosition = (Console.WindowHeight / 2) - (firstPlayerPlankSize / 2);//Middle position of the console.
    static int secondPlayerPosition = (Console.WindowHeight / 2) - (firstPlayerPlankSize / 2);//Middle position of the console.
    static void RemoveScrollBars()
    {
        Console.BufferWidth = Console.WindowWidth;
        Console.BufferHeight = Console.WindowHeight;
    }

    static void DrawFirstPlayer()
    {
        for (int i = firstPlayerPosition; i < firstPlayerPosition + firstPlayerPlankSize; i++)
        {
            PrintAtPosition(0, i, '0');
            PrintAtPosition(1, i, '|');
        }
    }

    static void DrawSecondPlayer()
    {
        for (int i = secondPlayerPosition; i < secondPlayerPosition + secondPlayerPlankSize; i++)
        {
            PrintAtPosition(Console.WindowWidth - 1, i, '0');
            PrintAtPosition(Console.WindowWidth - 2, i, '|');

        }
    }
    static void PrintAtPosition(int col, int row, char plankSymbol)
    {
        Console.SetCursorPosition(col, row);
        Console.Write(plankSymbol);
    }
    static void Main()
    {
        RemoveScrollBars();
        while (true)
        {
            DrawFirstPlayer();
            DrawSecondPlayer();
            Console.WriteLine();
            Thread.Sleep(60);
        }
    }
}


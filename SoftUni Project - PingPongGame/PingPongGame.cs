using System;
using System.Threading;

class Program
{
    static int firstPlayerPlankSize = 6;
    static int secondPlayerPlankSize = 6;
    static int ballPositionX = Console.WindowWidth / 2;//middle ball position on the console
    static int ballPositionY = Console.WindowHeight / 2;//middle ball position on the console
    static int firstPlayerPosition = (Console.WindowHeight / 2) - (firstPlayerPlankSize / 2);//Middle position of the console.
    static int secondPlayerPosition = (Console.WindowHeight / 2) - (firstPlayerPlankSize / 2);//Middle position of the console.
    static int firstPlayerPoints = 0;
    static int secondPlayerPoints = 0;
    static Random move=new Random();
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
    static void DrawBall()
    {
        PrintAtPosition(ballPositionX, ballPositionY, '*');
    }

    static void Results()
    {
        Console.SetCursorPosition(Console.WindowWidth / 2 - 1, 0);
        Console.Write("{0}-{1}", firstPlayerPoints, secondPlayerPoints);
    }

    static void FirstPlayerDown()
    {
        if (firstPlayerPosition<Console.WindowHeight-firstPlayerPlankSize)
        {
             firstPlayerPosition++;
        }                 
    }
    static void FirstPlayerUp()
    {
        if (firstPlayerPosition > 0)
        {
            firstPlayerPosition--;
        }

    }
    static void SecondPlayerDown()
    {
        if (secondPlayerPosition < Console.WindowHeight - secondPlayerPlankSize)
        {
            secondPlayerPosition++;
        }
    }
    static void SecondPlayerUp()
    {
        if (secondPlayerPosition > 0)
        {
            secondPlayerPosition--;
        }
    }

    static void SecondPlayerMovemend()
    {
      int randomNum=move.Next(0, 2);
        if (randomNum == 0)
        {
            SecondPlayerUp();
        }
        if (randomNum == 1)
        {
            SecondPlayerDown();
        }
    }
    static void Main()
    {
        RemoveScrollBars();
        while (true)
        {
            if (Console.KeyAvailable)
            {
                ConsoleKeyInfo keys = Console.ReadKey();
                if (keys.Key == ConsoleKey.UpArrow)
                {
                    FirstPlayerUp();
                }
                if (keys.Key == ConsoleKey.DownArrow)
                {
                    FirstPlayerDown();
                }
            }
            SecondPlayerMovemend();
            Console.Clear();
            DrawFirstPlayer();
            DrawSecondPlayer();
            DrawBall();
            Results();
            Thread.Sleep(60);

        }
    }


}


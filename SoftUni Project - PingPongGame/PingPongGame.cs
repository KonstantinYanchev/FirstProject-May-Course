using System;
using System.Threading;

class Program
{
    // Глобални променливи, за да може да се използват във всеки метод без да се деклалират всеки път;
    static int firstPlayerPlankSize = 8;
    static int secondPlayerPlankSize = 8;
    static int ballPositionX = Console.WindowWidth / 2; //Задава за позиция на топчето центъра на конзолата;
    static int ballPositionY = Console.WindowHeight / 2; //Задава за позиция на топчето центъра на конзолата;
    static bool ballUp = true;
    static bool ballDown = true;
    static int firstPlayerPosition = (Console.WindowHeight / 2) - (firstPlayerPlankSize / 2);//Гарантира, че дъските ще бъдат изчертани на средата;
    static int secondPlayerPosition = (Console.WindowHeight / 2) - (firstPlayerPlankSize / 2);//Гарантира, че дъските ще бъдат изчертани на средата;
    static int firstPlayerPoints = 0;
    static int secondPlayerPoints = 0;
    static Random RandomMoveGenerator = new Random();

    static void Main()
    {
        RemoveScrollBars();
        ChangeFontColor();
        while (true)
        {
            if (Console.KeyAvailable) // Без този if, конзолата винаги ще забива след всяко завъртане на цикъла, защото ще чака да прочете някакво копче;
            {
                ConsoleKeyInfo keys = Console.ReadKey();
                if (keys.Key == ConsoleKey.UpArrow)
                {
                    MoveFirstPlayerUp();
                }
                if (keys.Key == ConsoleKey.DownArrow)
                {
                    MoveFirstPlayerDown();
                }
            }
            SecondPlayerMovement();
            BallMovement();
            Console.Clear(); // Изчистваме и преначертаваме всичко отново, за да отразим движението на играчите и топчето;
            DrawFirstPlayer();
            DrawSecondPlayer();
            DrawBall();
            PrintResult();
            Thread.Sleep(40);
        }
    }

    static void RemoveScrollBars()
    {
        Console.BufferWidth = Console.WindowWidth;
        Console.BufferHeight = Console.WindowHeight;
    }

    static void ChangeFontColor()
    {
        Console.ForegroundColor = ConsoleColor.Red;
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

    static void IfSomeoneLoseSetBallInMid()
    {
        ballPositionX = Console.WindowWidth / 2;//middle ball position on the console
        ballPositionY = Console.WindowHeight / 2;//middle ball position on the console
    }
    static void DrawBall()
    {
        PrintAtPosition(ballPositionX, ballPositionY, '*');
    }

    static void PrintResult()
    {
        Console.SetCursorPosition(Console.WindowWidth / 2 - 1, 0);
        Console.Write("{0}-{1}", firstPlayerPoints, secondPlayerPoints);
    }

    static void MoveFirstPlayerDown()
    {
        if (firstPlayerPosition < Console.WindowHeight - firstPlayerPlankSize)
        {
            firstPlayerPosition++;
        }
    }
    static void MoveFirstPlayerUp()
    {
        if (firstPlayerPosition > 0) // С цел да не излизаме извън конзолата и да ни гърми;
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

    static void SecondPlayerMovement()
    {
        int randomNum = RandomMoveGenerator.Next(0, 2);
        //if (randomNum == 0)
        //{
        //    SecondPlayerUp();
        //}                                          //random direction
        //if (randomNum == 1)
        //{
        //    SecondPlayerDown();
        //}
        if (randomNum == 0)//without this if YOU NEVER WIN.With this if you have 50%
        {
            if (ballUp == true)
            {
                SecondPlayerUp();
            }
            else
            {
                SecondPlayerDown();
            }
        }

    }

    static void BallMovement()
    {
        if (ballPositionY == 0)
        {
            ballUp = false; // За да накараме топчето, когато е стигнало до горния ръб на конзолата, да започне да се движи надолу;
        }
        if (ballPositionY == Console.WindowHeight - 1) // За да накараме топчето, когато е стигнало до долния ръб на конзолата, да започне да се движи нагоре;
        {
            ballUp = true;
        }
        if (ballPositionX == Console.WindowWidth - 1) // Щом удари WindowWidth => Някой от играчите е спечелил, в този случай губи компютъра;
        {
            IfSomeoneLoseSetBallInMid(); // Сетва централна позиция на топчето, след като някой е загубил;
            ballDown = false; // задава посока на движение;
            ballUp = true;
            firstPlayerPoints++;
            Console.SetCursorPosition(((Console.WindowWidth / 2) - 5), (Console.WindowHeight / 2) );
            Console.Write("PLAYER WINS!");
            Console.ReadKey();//if someone lose just stop
        }

        if (ballPositionX == 0) // играча губи;
        {
            IfSomeoneLoseSetBallInMid();
            ballDown = true;// задава посока на движение;
            ballUp = true;
            secondPlayerPoints++;
            Console.SetCursorPosition(((Console.WindowWidth / 2) - 6), (Console.WindowHeight / 2) );
            Console.Write("COMPUTER WINS!");
            Console.ReadKey();//if someone lose just stop
        }


        if (ballPositionX < 3)
        {
            if (ballPositionY >= firstPlayerPosition && ballPositionY <= firstPlayerPosition + firstPlayerPlankSize)
            {
                ballDown = true;
            }
        }

        if (ballPositionX >= Console.WindowWidth - 3 - 1)
        {
            if (ballPositionY >= secondPlayerPosition && ballPositionY < secondPlayerPosition + secondPlayerPlankSize)
            {
                ballDown = false;
            }
        }

        if (ballUp)
        {
            ballPositionY--;
        }
        else
        {
            ballPositionY++;
        }
        if (ballDown)
        {
            ballPositionX++;
        }
        else
        {
            ballPositionX--;
        }

    }
}
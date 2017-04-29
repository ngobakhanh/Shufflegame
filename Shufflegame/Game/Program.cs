using System;
namespace Game
{
    class Program
        {
            static void Main(string[] args)
            {
                Console.Title = ("Shuffle Game");
                ShuffleGame fs = new ShuffleGame();
                fs.Interface();
                Console.ReadLine();

            }
        }
    }


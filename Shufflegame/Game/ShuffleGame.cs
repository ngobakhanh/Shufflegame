using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
namespace Game
{
    class ShuffleGame
    {
        int[,] array = new int[3, 3];
        int temp;
        int count = 0;
        public static List<Score> list;
        public void Interface()
        {
            Console.SetCursorPosition(Console.WindowWidth / 2 - "WELCOM TO SHUFFLE GAME".Length / 2, 8);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("WELCOM TO SHUFFLE GAME");
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("--!!----!!-----!!-----!!-----!!-----!!-----!!----!!--");
            Console.SetCursorPosition("--!!-----!!-----!!-----!!-----!!-----!!-----!!-----!!--".Length / 2, 11);
            Console.WriteLine("--!!----!!-----!!-----!!-----!!-----!!-----!!----!!--");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.SetCursorPosition(35, 17);
            Console.WriteLine("PROJECT NAME: SHUFFLE GAME");
            Console.SetCursorPosition(35, 18);
            Console.WriteLine("PROJECT BY: Ngo Ba Khanh");
            Console.SetCursorPosition(35, 19);
            Console.WriteLine("COORDINATOR: Phan Hong Trung");
            Menu();
        }
        public void Frame()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.SetCursorPosition(0, 1);
            Console.Write("Key Presses: {0}", count);
            Console.ResetColor();
            Console.SetCursorPosition(28, 9);
            Console.WriteLine("===================");
            Console.SetCursorPosition(28, 13);
            Console.WriteLine("===================");
            for (int i = 0; i < 5; i++)
            {
                Console.SetCursorPosition(27, i + 9);
                Console.WriteLine("+");
                Console.SetCursorPosition(33, i + 9);
                Console.WriteLine("+");
                Console.SetCursorPosition(41, i + 9);
                Console.WriteLine("+");
                Console.SetCursorPosition(47, i + 9);
                Console.WriteLine("+");
            }
        }
        public void PrintNumber()
        {
            Random ran = new Random();
            int h = 0;
            int[] randomArray = Enumerable.Range(0, 9).OrderBy(x => ran.Next()).ToArray();//in ra dãy số từ 0-9
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    while (h < 9)
                    {
                        Console.SetCursorPosition(j * 7 + 30, i + 10);
                        array[i, j] = randomArray[h];//gán các số vào mảng
                        Console.WriteLine(array[i, j]);
                        h++;
                        break;
                    }
                }
                Console.WriteLine();
            }
        }
        public void AssignValue()
        {
            //Console.ForegroundColor = ConsoleColor.Cyan;
            //Console.SetCursorPosition(0, 1);
            //Console.Write("Key Presses: {0}", count);
            Console.ResetColor();
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (array[i, j] == 0)//gán màu Green ở vị trí có giá trị = 0
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.SetCursorPosition(j * 7 + 30, i + 10);
                        Console.WriteLine(array[i, j]);
                        Console.ResetColor();
                    }
                    else//gán màu đỏ cho các giá trị còn lại
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.SetCursorPosition(j * 7 + 30, i + 10);
                        Console.WriteLine(array[i, j]);
                        Console.ResetColor();
                    }
                }
                Console.WriteLine();
            }
        }
        public void Check()
        {
            if (array[0, 0] == 1
                && array[0, 1] == 2
                && array[0, 2] == 3
                && array[1, 0] == 4
                && array[1, 1] == 5
                && array[1, 2] == 6
                && array[2, 0] == 7
                && array[2, 1] == 8
                && array[2, 2] == 0)
            {
                Console.Clear();
                Console.SetCursorPosition((Console.WindowWidth / 2 - "YOU WIN !!".Length / 2), (Console.WindowHeight / 2));
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("YOU WIN !!");
                Console.SetCursorPosition(30, 15);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Score: {0}", count);
                Console.SetCursorPosition(30, 16);
                Console.Write("Enter your name: ");
                Console.ForegroundColor = ConsoleColor.Magenta;
                string name = Console.ReadLine();
                SaveScore(name, count);
                Console.ResetColor();
                Console.WriteLine("Continue?(Y/N)");
                string answer=Console.ReadLine();
                if (answer.ToUpper().Trim()=="Y")
                {
                    count = 0;
                    Console.Clear();
                    Interface();
                }
                else
                {
                    Environment.Exit(0);
                }
            }
        }
        public void Move()
        {
            try
            {
                for (int i = 0; i < 3; i++)
                {
                    for (int j = 0; j < 3; j++)
                    {
                        while (array[i, j] == 0)
                        {
                            ConsoleKeyInfo move;   //khai bao
                            move = Console.ReadKey();
                            switch (move.Key)
                            {
                                case ConsoleKey.LeftArrow: //di chuyen qua trai
                                    Console.Clear();
                                    temp = array[i, j];
                                    array[i, j] = array[i, j - 1];
                                    array[i, j - 1] = temp;
                                    j = j - 1;
                                    break;


                                case ConsoleKey.UpArrow:  //di chuyen len
                                    Console.Clear();
                                    temp = array[i, j];
                                    array[i, j] = array[i - 1, j];
                                    array[i - 1, j] = temp;
                                    i = i - 1;
                                    break;

                                case ConsoleKey.DownArrow: //di chuyen xuong
                                    Console.Clear();
                                    temp = array[i, j];
                                    array[i, j] = array[i + 1, j];
                                    array[i + 1, j] = temp;
                                    i = i + 1;
                                    break;

                                case ConsoleKey.RightArrow: //di chuyen qua phai
                                    Console.Clear();
                                    temp = array[i, j];
                                    array[i, j] = array[i, j + 1];
                                    array[i, j + 1] = temp;
                                    j = j + 1;
                                    break;
                            }
                            if (move.Key == ConsoleKey.LeftArrow || move.Key == ConsoleKey.RightArrow 
                                || move.Key == ConsoleKey.DownArrow || move.Key == ConsoleKey.UpArrow)
                            { count++; }
                            AssignValue();
                            Frame();
                            Check();
                            End();
                        }
                    }
                }
            }
            catch (Exception)
            {
                Console.WriteLine("You can not move !!");
                Console.WriteLine("Press any key to continue or E to exit...");
                End();
            }

        }
        public void End()
        {
            ConsoleKeyInfo exit;
            exit = Console.ReadKey();
            if (exit.Key == ConsoleKey.E)
            {
                Console.WriteLine("\nDo you want to exit (Y/N)");
                exit = Console.ReadKey();
                if (exit.Key == ConsoleKey.Y)
                {
                    Environment.Exit(0);
                }
                else if (exit.Key == ConsoleKey.N)
                {
                    Resume();//chơi lại
                }
            }
            else
            {
                Resume();
            }
        }
        public void Guide()
        {
            Console.Clear();
            Console.WriteLine("Rule: Arrange the numbers in order from 1-8 using the arrow keys.");
            Back();
        }
        public void Back()
        {
            Console.WriteLine("Press B to back !");
            ConsoleKeyInfo back;
            for (int i = 1; i < 3; i++)
            {
                back = Console.ReadKey();
                if (back.Key == ConsoleKey.B)
                {
                    Console.Clear();
                    Interface();
                    break;
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Press B to back !");
                    i--;
                }
            }
        }
        public void Resume()
        {
            Console.Clear();
            Frame();
            AssignValue();
            Move();
            Check();
            End();
        }
        public void SaveScore(string name,int score)
        {
            FileStream fs = new FileStream("Score.txt", FileMode.Append, FileAccess.Write);
            BinaryWriter bw = new BinaryWriter(fs);
            Score sc = new Score();
            sc.Name = name;
            sc.Keystroce = score;
            bw.WriteScore(sc);

            bw.Flush();
            bw.Close();
            fs.Close();
        }
        public void LoadScore()
        {
            list = new List<Score>();
            using (BinaryReader br = new BinaryReader(new FileStream("Score.txt", FileMode.OpenOrCreate)))
            {
                try
                {
                    while (true)
                    {
                        Score sc = new Score();
                        sc = br.ReadScore();
                        list.Add(sc);
                    }
                }
                catch (EndOfStreamException)
                {
                }
            }
        }

        public void HighScore()
        {
            LoadScore();
            var value = from Score in list orderby Score.Keystroce select Score;
            int y = 3;
            Console.SetCursorPosition(33, 1);
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("-------SCORE-------");
            foreach (Score sc in value)
            {
                Console.SetCursorPosition(36, y);
                sc.Display();
                y++;
            }
            Console.SetCursorPosition(33, y);
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("-------------------");
            Console.ResetColor();
        }
        /*public void HighScore()
        {
            int y = 3;
            Console.SetCursorPosition(33, 1);
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("-------SCORE-------");
            FileStream fs = new FileStream("Score.txt", FileMode.Open, FileAccess.Read);
            BinaryReader br = new BinaryReader(fs);
            try
            {
                while (true)
                {
                    Console.SetCursorPosition(36, y);
                    Score sc = new Score();
                    sc = br.ReadScore();
                    sc.Display();
                    y++;
                }
            }
            catch (EndOfStreamException) { }
            br.Close();
            fs.Close();
            Console.SetCursorPosition(33, y);
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("-------------------");
            Console.ResetColor();
        }*/

        public void Menu()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.SetCursorPosition(10, 16);
            Console.WriteLine("Menu");
            Console.SetCursorPosition(5, 18);
            Console.WriteLine("1. New game");
            Console.SetCursorPosition(5, 19);
            Console.WriteLine("2. Instruction");
            Console.SetCursorPosition(5, 20);
            Console.WriteLine("3. Highscore");
            Console.SetCursorPosition(5, 21);
            Console.WriteLine("4. Exit");
            Console.ResetColor();
            int choose;
            for (int i = 1; i < 2; i++)
            {
                choose = int.Parse(Console.ReadLine());
                if (choose == 1)
                {
                    Console.Clear();
                    Frame();
                    PrintNumber();
                    Move();
                    End();
                }
                else if (choose == 2)
                {
                    Guide();
                    Back();
                }
                else if (choose == 3)
                {
                    Console.Clear();
                    HighScore();
                    Console.WriteLine();
                    Back();
                }
                else if(choose==4)
                {
                    Environment.Exit(0);
                }
                else
                {
                    Console.Clear();
                    Interface();
                    i--;
                }
            }
        }
    }
}

using System;

namespace Game
{
    public class Score
    {
        public string Name { get; set; }
        public int Keystroce { get; set; }
        public void Display()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("{0} : ", Name);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine ("{0}", Keystroce);
        }
    }
}

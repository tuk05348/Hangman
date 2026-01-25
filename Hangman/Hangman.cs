using System.IO;

namespace HangmanNS
{

    public class Hangman
    {
        public const string Top = "__________\n|      |";
        public const string First = "|      O";
        public const string Second = "|    / | \\ ";
        public const string Third = "|     / \\ ";
        public const string Bottom = "|         \n|_________";

        public List<string> WordBank { get; } = new List<string>();
        private int Guesses { get; set; } = 6;
        public Hangman(string filePath) { 
            StreamReader sr = new StreamReader(filePath);

            var line = sr.ReadLine();

            while(line != null)
            {
                WordBank.Add(line);
                line = sr.ReadLine();
            }
        }

        public void DisplayGallows()
        {
            Console.WriteLine(Top);
            if(Guesses == 6)
            {
                Console.WriteLine(First.Substring(0, 7));
            }
            else
            {
                Console.WriteLine(First);
            }
            
            if(Guesses == 4)
            {
                Console.WriteLine(Second.Substring(0, 7));
            }
            else if(Guesses == 3)
            {
                Console.WriteLine(Second.Substring(0, 9));
            }
            else if(Guesses <= 2)
            {
                Console.WriteLine(Second);
            }
            

            if(Guesses == 1)
            {
                Console.WriteLine(Third.Substring(0, 8));
            }
            else if(Guesses == 0)
            {
                Console.WriteLine(Third);
            }
            Console.WriteLine(Bottom);
        }

        static void Main(string[] args)
        {
            Hangman hangman = new Hangman("HangmanWords.txt");
            hangman.DisplayGallows();
            Console.ReadLine();
        }

    }

}

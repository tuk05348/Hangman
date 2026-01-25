using System.IO;

namespace HangmanNS
{

    public class Hangman
    {
        public List<string> WordBank { get; } = new List<string>();
        public Hangman(string filePath) { 
            StreamReader sr = new StreamReader(filePath);

            var line = sr.ReadLine();

            while(line != null)
            {
                WordBank.Add(line);
                line = sr.ReadLine();
            }
        }

        static void Main(string[] args)
        {
            Hangman hangman = new Hangman("HangmanWords.txt");
            hangman.WordBank.ForEach(Console.WriteLine);
            Console.ReadLine();
        }

    }

}

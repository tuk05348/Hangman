using System.IO;
using System.Text;

namespace HangmanNS
{

    public class Hangman
    {

        static Random random  = new Random();
        public Gallows gallows;

        public List<string> WordBank { get; } = new List<string>();
        private bool GuessCorrect {  get; set; }
        private List<string> Guesses { get; } = new List<string>();
        public Hangman(string filePath) { 
            StreamReader sr = new StreamReader(filePath);

            var line = sr.ReadLine();

            while(line != null)
            {
                WordBank.Add(line);
                line = sr.ReadLine();
            }

            gallows = new Gallows();
        }

        private string SelectWord()
        {
            return WordBank[random.Next(WordBank.Count)];
        }

        public string UpdateMask(char guess, string mask, string word)
        {
            var foundIndices = new List<int>();
            for (int i = 0; i < word.Length; i++)
            {
                if (guess == word[i])
                {
                    foundIndices.Add(i);
                }
            }

            StringBuilder sb = new StringBuilder(mask);

            foreach (var item in foundIndices)
            {
                sb[item] = guess;
            }

            return sb.ToString();
        }

        public void RunGame()
        {

            Console.WriteLine("Welcome to Hangman!");
            Console.WriteLine("The classic word guessing game");

            string word = SelectWord();

            string mask = new string('*', word.Length);

            while(gallows.GuessesLeft > -1)
            {
                if(gallows.GuessesLeft < 6)
                {
                    Console.Write(GuessCorrect ? "That is correct. " : "That is incorrect. ");
                    Console.WriteLine("You may miss {0} more time(s).", gallows.GuessesLeft);
                    Console.WriteLine(string.Join(", ", Guesses.ToArray()));
                }
                gallows.DisplayGallows();
                Console.Write("The word is {0} Enter a guess: ", mask);
                var currentGuess = Console.ReadLine();
                
                while(currentGuess == null)
                {
                    Console.WriteLine("Please enter a valid guess: ");
                    currentGuess = Console.ReadLine();
                }

                if (word.Contains(currentGuess[0]))
                {
                    GuessCorrect = true;
                    mask = UpdateMask(currentGuess[0], mask, word);
                }
                else
                {
                    GuessCorrect = false;
                    gallows.GuessesLeft--;
                }
            }
        }

        static void Main(string[] args)
        {
            Hangman hangman = new Hangman("HangmanWords.txt");
            hangman.RunGame();
        }

    }

}

using System.IO;
using System.Text;

namespace HangmanNS
{

    public class Hangman
    {
        public const string Top = "__________\n|      |";
        public const string First = "|      O";
        public const string Second = "|    / | \\ ";
        public const string Third = "|     / \\ ";
        public const string Bottom = "|         \n|_________";

        static Random random  = new Random();

        public List<string> WordBank { get; } = new List<string>();
        private int GuessesLeft { get; set; } = 6;

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
        }

        private string SelectWord()
        {
            return WordBank[random.Next(WordBank.Count)];
        }

        public void DisplayGallows()
        {
            Console.WriteLine(Top);
            if(GuessesLeft == 6)
            {
                Console.WriteLine(First.Substring(0, 7));
            }
            else
            {
                Console.WriteLine(First);
            }
            
            if(GuessesLeft == 4)
            {
                Console.WriteLine(Second.Substring(0, 7));
            }
            else if(GuessesLeft == 3)
            {
                Console.WriteLine(Second.Substring(0, 9));
            }
            else if(GuessesLeft <= 2)
            {
                Console.WriteLine(Second);
            }
            

            if(GuessesLeft == 1)
            {
                Console.WriteLine(Third.Substring(0, 8));
            }
            else if(GuessesLeft == 0)
            {
                Console.WriteLine(Third);
            }
            Console.WriteLine(Bottom);
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

            while(GuessesLeft > 0)
            {
                if(GuessesLeft < 6)
                {
                    Console.Write(GuessCorrect ? "That is correct. " : "That is incorrect. ");
                    Console.WriteLine("You may miss {0} more time(s).", GuessesLeft);
                    Console.WriteLine(string.Join(", ", Guesses.ToArray()));
                }
                DisplayGallows();
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
                    GuessesLeft--;
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

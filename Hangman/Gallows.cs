using System;

public class Gallows
{

    public const string Top = "__________\n|      |";
    public const string First = "|      O";
    public const string Second = "|    / | \\ ";
    public const string Third = "|     / \\ ";
    public const string Bottom = "|         \n|_________";

    public int GuessesLeft { get; set; } = 6;

    public Gallows()
	{
	}

    public void DecrementGuesses()
    {
        if (GuessesLeft > 0)
        {
            GuessesLeft--;
        }
    }

    public void ResetGuessesLeft()
    {
        GuessesLeft = 6;
    }

    public void DisplayGallows()
    {
        Console.WriteLine(Top);
        DisplayFirstRow();
        DisplaySecondRow();
        DisplayThirdRow();
        Console.WriteLine(Bottom);
    }

    public void DisplayFirstRow()
    {
        if (GuessesLeft == 6)
        {
            Console.WriteLine(First.Substring(0, 7));
        }
        else
        {
            Console.WriteLine(First);
        }
    }

    public void DisplaySecondRow()
    {
        if (GuessesLeft == 4)
        {
            Console.WriteLine(Second.Substring(0, 7));
        }
        else if (GuessesLeft == 3)
        {
            Console.WriteLine(Second.Substring(0, 9));
        }
        else if (GuessesLeft <= 2)
        {
            Console.WriteLine(Second);
        }
    }

    public void DisplayThirdRow()
    {
        if (GuessesLeft >= 2)
        {
            Console.WriteLine(Third.Substring(0, 6));
        }
        else if (GuessesLeft == 1)
        {
            Console.WriteLine(Third.Substring(0, 8));
        }
        else if (GuessesLeft == 0)
        {
            Console.WriteLine(Third);
        }
    }
}

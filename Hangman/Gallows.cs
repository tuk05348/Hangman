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

    }

    public void DisplaySecondRow()
    {

    }

    public void DisplayThirdRow()
    {

    }
}

using System;

namespace Yatzy;

class DiceHand
{
    public int[] DiceValues = new int[5];
    public bool[] KeepFlags = new bool[5];

    public void ResetKeepFlags()
    {
        for (int i = 0; i < KeepFlags.Length; i++)
        {
            KeepFlags[i] = false;
        }
    }

    public void ApplyKeepInput(string? input)
    {
        ResetKeepFlags();
        if (string.IsNullOrWhiteSpace(input)) return;
        foreach (char character in input.Trim())
        {
            if (character >= '1' && character <= '5')
            {
                int index = character - '1';
                KeepFlags[index] = true;
            }
        }
    }

    public void Roll(Random randomNumberGenerator)
    {
        for (int i = 0; i < DiceValues.Length; i++)
        {
            if (KeepFlags[i] == false)
            {
                DiceValues[i] = randomNumberGenerator.Next(1, 7);
            }
        }
    }

    public void PrintDice()
    {
        Console.WriteLine("[" + string.Join(" ", DiceValues) + "]");
    }
}

namespace Yatzy;

class DiceHand
{
    public int[] DiceValues = new int[5];
    public bool[] KeepFlags = new bool[5];
    private readonly Random randomNumberGenerator = new Random();

    public void ResetKeepFlags()
    {
        for (int i = 0; i < KeepFlags.Length; i++)
        {
            KeepFlags[i] = false;
        }
    }

    public void ApplyKeepInput(string? input)
    {
        //ResetKeepFlags();
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

    public void Roll()
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
        var values = DiceValues;
        var output = new List<string>();

        for (int i = 0; i < values.Length; i++)
        {
            if (KeepFlags[i])
                output.Add(values[i] + "*");
            else
                output.Add(values[i].ToString());
        }

        Console.WriteLine("[" + string.Join(" ", output) + "]");
    }
}

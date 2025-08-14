namespace Yatzy;

class Game
{
    private readonly string[] categories = Enum.GetNames(typeof(Categories));
    private readonly Player[] players;
    // Minimal color helpers to keep output readable but a bit nicer
    private static void WriteLineColored(string text, ConsoleColor color)
    {
        ConsoleColor prev = Console.ForegroundColor;
        try { Console.ForegroundColor = color; Console.WriteLine(text); }
        finally { Console.ForegroundColor = prev; }
    }

    private static void WriteColored(string text, ConsoleColor color)
    {
        ConsoleColor prev = Console.ForegroundColor;
        try { Console.ForegroundColor = color; Console.Write(text); }
        finally { Console.ForegroundColor = prev; }
    }

    public Game()
    {
        players = new[] { new Player("Player 1"), new Player("Player 2") };
    }

    public void PlayGame()
    {
        WriteLineColored("Simple Free Yatzy", ConsoleColor.Cyan);
        WriteLineColored("Categories: " + string.Join(", ", categories), ConsoleColor.Yellow);
        Console.WriteLine();

        for (int round = 0; round < categories.Length; round++)
        {
            for (int i = 0; i < players.Length; i++)
            {
                TakeTurn(players[i]);
            }
        }

        PrintFinalScores();
    }

    private void TakeTurn(Player player)
    {
        WriteLineColored("\n=== " + player.Name + " ===", ConsoleColor.Cyan);
        DiceHand diceHand = new DiceHand();
        RollPhase(diceHand);

        List<string> remainingCategories = player.ScoreCard.Remaining();
        string chosenCategory = ChooseCategoryUntilValid(remainingCategories, diceHand.DiceValues);
        int scoredPoints = ScoreCard.Calculate(chosenCategory, diceHand.DiceValues);
        player.ScoreCard.Set(chosenCategory, scoredPoints);
        WriteLineColored("Scored " + scoredPoints + " in " + chosenCategory + ".", ConsoleColor.Green);
    }

    private void RollPhase(DiceHand diceHand)
    {
        for (int rollNumber = 1; rollNumber <= 3; rollNumber++)
        {
            diceHand.Roll();
            WriteColored("Roll " + rollNumber + ": ", ConsoleColor.DarkGray);
            ConsoleColor prev = Console.ForegroundColor;
            try { Console.ForegroundColor = ConsoleColor.White; diceHand.PrintDice(); }
            finally { Console.ForegroundColor = prev; }

            if (rollNumber == 3)
            {
                return;
            }

            bool keepRolling = AskKeepOrStop(diceHand);
            if (keepRolling == false)
            {
                return;
            }
        }
    }

    private bool AskKeepOrStop(DiceHand diceHand)
    {
        while (true)
        {
            WriteLineColored("Keep dice positions 1-5 (e.g., 1,4,5 or keep 1 3 5)", ConsoleColor.DarkGray);
            WriteLineColored("ENTER/r = reroll all | s = stop", ConsoleColor.DarkGray);
            WriteColored("Choice: ", ConsoleColor.Gray);

            string? userInput = Console.ReadLine();

            if (userInput == null) userInput = string.Empty;
            userInput = userInput.Trim();

            string lower = userInput.ToLowerInvariant();

            // Stop early
            if (lower == "s")
            {
                return false;
            }

            // Reroll all
            if (userInput.Length == 0)
            {
                diceHand.ApplyKeepInput(string.Empty); // clears keep flags
                return true;
            }

            // Support optional prefixes: keep/hold/k/h
            if (lower.StartsWith("keep ")) userInput = userInput.Substring(5).Trim();
            else if (lower.StartsWith("hold ")) userInput = userInput.Substring(5).Trim();
            else if (lower.StartsWith("k ")) userInput = userInput.Substring(2).Trim();
            else if (lower.StartsWith("h ")) userInput = userInput.Substring(2).Trim();

            // Validate only allowed characters: digits 1-5, commas, and whitespace
            bool hasOnlyAllowedChars = true;
            bool hasAtLeastOneDigit = false;
            foreach (char c in userInput)
            {
                if ((c >= '1' && c <= '5'))
                {
                    hasAtLeastOneDigit = true;
                    continue;
                }
                if (c == ',' || char.IsWhiteSpace(c))
                {
                    continue;
                }
                hasOnlyAllowedChars = false;
                break;
            }

            if (!hasOnlyAllowedChars || !hasAtLeastOneDigit)
            {
                WriteLineColored("Invalid input. Use positions 1-5 separated by commas or spaces, or press ENTER.", ConsoleColor.Red);
                continue;
            }

            // Tokenize on commas and whitespace
            string[] tokens = userInput.Replace(',', ' ').Split(' ', StringSplitOptions.RemoveEmptyEntries);
            if (tokens.Length > 5)
            {
                WriteLineColored("Too many positions. Specify up to 5 distinct positions between 1 and 5.", ConsoleColor.Red);
                continue;
            }

            bool[] keepMap = new bool[6]; // 1..5 used
            bool invalid = false;
            foreach (string token in tokens)
            {
                // Each token must be a single digit 1..5
                if (token.Length != 1 || token[0] < '1' || token[0] > '5')
                {
                    invalid = true;
                    break;
                }
                int pos = token[0] - '0'; // 1..5
                if (keepMap[pos])
                {
                    WriteLineColored("Duplicate position '" + pos + "'. Use each position at most once.", ConsoleColor.Red);
                    invalid = true;
                    break;
                }
                keepMap[pos] = true;
            }

            if (invalid)
            {
                WriteLineColored("Invalid input. Example: 1,4,5 or 2 3.", ConsoleColor.Red);
                continue;
            }

            // Build a compact string like "145" for ApplyKeepInput
            string cleaned = string.Empty;
            for (int i = 1; i <= 5; i++)
            {
                if (keepMap[i]) cleaned += i.ToString();
            }

            diceHand.ApplyKeepInput(cleaned);
            return true;
        }
    }

    private string ChooseCategoryUntilValid(List<string> remainingCategories, int[] diceValues)
    {
        while (true)
        {
            PrintCategories(remainingCategories);
            string? userInput = Console.ReadLine();
            if (userInput == null) userInput = string.Empty;
            userInput = userInput.Trim();
            foreach (string remainingCategory in remainingCategories)
            {
                if (string.Equals(remainingCategory, userInput, StringComparison.OrdinalIgnoreCase))
                {
                    if (Check.IsValid(remainingCategory, diceValues, out string invalidReason)) return remainingCategory;
                    WriteLineColored("Not valid for current dice: " + invalidReason, ConsoleColor.Red);
                    break;
                }
            }
            WriteLineColored("Invalid. Try again.", ConsoleColor.Red);
        }
    }

    private void PrintCategories(List<string> remainingCategories)
    {
        WriteColored("Choose category: ", ConsoleColor.Gray);
        for (int index = 0; index < remainingCategories.Count; index++)
        {
            WriteLineColored(remainingCategories[index], ConsoleColor.Yellow);
        }
    }

    private void PrintFinalScores()
    {
        foreach (Player player in players)
        {
            WriteLineColored("\n" + player.Name + " scores:", ConsoleColor.Cyan);
            foreach (KeyValuePair<string, int?> entry in player.ScoreCard.Scores)
            {
                int value = entry.Value ?? 0;
                Console.WriteLine("- " + entry.Key + ": " + value);
            }
            WriteLineColored("Total: " + player.ScoreCard.Total(), ConsoleColor.Green);
        }
    }
}

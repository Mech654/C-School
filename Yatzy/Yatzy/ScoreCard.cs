using System;
using System.Collections.Generic;

namespace Yatzy;

class ScoreCard
{
    public Dictionary<string, int?> Scores;

    public ScoreCard()
    {
        Scores = new Dictionary<string, int?>(StringComparer.OrdinalIgnoreCase);
        string[] names = Enum.GetNames(typeof(Categories));
        for (int i = 0; i < names.Length; i++)
        {
            Scores[names[i]] = null;
        }
    }

    public List<string> Remaining()
    {
        List<string> list = new List<string>();
        foreach (KeyValuePair<string, int?> entry in Scores)
        {
            if (entry.Value == null)
            {
                list.Add(entry.Key);
            }
        }
        return list;
    }

    public int Total()
    {
        int sum = 0;
        foreach (KeyValuePair<string, int?> entry in Scores)
        {
            if (entry.Value.HasValue)
            {
                sum += entry.Value.Value;
            }
        }
        return sum;
    }

    public void Set(string category, int value)
    {
        Scores[category] = value;
    }

    public static int Calculate(string category, int[] diceValues)
    {
        int[] faceCounts = CountFaceCounts(diceValues);
        int total = SumDice(diceValues);

        if (EqualsCategory(category, "Ones")) return faceCounts[1] * 1;
        if (EqualsCategory(category, "Twos")) return faceCounts[2] * 2;
        if (EqualsCategory(category, "Threes")) return faceCounts[3] * 3;
        if (EqualsCategory(category, "Fours")) return faceCounts[4] * 4;
        if (EqualsCategory(category, "Fives")) return faceCounts[5] * 5;
        if (EqualsCategory(category, "Sixes")) return faceCounts[6] * 6;

        if (EqualsCategory(category, "Pair"))
        {
            for (int faceValue = 6; faceValue >= 1; faceValue--)
            {
                if (faceCounts[faceValue] >= 2)
                {
                    return faceValue * 2;
                }
            }
            return 0;
        }
        if (EqualsCategory(category, "TwoPairs"))
        {
            int found = 0;
            int score = 0;
            for (int faceValue = 6; faceValue >= 1; faceValue--)
            {
                if (faceCounts[faceValue] >= 2)
                {
                    found++;
                    score += faceValue * 2;
                    if (found == 2)
                    {
                        return score;
                    }
                }
            }
            return 0;
        }
        if (EqualsCategory(category, "ThreeOfAKind"))
        {
            for (int faceValue = 6; faceValue >= 1; faceValue--)
            {
                if (faceCounts[faceValue] >= 3)
                {
                    return faceValue * 3;
                }
            }
            return 0;
        }
        if (EqualsCategory(category, "FourOfAKind"))
        {
            for (int faceValue = 6; faceValue >= 1; faceValue--)
            {
                if (faceCounts[faceValue] >= 4)
                {
                    return faceValue * 4;
                }
            }
            return 0;
        }
        if (EqualsCategory(category, "SmallStraight"))
        {
            return IsSmallStraight(faceCounts) ? 15 : 0;
        }
        if (EqualsCategory(category, "LargeStraight"))
        {
            return IsLargeStraight(faceCounts) ? 20 : 0;
        }
        if (EqualsCategory(category, "FullHouse"))
        {
            bool three = false;
            bool two = false;
            for (int faceValue = 1; faceValue <= 6; faceValue++)
            {
                if (faceCounts[faceValue] == 3) three = true;
                else if (faceCounts[faceValue] == 2) two = true;
            }
            if (three && two)
            {
                return total;
            }
            return 0;
        }
        if (EqualsCategory(category, "Yatzy"))
        {
            for (int faceValue = 1; faceValue <= 6; faceValue++)
            {
                if (faceCounts[faceValue] == 5)
                {
                    return 50;
                }
            }
            return 0;
        }
        if (EqualsCategory(category, "Chance"))
        {
            return total;
        }
        return 0;
    }

    private static int[] CountFaceCounts(int[] diceValues)
    {
        int[] faceCountsArray = new int[7];
        for (int i = 0; i < diceValues.Length; i++)
        {
            if (diceValues[i] >= 1 && diceValues[i] <= 6)
            {
                faceCountsArray[diceValues[i]]++;
            }
        }
        return faceCountsArray;
    }

    private static int SumDice(int[] diceValues)
    {
        int sum = 0;
        for (int i = 0; i < diceValues.Length; i++)
        {
            sum += diceValues[i];
        }
        return sum;
    }

    private static bool IsSmallStraight(int[] faceCounts)
    {
        for (int faceValue = 1; faceValue <= 5; faceValue++)
        {
            if (faceCounts[faceValue] == 0) return false;
        }
        return true;
    }

    private static bool IsLargeStraight(int[] faceCounts)
    {
        for (int faceValue = 2; faceValue <= 6; faceValue++)
        {
            if (faceCounts[faceValue] == 0) return false;
        }
        return true;
    }

    private static bool EqualsCategory(string nameA, string nameB)
    {
        return string.Equals(nameA, nameB, StringComparison.OrdinalIgnoreCase);
    }
}

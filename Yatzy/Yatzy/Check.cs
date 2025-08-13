using System;

namespace Yatzy;

class Check
{
    // Return true if the dice satisfy the chosen category; reason explains failures.
    public static bool IsValid(string category, int[] diceValues, out string reason)
    {
        reason = string.Empty;
        int[] faceCounts = CountFaceCounts(diceValues);

        if (string.Equals(category, "Chance", StringComparison.OrdinalIgnoreCase))
        {
            return true;
        }

        if (string.Equals(category, "Ones", StringComparison.OrdinalIgnoreCase))
        {
            if (faceCounts[1] > 0) return true; reason = "No ones"; return false;
        }
        if (string.Equals(category, "Twos", StringComparison.OrdinalIgnoreCase))
        {
            if (faceCounts[2] > 0) return true; reason = "No twos"; return false;
        }
        if (string.Equals(category, "Threes", StringComparison.OrdinalIgnoreCase))
        {
            if (faceCounts[3] > 0) return true; reason = "No threes"; return false;
        }
        if (string.Equals(category, "Fours", StringComparison.OrdinalIgnoreCase))
        {
            if (faceCounts[4] > 0) return true; reason = "No fours"; return false;
        }
        if (string.Equals(category, "Fives", StringComparison.OrdinalIgnoreCase))
        {
            if (faceCounts[5] > 0) return true; reason = "No fives"; return false;
        }
        if (string.Equals(category, "Sixes", StringComparison.OrdinalIgnoreCase))
        {
            if (faceCounts[6] > 0) return true; reason = "No sixes"; return false;
        }

        if (string.Equals(category, "Pair", StringComparison.OrdinalIgnoreCase))
        {
            if (HasOfAKindCount(faceCounts, 2)) return true; reason = "Need a pair"; return false;
        }
        if (string.Equals(category, "TwoPairs", StringComparison.OrdinalIgnoreCase))
        {
            if (HasTwoPairs(faceCounts)) return true; reason = "Need two pairs"; return false;
        }
        if (string.Equals(category, "ThreeOfAKind", StringComparison.OrdinalIgnoreCase))
        {
            if (HasOfAKindCount(faceCounts, 3)) return true; reason = "Need three of a kind"; return false;
        }
        if (string.Equals(category, "FourOfAKind", StringComparison.OrdinalIgnoreCase))
        {
            if (HasOfAKindCount(faceCounts, 4)) return true; reason = "Need four of a kind"; return false;
        }
        if (string.Equals(category, "SmallStraight", StringComparison.OrdinalIgnoreCase))
        {
            if (IsSmallStraight(faceCounts)) return true; reason = "Need 1-2-3-4-5"; return false;
        }
        if (string.Equals(category, "LargeStraight", StringComparison.OrdinalIgnoreCase))
        {
            if (IsLargeStraight(faceCounts)) return true; reason = "Need 2-3-4-5-6"; return false;
        }
        if (string.Equals(category, "FullHouse", StringComparison.OrdinalIgnoreCase))
        {
            if (IsFullHouse(faceCounts)) return true; reason = "Need full house"; return false;
        }
        if (string.Equals(category, "Yatzy", StringComparison.OrdinalIgnoreCase))
        {
            if (HasOfAKindCount(faceCounts, 5)) return true; reason = "Need five of a kind"; return false;
        }

        reason = "Unknown category.";
        return false;
    }

    // Helpers kept simple loops
    private static int[] CountFaceCounts(int[] diceValues)
    {
        int[] faceCounts = new int[7];
        for (int i = 0; i < diceValues.Length; i++)
        {
            if (diceValues[i] >= 1 && diceValues[i] <= 6)
                faceCounts[diceValues[i]]++;
        }
        return faceCounts;
    }

    private static bool HasOfAKindCount(int[] faceCounts, int requiredCount)
    {
        for (int faceValue = 1; faceValue <= 6; faceValue++)
        {
            if (faceCounts[faceValue] >= requiredCount)
                return true;
        }
        return false;
    }

    private static bool HasTwoPairs(int[] faceCounts)
    {
        int pairs = 0;
        for (int faceValue = 1; faceValue <= 6; faceValue++)
        {
            if (faceCounts[faceValue] >= 2)
                pairs++;
        }
        return pairs >= 2;
    }

    private static bool IsSmallStraight(int[] faceCounts)
    {
        for (int faceValue = 1; faceValue <= 5; faceValue++)
        {
            if (faceCounts[faceValue] == 0)
                return false;
        }
        return true;
    }

    private static bool IsLargeStraight(int[] faceCounts)
    {
        for (int faceValue = 2; faceValue <= 6; faceValue++)
        {
            if (faceCounts[faceValue] == 0)
                return false;
        }
        return true;
    }

    private static bool IsFullHouse(int[] faceCounts)
    {
        bool three = false, two = false;
        for (int faceValue = 1; faceValue <= 6; faceValue++)
        {
            if (faceCounts[faceValue] == 3)
                three = true;
            else if (faceCounts[faceValue] == 2)
                two = true;
        }
        return three && two;
    }
}

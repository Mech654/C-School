using System;

namespace RatRace;

public static class RNG
{
    private static Random rng;

    public static int Range(int upper, int lower)
    {
        if (rng == null)
        {
            rng = new Random();
        }
        return rng.Next(lower, upper);
    }
}

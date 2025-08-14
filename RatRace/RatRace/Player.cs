using System.Collections.Generic;

namespace RatRace;

public class Player
{
    public string Name;
    public int Money;
    public List<Bet> Bets = new List<Bet>();
    public bool HasBet;
}

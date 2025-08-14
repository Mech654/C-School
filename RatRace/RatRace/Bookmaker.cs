namespace RatRace;

public class Bookmaker
{
    public List<Bet> Bets = new List<Bet>();

    public Bet? PlaceBet(Race race, Rat rat, Player player, int money)
    {
        if (money <= 0) return null;
        if (player.Money < money) return null;
        player.Money -= money;
        Bet bet = new Bet(player, race, rat, money);
        Bets.Add(bet);
        player.Bets.Add(bet);
        return bet;
    }

    public void PayOutWinnings(Bet bet)
    {
        bet.PayWinnings();
    }
}

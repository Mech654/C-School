namespace RatRace;

public class Bet
{
    private int _money;
    private Player _player;
    private Race _race;
    private Rat _rat;
    private bool _paid;

    public int Money { get { return _money; } }
    public Player Player { get { return _player; } }
    public Race Race { get { return _race; } }
    public Rat Rat { get { return _rat; } }
    public bool Paid { get { return _paid; } }

    public Bet(Player player, Race race, Rat rat, int money)
    {
        _player = player;
        _race = race;
        _rat = rat;
        _money = money;
        _paid = false;
    }

    public void PayWinnings()
    {
        if (_paid) return;
        Rat? winner = _race.GetWinner();
        if (winner != null && winner == _rat)
        {
            _player.Money += _money * 2; // return stake + winnings
        }
        _paid = true;
    }
}

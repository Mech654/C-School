namespace Yatzy;

class Player
{
    public string Name { get; }
    public ScoreCard ScoreCard { get; }

    public Player(string name)
    {
        Name = name;
        ScoreCard = new ScoreCard();
    }
}

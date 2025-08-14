namespace RatRace;

public class Race
{
    public int RaceID;
    public List<Rat>? Rats;
    public Track? RaceTrack;
    private Rat? _winner;
    private string _log = string.Empty;
    public bool Finished;
    public List<Bet> Bets = new List<Bet>();

    public void ConductRace()
    {
        if (Rats == null || RaceTrack == null) return;
        Rat highest = Rats[0];
        while (true)
        {
            foreach (Rat rat in Rats)
            {
                Random random = new Random();
                int rn = random.Next(0, rat.stamina.Length);
                if (rat.stamina[rn] >= 0){
                    rat.Position = rat.Position + rat._speed + rat.stamina[rn];
                }
                else{
                rat.Position += rat._speed;
                }
            }


            foreach (Rat rat in Rats)
            {
                if (rat.Position >= highest.Position)
                {
                    highest = rat;
                }
            }
            Console.WriteLine(RaceTrack.TrackLength.ToString());
            Console.Clear();
            foreach (Rat rat in Rats)
            {
                for (int i = 0; i <= RaceTrack.TrackLength; i++)
                {
                    if (i == rat.Position)
                    {
                        var prev = Console.ForegroundColor;
                        Console.ForegroundColor = rat.Color;
                        Console.Write(rat.Name);
                        Console.ForegroundColor = prev;
                    }
                    else
                    {
                        Console.Write('-');
                    }
                }
                Console.WriteLine();
            }

            Thread.Sleep(500);
            if (highest.Position >= RaceTrack.TrackLength) break;
        }
        _winner = highest;
        Finished = true;
        Console.WriteLine(_winner.Name);
        logRace();
    }

    public Rat? GetWinner()
    {
        return _winner;
    }

    public string GetRaceReport()
    {
        return _log;
    }

    private void logRace()
    {
        _log = $"Race {RaceID} Winner: {_winner?.Name}";
        if (Bets.Count > 0)
        {
            _log += "\nBets:";
            foreach (var b in Bets)
            {
                _log += $"\n {b.Player.Name} bet {b.Money} on {b.Rat.Name} {(b.Paid && b.Rat == _winner ? "(won)" : "")}";
            }
        }
    }
}

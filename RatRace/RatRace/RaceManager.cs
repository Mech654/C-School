namespace RatRace;

public class RaceManager
{
    public List<Track> Tracks = new List<Track>();
    public List<Player> Players = new List<Player>();
    public List<Race> Races = new List<Race>();
    public List<Rat> Rats = new List<Rat>();
    public Bookmaker Bookmaker = new Bookmaker();

    public Race CreateRace(int raceID, List<Rat> rats, Track track)
    {
        Race race = new Race();
        race.RaceID = raceID;
        race.Rats = rats; // use provided list
        race.RaceTrack = track; //change to better logic later
        Races.Add(race);
        return race;
    }

    public Track CreateTrack(string name, int tracklength)
    {
        Track track = new Track();
        track.Name = name;
        track.TrackLength = tracklength;
        Tracks.Add(track);
        return track;
    }

    public void ConductRace(Race race)
    {
        if (Players.Count() >= 2)
        {
            race.ConductRace();
            foreach (Bet bet in Bookmaker.Bets)
            {
                if (bet.Race == race)
                {
                    bet.PayWinnings();
                }
            }
        }
    }

    public string? ViewRaceReport(Race race)
    {
        return race.GetRaceReport();
    }

    public Rat CreateRat(string name)
    {
        Rat rat = new Rat();
        rat.Name = name;
        return rat; // stub
    }

    public Player CreatePlayer(string name, int money)
    {
        Player player = new Player();
        player.Name = name;
        player.Money = money;
        Players.Add(player);
        return player; // stub
    }
}

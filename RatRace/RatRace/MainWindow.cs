namespace RatRace;

public class MainWindow
{
  private int raceID = 0;
  private RaceManager rm = new RaceManager();
  public void Main()
  {
    Setup();
    GameLoop();
  }
  private void Setup()
  {
    // Rats
    Console.WriteLine("=== Setup Rats ===");
    Console.Write("How many rats?: ");
    string? ratCountInput = Console.ReadLine();
    int ratCount = 0;
    int.TryParse(ratCountInput, out ratCount);
    if (ratCount < 2) ratCount = 2; // minimum 2
    for (int i = 1; i <= ratCount; i++)
    {
      rm.Rats.Add(rm.CreateRat($"Rat{i}"));
    }
    // Players
    Console.WriteLine("=== Setup Players ===");
    List<string> players = PromptForUsers();
    foreach (string player in players) { rm.CreatePlayer(player, 500); }
    // Track (single for now)
    rm.Tracks.Add(rm.CreateTrack("FirstTrack", 100));
  }

  private void GameLoop()
  {
    while (true)
    {
      Console.WriteLine();
      Console.WriteLine("=== MENU ===");
      Console.WriteLine("1) Run Race");
      Console.WriteLine("2) Standings");
      Console.WriteLine("3) Exit");
      Console.Write("Select: ");
      string? choice = Console.ReadLine();
      if (choice == "1") { RunRaceCycle(); }
      else if (choice == "2") { ShowStandings(); }
      else if (choice == "3" || string.IsNullOrEmpty(choice)) { break; }
    }
  }

  private void RunRaceCycle()
  {
    Race race = rm.CreateRace(raceID++, rm.Rats, rm.Tracks[0]);
    ResetForNewRace();
    PromptForBets(race);
    rm.ConductRace(race);
    Console.WriteLine();
    Console.WriteLine(rm.ViewRaceReport(race));
  }

  private void ResetForNewRace()
  {
    foreach (var p in rm.Players) { p.HasBet = false; }
    rm.Bookmaker.Bets.Clear();
    foreach (var r in rm.Rats) { r.ResetRat(); }
  }

  private void ShowStandings()
  {
    Console.WriteLine("=== Standings ===");
    foreach (var p in rm.Players) { Console.WriteLine($"{p.Name}: {p.Money}"); }
  }

  // Removed PromptRatName (auto naming now)

  private List<string> PromptForUsers()
  {
    List<string> players = new List<string>();
    Console.Write("How many players?: ");
    string? usercount = Console.ReadLine();
    int count = 0;
    int.TryParse(usercount, out count);
    for (int i = 0; i < count; i++)
    {
      Console.Write("Player name: ");
      string? playername = Console.ReadLine();
      while (string.IsNullOrEmpty(playername))
      {
        Console.Write("Enter player name: ");
        playername = Console.ReadLine();
      }
      players.Add(playername);
    }
    return players;
  }

  private void PromptForBets(Race race)
  {
    Console.WriteLine("Place bets (each player exactly one bet)\n");
    foreach (Player player in rm.Players)
    {
      if (player.HasBet) continue;
      Console.WriteLine($"Player: {player.Name} (Money: {player.Money})");
      Console.WriteLine("Available Rats: " + string.Join(", ", rm.Rats.Select(r => r.Name)));
      // Rat selection (force valid)
      Rat? rat = null;
      while (rat == null)
      {
        Console.Write("Rat name: ");
        string? rname = Console.ReadLine();
        rat = rm.Rats.FirstOrDefault(r => r.Name == rname);
        if (rat == null) Console.WriteLine("No such rat");
      }
      // Amount selection (force valid)
      int betAmt = 0;
      while (true)
      {
        Console.Write("Bet amount: ");
        string? amt = Console.ReadLine();
        if (!int.TryParse(amt, out betAmt) || betAmt <= 0)
        {
          Console.WriteLine("Invalid amount");
          continue;
        }
        if (betAmt > player.Money)
        {
          Console.WriteLine("Not enough funds");
          continue;
        }
        break;
      }
      var placed = rm.Bookmaker.PlaceBet(race, rat, player, betAmt);
      if (placed != null)
      {
        race.Bets.Add(placed);
        player.HasBet = true;
        Console.WriteLine("Bet accepted\n");
      }
      else
      {
        // Should not normally happen because we validate inputs; still mark to avoid infinite loop.
        player.HasBet = true;
        Console.WriteLine("Bet failed (skipping)\n");
      }
    }
  }
}

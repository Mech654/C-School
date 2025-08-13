using System;
using System.IO;
using System.Threading.Tasks;
using NetCoreAudio;

namespace Mozart;

class Program
{
    static async Task Main(string[] args)
    {
        var mz = new Mozart();
        await mz.StartPlaying();
    }
}

class Mozart
{
    private readonly Random _random;

    public Mozart() { _random = new Random(); }

    private string SelectInstrument()
    {
        Console.Write("Select instrument 1-4: ");
        switch (Console.ReadLine())
        {
            case "1":
                return "clarinet";
            case "2":
                return "flute-harp";
            case "3":
                return "mbira";
            case "4":
                return "piano";
            default:
                return "clarinet"; // fallback instead of error string
        }
    }

    private string RandomLastPart()
    {
        string sekvens = _random.Next(1, 15).ToString();
        string frase = (_random.Next(1, 7) + _random.Next(1, 7)).ToString();
        return sekvens + "-" + frase;
    }

    private string GetFilePath()
    {
        string currPath = Directory.GetCurrentDirectory();
        string targetPath = Path.Combine(currPath,
            "Data",
            "mozart",
            "mozart",
            SelectInstrument(),
            "minuet" + RandomLastPart() + ".wav");
        return targetPath;
    }

    public async Task StartPlaying()
    {
        await RunSound(GetFilePath());
    }

    private async Task RunSound(string filePath)
    {
        Console.WriteLine($"Playing {filePath}");
        var p = new Player();
        await p.Play(filePath);
        // NetCoreAudio's Play is async until playback starts; to keep behavior similar, poll until finished
        while (p.Playing)
            await Task.Delay(100);
    }
}
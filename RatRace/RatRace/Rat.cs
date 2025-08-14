namespace RatRace;

public class Rat
{
    public string Name; // public field per spec
    private int _position;
    public int Position { get { return _position; } set { _position = value; } }
    public int _speed;
    public ConsoleColor Color;
    public int[] stamina = [1,1,2,2,3,4,5,6,7];

    public Rat()
    {
        // Leave speed range logic, but use RNG for consistency
        _speed = new Random().Next(5, 8); // user wants to manage stamina/speed later
        _position = 0;
        Color = (ConsoleColor)RNG.Range(16, 1);
    }

    public void ResetRat()
    {
        _position = 0;
    }

    public int MoveRat()
    {
        _position += _speed;
        return _position;
    }
}

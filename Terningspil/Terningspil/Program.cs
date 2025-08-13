namespace Terningspil;
using System;
class Program
{
    static Die[] dice = new Die[6];
    static void Main(string[] args)
    {
        int count = 1;
        while (true)
        {
            NewDices();
            if (CheckNumberInAllDices(6))
            {
                Console.WriteLine(count);
                break;
            }
            count++;
        }
    }

    static bool CheckNumberInAllDices(int number)
    {
        for (int i = 0; i < dice.Length; i++)
        {
            if (dice[i].Value != number)  return false;
        }
        return true;
    }

    static void NewDices()
    {
        for (int i = 0; i < dice.Length; i++)
        {
            dice[i] = new Die();
        }
    }
}

class Die
{
    public int Value { get; set; }
    public void Roll()
    {
        Random random = new Random();
        Value = random.Next(1, 7);
    }

    public Die()
    {
        Roll();
    }
}

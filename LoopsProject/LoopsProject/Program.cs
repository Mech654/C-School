namespace LoopsProject;

class Program
{
    static void Main(string[] args)
    {
        //PrintTable();
        //Console.WriteLine(BiggestNumber([1, 2, 3, 5, 10, 1]));
        //Console.WriteLine(Sevens([3,3,3,7,7,2]));
        //Console.WriteLine(isAdjacent([1,2,1,2,3]));
        Console.WriteLine(string.Join(", ", PrimeNumbers(100)));
        Console.WriteLine(ExtractString("##abc##def"));
        Console.WriteLine(FullSequenceOfLetters("ds"));
        Console.WriteLine(SumAndAverage(11, 66));
        DrawTriangle();
        Console.WriteLine(ToThePowerOf(-2, 3));
    }

    static void PrintTable()
    {
        for (int i = 1; i < 11; i++)
        {
            for (int ii = 1; ii < 11; ii++)
            {
                int x = i * ii;
                Console.Write($"{x} , ");
            }
            Console.WriteLine(' ');
        }
    }

    static int BiggestNumber(int[] args)
    {
        int x = 0;

        foreach (int i in args)
        {
            if (i > x) x = i;
        }
        return x;
    }

    static int Sevens(int[] args)
    {
        int x = 0;

        foreach (int i in args)
        {
            if (i == 7) x++;
        }
        return x;
    }

    static bool isAdjacent(int[] args)
    {
        int x = 0;
        foreach (int i in args)
        {
            if (i == (x + 1))
            {
                x++;
            }
            else
            {
                x = 0;
            }

            if (x == 2) return true;
        }
        return false;
    }

    static List<int> PrimeNumbers(int x)
    {
        int[] primes = {
           2, 3, 5, 7, 11, 13, 17, 19, 23, 29,
          31, 37, 41, 43, 47, 53, 59, 61, 67, 71,
          73, 79, 83, 89, 97, 101, 103, 107, 109, 113,
          127, 131, 137, 139, 149, 151, 157, 163, 167, 173,
          179, 181, 191, 193, 197, 199, 211, 223, 227, 229,
          233, 239, 241, 251, 257, 263, 269, 271, 277, 281,
          283, 293, 307, 311, 313, 317, 331, 337, 347, 349,
          353, 359, 367, 373, 379, 383, 389, 397, 401, 409,
          419, 421, 431, 433, 439, 443, 449, 457, 461, 463,
          467, 479, 487, 491, 499, 503, 509, 521, 523, 541,
          547, 557, 563, 569, 571, 577, 587, 593, 599, 601,
          607, 613, 617, 619, 631, 641, 643, 647, 653, 659,
          661, 673, 677, 683, 691, 701, 709, 719, 727, 733,
          739, 743, 751, 757, 761, 769, 773, 787, 797, 809,
          811, 821, 823, 827, 829, 839, 853, 857, 859, 863,
          877, 881, 883, 887, 907, 911, 919, 929, 937, 941,
          947, 953, 967, 971, 977, 983, 991, 997
      };
        List<int> selected = new List<int>();
        foreach (int prime in primes)
        {
            if (prime < x) selected.Add(prime);
            else return selected;
        }
        return selected;
    }

    static string ExtractString(string s)
    {
        int a = s.IndexOf("##"), b = s.IndexOf("##", a + 2);
        return (a == -1 || b == -1) ? "" : s.Substring(a + 2, b - a - 2);
    }

    static string FullSequenceOfLetters(string s)
    {
        string r = "";
        for (char c = s[0]; c <= s[1]; c++) r += c;
        return r;
    }

    static string SumAndAverage(int n, int m)
    {
        int sum = 0, count = m - n + 1;
        for (int i = n; i <= m; i++) sum += i;
        return $"Sum: {sum}, Average: {(double)sum / count}";
    }

    static void DrawTriangle()
    {
        int rows = 10;
        for (int i = 1; i <= rows; i++)
        {
            Console.Write(new string(' ', rows - i));
            Console.WriteLine(new string('*', 2 * i - 1));
        }
    }

    static int ToThePowerOf(int b, int p)
    {
        if (p < 0) return 0;
        int r = 1;
        for (int i = 0; i < p; i++) r *= b;
        return r;
    }
}

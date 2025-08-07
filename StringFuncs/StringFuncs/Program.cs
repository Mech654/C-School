namespace StringFuncs;

public class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");
    }

    public static string AddSeperator(string input)
    {
        if (string.IsNullOrEmpty(input))
        {
            return input;
        }
        string result = string.Empty;
        foreach (char c in input)
        {
            result += char.ToUpper(c) + "^";
        }
        return result;

    }

    public static bool IsPalindrome(string input)
    {
        if (string.IsNullOrEmpty(input))
        {
            return false;
        }

        for (int i = 0; i < (input.Length / 2); i++)
        {
            if (char.ToLower(input[i]) != char.ToLower(input[input.Length - 1 - i]))
            {
                return false;
            }
        }


        return true;
    }

    public static int GetStringLength(string input)
    {
        int x = 0;

        foreach (char c in input)
        {
            x++;
        }

        return x;
    }

    public static string ReverseString(string input)
    {
        if (string.IsNullOrEmpty(input))
        {
            return input;
        }

        char[] charArray = input.ToCharArray();
        Array.Reverse(charArray);
        return new string(charArray);
    }

    public static int NumberOfWords(string input)
    {
        if (string.IsNullOrEmpty(input))
        {
            return 0;
        }
        return input.Split(' ', StringSplitOptions.RemoveEmptyEntries).Length;
    }

    public static string ReverseWords(string input)
    {
        if (string.IsNullOrEmpty(input))
        {
            return input;
        }

        string[] words = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);
        Array.Reverse(words);
        return string.Join(" ", words);
    }

    public static string NumberOfOccurences(string line, string word)
    {
        if (string.IsNullOrEmpty(line) || string.IsNullOrEmpty(word))
        {
            return "0";
        }

        int count = 0;
        int index = 0;

        while ((index = line.IndexOf(word, index, StringComparison.OrdinalIgnoreCase)) != -1)
        {
            count++;
            index += word.Length;
        }

        return count.ToString();

    }

    public static string SortDescending(string input)
    {
        if (string.IsNullOrEmpty(input))
        {
            return input;
        }

        char[] charArray = input.ToCharArray();
        Array.Sort(charArray);
        Array.Reverse(charArray);
        return new string(charArray);
    }

    public static string CompressString(string input)
    {
        if (string.IsNullOrEmpty(input))
        {
            return input;
        }

        string result = string.Empty;
        char currentChar = input[0];
        int count = 0;

        foreach (char c in input)
        {
            if (c == currentChar)
            {
                count++;
            }
            else
            {
                result += currentChar + count.ToString();
                currentChar = c;
                count = 1;
            }
        }

        return result + currentChar + count.ToString();
    }
}

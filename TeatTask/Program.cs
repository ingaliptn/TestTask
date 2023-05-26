class Program
{
    static void Main()
    {
        string file = "passwords.txt";

        Console.WriteLine("Count valid pass: " + CountValidPasswords(file));
    }

    static int CountValidPasswords(string file)
    {
        int validPassCount = 0;

        string[] lines = File.ReadAllLines(file);

        foreach (string line in lines)
        {
            if (IsValidPass(line))
            {
                validPassCount++;
            }
        }

        return validPassCount;
    }

    static bool IsValidPass(string line)
    {
        string[] parts = line.Split(':');
        string req = parts[0].Trim();
        string pass = parts[1].Trim();

        char reqChar = req[0];
        string[] range = req.Substring(2).Split('-');
        int minCount = int.Parse(range[0]);
        int maxCount = int.Parse(range[1]);

        int charCount = CountChar(pass, reqChar);
        return charCount >= minCount && charCount <= maxCount;
    }

    static int CountChar(string str, char ch)
    {
        int count = 0;
        foreach (char c in str)
        {
            if (c == ch)
            {
                count++;
            }
        }
        return count;
    }
}
namespace The_game_of_doom;

public class Misc
{
    public static string AskUser(string prompt)
    {
        Console.Write(prompt);

        var input = Console.ReadLine() ?? "";
        return input;
    }

    public static string ForceInput(string prompt)
    {
        var input = "";
        while (input == "") input = AskUser(prompt);

        return input;
    }

    public static string ForceKey(string prompt, string valid)
    {
        var input = '\0';
        while (input == '\0')
        {
            Console.Write(prompt);
            input = Console.ReadKey().KeyChar;

            if (!valid.Contains(input)) input = '\0';
            Console.WriteLine();
        }

        return input.ToString();
    }

    public static string GetPasswordText(string prompt)
    {
        Console.Write(prompt);
        var password = "";
        var key = Console.ReadKey(true);
        while (key.Key != ConsoleKey.Enter)
        {
            password = password.Insert(password.Length, key.KeyChar.ToString());
            key = Console.ReadKey(true);
        }

        Console.WriteLine();

        return password;
    }

    public static string ForcePasswordText(string prompt)
    {
        var input = "";
        while (input == "") input = GetPasswordText(prompt);

        return input;
    }
}
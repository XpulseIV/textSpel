namespace The_game_of_doom.Classes.misc_classes
{
    internal static class Asker
    {
        private static string AskUser(string prompt)
        {
            Console.Write(prompt);

            string input = Console.ReadLine() ?? "";
            return input;
        }

        public static string ForceInput(string prompt, int lineNumber = -1)
        {
            string input = "";
            while (input == "")
            {
                if (lineNumber != -1) Console.SetCursorPosition(0, lineNumber);
                input = Asker.AskUser(prompt);
            }

            return input;
        }

        public static string ForceKey(string prompt, string valid, int lineNumber = -1)
        {
            char input = '\0';
            while (input == '\0')
            {
                if (lineNumber != -1) Console.SetCursorPosition(0, lineNumber);
                Console.Write(prompt);
                input = Console.ReadKey().KeyChar;

                if (!valid.Contains(input)) input = '\0';
                Console.WriteLine();
            }

            return input.ToString();
        }
    }
}
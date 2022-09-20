namespace The_game_of_doom.Classes.misc_classes
{
    internal static class Asker
    {
        private static string AskUser(string prompt)
        {
            Console.Write(value: prompt);

            string input = Console.ReadLine() ?? "";
            return input;
        }

        public static string ForceInput(string prompt)
        {
            string input = "";
            while (input == "") input = Asker.AskUser(prompt: prompt);

            return input;
        }

        public static string ForceKey(string prompt, string valid)
        {
            char input = '\0';
            while (input == '\0')
            {
                Console.Write(value: prompt);
                input = Console.ReadKey().KeyChar;

                if (!valid.Contains(value: input)) input = '\0';
                Console.WriteLine();
            }

            return input.ToString();
        }
    }
}
namespace The_game_of_doom.Classes.misc_classes
{
    public sealed class PrimeChecker
    {
        public static bool CheckNumber(ulong number)
        {
            DateTime start = DateTime.Now;
            DateTime end;

            if ((number % 2) == 0)
            {
                Console.WriteLine(value: number + " is not a prime!");

                end = DateTime.Now;

                Console.WriteLine(value: end - start);

                return false;
            }

            for (ulong i = 3; i < (Math.Floor(d: Math.Sqrt(d: number)) + 1); i += 2)
            {
                if ((number % i) != 0) continue;

                Console.WriteLine(value: number + " is not a prime!");

                end = DateTime.Now;

                Console.WriteLine(value: end - start);

                return false;
            }

            Console.WriteLine(value: number + " is indeed a prime! yes");

            end = DateTime.Now;

            Console.WriteLine(value: end - start);

            return true;
        }
    }
}
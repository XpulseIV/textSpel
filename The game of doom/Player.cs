namespace MyGame
{
    internal class Player
    {
        public string? Name { get; set; }
        public int Age { get; set; }
        public int Inteligense { get; set; }
        public int Speed { get; set; }
        public Clothes Clothes { get; set; }

        public Player()
        {
            Console.WriteLine("|-----------------------------------------------------------------------------|\n" +
                "|Weloce to the player creator!                                                             |\n" +
                "|It is here you are given multiple options regarding name, age, and what to wear.          |\n" +
                "|Depending on what your choices are you will be given certain advantages and disadvantages!|\n" +
                "|------------------------------------------------------------------------------------------|");

            Console.WriteLine("Please fill out you name and age seperated by a comma!");
            string nameAge = string.Empty;

            while (nameAge == String.Empty)
            {
                nameAge = Console.ReadLine();
            }

            Name = nameAge!.Split(',')[0];

            Age = Convert.ToInt32(nameAge!.Split(',')[1]);


        }
    }
}

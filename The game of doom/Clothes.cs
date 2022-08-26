namespace The_game_of_doom
{
    internal struct Clothes
    {
        public enum Hats
        {
            Nothing,
            Hat,
            TopHat,
            Cap,
            CowboyHat
        }

        public enum Shirts
        {
            Shirt,
            HawaiianShirt
        }

        public enum Pants
        {
            Shorts,
            Chinos
        }

        public enum Boots
        {
            FlipFlops,
            RegularBoots,
            Crooks
        }

        public Clothes DressPlayer()
        {
            return new Clothes();
        }
    }
}

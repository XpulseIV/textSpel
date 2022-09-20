namespace The_game_of_doom.Classes.misc_classes
{
    public static class Extensions
    {
        public static int[] FindAllIndex<T>(this IEnumerable<T> array, Predicate<T> match)
        {
            return array.Select(selector: (value, index) => match(obj: value) ? index : -1)
                .Where(predicate: static index => index != -1).ToArray();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace The_game_of_doom.Classes.misc_classes
{
    public static class Extensions
    {
        public static int[] FindAllIndex<T>(this T[] array, Predicate<T> match)
        {
            return array.Select((value, index) => match(value) ? index : -1)
                    .Where(index => index != -1).ToArray();
        }
    }
}

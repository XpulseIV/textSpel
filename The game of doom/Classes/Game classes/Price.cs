namespace The_game_of_doom.Classes.Game_classes;

[Serializable]
public sealed class Price<TItem, TItemPrice>
{
    public TItem Item { get; set; }
    public TItemPrice ItemPrice { get; set; }
    
    public Price()
    {
    }

    public Price(TItem item, TItemPrice price)
    {
        Item = item;
        ItemPrice = price;
    }
}
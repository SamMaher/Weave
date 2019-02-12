/// <summary>
///     Describes the moving of a card, includes drawing, discarding etc.
/// </summary>
public class CardMoved : EventData {
    
    public Card card { get; set; }
    public Zone from { get; set; }
    public Zone to { get; set; }

    public override string ToString()
    {
        return string.Format($"Card: {card.name}, Moved from {from} to {to} ");
    }
}
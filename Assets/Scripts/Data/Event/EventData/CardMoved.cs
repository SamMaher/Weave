/// <summary>
///     Describes the moving of a card, includes drawing, discarding etc.
/// </summary>
public class CardMoved : EventData {
    public Card card { get; set; }
    public Zone from { get; set; }
    public Zone to { get; set; }

    public CardMoved(Card card, Zone from, Zone to)
    {
        this.card = card;
        this.from = from;
        this.to = to;
    }

    public override string ToString()
    {
        return $"Card {card.name}, Moved from {from} to {to}";
    }
}
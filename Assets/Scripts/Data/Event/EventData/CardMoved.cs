/// <summary>
///     Describes the moving of a Card, includes drawing, discarding etc.
/// </summary>
public class CardMoved : EventData {
    
    public Card Card { get; set; }
    public Zone From { get; set; }
    public Zone To { get; set; }

    public CardMoved(Card card, Zone from, Zone to)
    {
        Card = card;
        From = from;
        To = to;
    }

    public override string ToString()
    {
        return $"Card {Card.Name}, Moved From {From} To {To}";
    }
}
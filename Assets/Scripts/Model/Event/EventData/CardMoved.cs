public class CardMoved : EventData {
    
    public Card Card { get; set; }
    public CardZone From { get; set; }
    public CardZone To { get; set; }

    public CardMoved(Card card, CardZone from, CardZone to)
    {
        Card = card;
        From = from;
        To = to;
    }

    public override string ToString()
    {
        return $"Card: {Card.ToIdentity(IdentityType.Partial)}, Moved From: {From}, To: {To}";
    }
}
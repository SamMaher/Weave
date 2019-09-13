using System.Linq;

public class HandDrawn : EventData {
    
    public Card[] Cards { get; set; }

    public HandDrawn(Card[] cards)
    {
        Cards = cards;
    }

    public override string ToString()
    {
        var cardNames = Cards.Select(card => card.ToIdentity(IdentityType.Partial));
        var cardNameList = string.Join(", ", cardNames);
        return $"Cards Drawn: {cardNameList}";
    }
}
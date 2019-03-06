/// <summary>
/// 	Handles actions and generates event data
/// </summary>
public class MatchManager {
    public MatchStateManager States;
    public DeckManager Deck;

    public MatchManager()
    {
        States = new MatchStateManager();
        Deck = new DeckManager();
    }

    public void DrawCard(Card card = null)
    {
        var cardMoved = Deck.DrawCard(card);

        EventManager.Notify(EventName.CardDrawn, cardMoved);
    }

    public void DiscardCard(Card card)
    {
        var cardMoved = Deck.MoveCard(card, Zone.Discard);

        EventManager.Notify(EventName.CardDiscarded, cardMoved);
    }

    public void EndTurn()
    {
        States.Next(new MatchTurn());
    }
}
using System.Collections.Generic;
using System.Linq;

/// <summary>
/// 	Manages deckList in Match
/// </summary>
public class DeckManager {
    public const int MaxHandSize = 7;
    public const int BaseHandSize = 5;
    public Deck Deck { get; set; }
    public List<Card> Cards { get; set; }

    #region "Get"

    private Card[] GetCollection(Zone zone = Zone.None)
    {
        if (zone == Zone.None) return Cards.ToArray();
        return Cards.Where(card => card.zone == zone).ToArray();
    }

    public Card[] GetDeck() => GetCollection(Zone.Deck);

    public Card[] GetHand() => GetCollection(Zone.Hand);

    public Card[] GetDiscard() => GetCollection(Zone.Discard);

    public Card[] GetExhausted() => GetCollection(Zone.Exhaust);

    #endregion

    public void Open(Deck deck)
    {
        Deck = deck;
        Cards = GameManager.Game.Cards.CreateCards(deck).ToList();
    }

    public CardMoved AddCard(Card card, Zone zone = Zone.None)
    {
        card.zone = (zone == Zone.None) ? Zone.Deck : zone;
        Cards.Add(card);

        return new CardMoved(card, Zone.None, zone);
    }

    public CardMoved MoveCard(Card card, Zone zone)
    {
        Zone from = card.zone;
        Zone to = card.zone = zone;
        return new CardMoved(card, from, to);
    }

    public CardMoved DrawCard(Card card = null)
    {
        if (card == null || card.zone == Zone.Deck)
        {
            if (GetDeck().Length < 1) Recycle();
            card = GetDeck()[0];
        }

        if (GetHand().Length >= MaxHandSize) return MoveCard(card, Zone.Discard);

        return MoveCard(card, Zone.Hand);
    }

    public void Shuffle()
    {
        System.Random r = new System.Random();
        var deck = GetDeck();

        Card card;
        for (int i = 0, c = GetDeck().Length; i < c; i++)
        {
            int n = i + (int) (r.NextDouble() * (c - i));
            card = deck[n];
            deck[n] = deck[i];
            deck[i] = card;
        }
    }

    public void Recycle()
    {
        foreach (var card in GetDiscard()) MoveCard(card, Zone.Deck);
        Shuffle();
    }
}
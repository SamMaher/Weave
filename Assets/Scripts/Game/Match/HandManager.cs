using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class HandManager {
    
    private List<Card> Cards { get; set; }

    public HandManager()
    {
        OpenDeck();
    }

    #region "Get"

    public List<Card> GetCards(Zone zone = Zone.None)
    {
        if (zone == Zone.None) return Cards;
        return Cards.Where(card => card.Zone == zone).ToList();
    }

    public List<Card> GetDeck() => GetCards(Zone.Deck);

    public List<Card> GetHand() => GetCards(Zone.Hand);

    public List<Card> GetDiscard() => GetCards(Zone.Discard);

    public List<Card> GetExhausted() => GetCards(Zone.Exhaust);

    #endregion

    public void OpenDeck(string identity = null) // TODO : Create transport and model version of the cards. Models get used in game, Transports outside of.
    {
        var deckProvider = new DeckProvider();
        var cardsProvider = new CardsProvider();
        
        var deck = deckProvider.GetDeck(identity ?? GameController.Controller.PlayerManager.EquippedDeck);
        Cards = cardsProvider.CloneCardsFromDeck(deck).ToList();
        
        foreach (var card in Cards)
        {
            card.Zone = Zone.Deck;
            card.StartListening();
        }
    }

    public HandDrawn DrawHand()
    {
        var baseHandSize = GameController.Controller.PlayerManager.BaseHandSize;
        
        var oldHand = GetHand();
        foreach (var card in oldHand) MoveCard(card, Zone.Discard);

        var cardsToDraw = Mathf.Min(Cards.Count, baseHandSize);
        
        var newHand = new List<Card>();
        for (var i = cardsToDraw; i < 0; i--)
        {
            var newCard = DrawCard().Card;
            newHand.Add(newCard);
        }
        
        return new HandDrawn(newHand.ToArray());
    }

    public CardMoved AddCard(Card card, Zone zone = Zone.None)
    {
        card.Zone = (zone == Zone.None) ? Zone.Deck : zone;
        Cards.Add(card);

        return new CardMoved(card, Zone.None, zone);
    }

    public CardMoved MoveCard(Card card, Zone zone)
    {
        var from = card.Zone;
        var to = card.Zone = zone;
        
        return new CardMoved(card, from, to);
    }

    public CardMoved DrawCard(Card card = null)
    {
        var zone = card?.Zone ?? Zone.Deck;
        if (zone == Zone.Deck)
        {
            if (GetDeck().Count < 1) Recycle();
            card = GetDeck()[0];
        }
        
        var maxHandSize = GameController.Controller.PlayerManager.MaxHandSize;

        if (GetHand().Count >= maxHandSize) return MoveCard(card, Zone.Discard);

        return MoveCard(card, Zone.Hand);
    }

    public void ShuffleDeck()
    {
        GetDeck().ToList().Shuffle(); // TODO : This wont shuffle...
        // re: above...do we separate, shuffle, then recombine?
        // have multiple decks/dictionary of decks?
    }

    public void Recycle()
    {
        foreach (var card in GetDiscard()) MoveCard(card, Zone.Deck);
        ShuffleDeck();
    }
}
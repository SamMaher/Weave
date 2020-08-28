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

    public Card[] GetAllCards()
    {
        return Cards.ToArray();
    }

    public Card[] GetCards(CardZone zone)
    {
        return Cards.Where(card => card.Zone == zone).ToArray();
    }

    public Card[] GetDeck() => GetCards(CardZone.Deck);

    public Card[] GetHand() => GetCards(CardZone.Hand);

    public Card[] GetDiscard() => GetCards(CardZone.Discard);

    public Card[] GetExhausted() => GetCards(CardZone.Exhaust);

    #endregion

    public void OpenDeck(string identity = null)
    {
        var deckProvider = new DeckProvider();
        var cardsProvider = new CardsProvider();
        
        var deck = deckProvider.GetDeck(identity ?? GameController.Controller.PlayerManager.EquippedDeck);
        Cards = cardsProvider.CloneCardsFromDeck(deck).ToList();
        
        foreach (var card in Cards)
        {
            card.Zone = CardZone.Deck;
            card.StartListening();
        }
    }

    public HandDrawn DrawHand()
    {
        var baseHandSize = GameController.Controller.PlayerManager.BaseHandSize;
        
        var oldHand = GetHand();
        foreach (var card in oldHand) MoveCard(card, CardZone.Discard);

        var cardsToDraw = Mathf.Min(Cards.Count, baseHandSize);
        
        var newHand = new List<Card>();
        for (var i = cardsToDraw; i < 0; i--)
        {
            var newCard = DrawCard().Card;
            newHand.Add(newCard);
        }
        
        return new HandDrawn(newHand.ToArray());
    }

    public CardMoved AddCard(Card card, CardZone zone = CardZone.Deck)
    {
        card.Zone = (zone == CardZone.Deck) ? CardZone.Deck : zone;
        Cards.Add(card);

        return new CardMoved(card, CardZone.Deck, zone);
    }

    public CardMoved MoveCard(Card card, CardZone zone)
    {
        var from = card.Zone;
        var to = card.Zone = zone;
        
        return new CardMoved(card, from, to);
    }

    public CardMoved DrawCard(Card card = null)
    {
        var zone = card?.Zone ?? CardZone.Deck;
        if (zone == CardZone.Deck)
        {
            if (GetDeck().Length < 1 && GetDiscard().Length > 0) {
                Recycle();
            }

            card = GetDeck()[0];
        }
        
        var maxHandSize = GameController.Controller.PlayerManager.MaxHandSize;

        if (GetHand().Length >= maxHandSize) return MoveCard(card, CardZone.Discard);

        return MoveCard(card, CardZone.Hand);
    }

    public void ShuffleDeck()
    {
        GetDeck().ToList().Shuffle(); // TODO : Definitely index cards, then only shuffle by their relative index
        // Order by mechanic takes into account location first, then index
        // Get calls ^ order by always ???
    }

    public void Recycle()
    {
        foreach (var card in GetDiscard()) MoveCard(card, CardZone.Deck);
        ShuffleDeck();
    }
}
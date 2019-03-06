using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using UnityEngine;
using UnityEngine.Experimental.AI;

/// <summary>
/// 	Manages card data
/// </summary>
public class CardsManager {
    
    private Factory<Card> _CardFactory;
    public Dictionary<string, Card> Set { get; set; }
    public Deck Collection { get; set; }
    public Dictionary<string, Deck> Decks { get; set; }

    public CardsManager()
    {
        _CardFactory = new Factory<Card>();
        
        if (Set == null)
        {
            Set = _CardFactory.Load("card").ToDictionary(card => card.id);
        }

        if (Decks == null)
        {
            Decks = new Factory<Deck>().Load("deck").ToDictionary(deck => deck.id);
        }
    }

    public Deck GetDeck(string id) => Decks[id];

    // ToDO : These two methods could constitute a new statis class
    public Card CreateCard(string id)
    {
        return _CardFactory.Clone(Set[id]);
    }

    public Card[] CreateCards(Deck deck)
    {
        List<Card> cards = new List<Card>();

        foreach (var card in deck.cardList)
        for (var i = 0; i < card.Value; i++)
        {
            cards.Add(Set[card.Key]);
        }

        return _CardFactory.Clone(cards.ToArray());
    }
}
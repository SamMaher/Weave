using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using UnityEngine;
using UnityEngine.Experimental.AI;

/// <summary>
/// 	Manages Card data
/// </summary>
public class CardsProvider {
    
    private Factory<Card> _CardFactory; 
    private Dictionary<string, Card> Set { get; set; }
    private Dictionary<string, Deck> Decks { get; set; }

    public CardsProvider()
    {
        _CardFactory = new Factory<Card>();
        
        Set = _CardFactory.Load("Card").ToDictionary(card => card.Id);

        Decks = new Factory<Deck>().Load("deck").ToDictionary(deck => deck.Id);
    }

    public Deck GetDeck(string id) => Decks[id];
    
    public Card CreateCard(string id)
    {
        return _CardFactory.Clone(Set[id]);
    }

    public Card[] CreateCardsFromDeck(Deck deck)
    {
        List<Card> cards = new List<Card>();

        foreach (var card in deck.CardList)
        for (var i = 0; i < card.Value; i++)
        {
            cards.Add(Set[card.Key]);
        }

        var createdCards = _CardFactory.Clone(cards.ToArray());

        return createdCards;
    }
}
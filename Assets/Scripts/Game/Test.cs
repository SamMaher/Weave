using System.Linq;
using UnityEngine;
using UnityEngine.Experimental.AI;

public class Test : MonoBehaviour {
    private void Awake()
    {
        var game = GameManager.Game;

        var deck = GameManager.Game.Cards.Decks.First().Value;

        GameManager.Game.Match.Deck.Open(deck);

        var cards = GameManager.Game.Match.Deck.Cards;
    }
}
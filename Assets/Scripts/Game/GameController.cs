using System.Collections;
using System.Runtime.InteropServices.ComTypes;
using UnityEngine;

public class GameController : MonoBehaviour {

    private static GameController _gameController;

    public static GameController Game => _gameController;
    
    private void Singleton()
    {
        if (_gameController != null && _gameController != this)
        {
            Destroy(this);
            throw new System.Exception("An instance of this singleton already exists.");
        }

        _gameController = this;
    }
    
    private void Awake()
    {
        Singleton();
        
        var game = GameManager.Game;

        var deck = GameManager.Game.Cards.GetDeck("DA01");

        GameManager.Game.Match.Deck.Open(deck);

        var cards = GameManager.Game.Match.Deck.Cards;

        foreach (var card in cards) card.Activate();

        var testCard1 = cards[8];

        Debug.Log(testCard1.RenderText());
       
        GameManager.Game.Match.DrawCard();
        
        Debug.Log(testCard1.RenderText());
        
        GameManager.Game.Match.DrawCard();
        
        Debug.Log(testCard1.RenderText());
        
        var testCard2 = cards[18];
        
        Debug.Log(testCard2.RenderText());

        var startTurns = GameManager.Game.Match.States.Start();
        GameController.Game.StartCoroutine(startTurns);
    }
}
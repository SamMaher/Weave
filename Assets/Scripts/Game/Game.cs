using System.Text.RegularExpressions;
using UnityEngine;

public class Game : MonoBehaviour {

    public static void TestMatch()
    {
        GameController.Controller.New();
        GameController.NewMatch();
    }

    public static void FireRandomTests()
    {
        var cards = MatchController.Controller.HandManager.GetCards();

        foreach (var card in cards) card.StartListening();

        var testCard1 = cards[8];

        Debug.Log(testCard1.RenderText());
       
        MatchController.DrawCard();
        
        Debug.Log(testCard1.RenderText());
        
        MatchController.DrawCard();
        
        Debug.Log(testCard1.RenderText());
        
        var testCard2 = cards[18];
        
        Debug.Log(testCard2.RenderText());
    }
}

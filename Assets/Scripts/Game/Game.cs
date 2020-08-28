using UnityEngine;

public class Game : MonoBehaviour {

    public void TestGame()
    {
        GameController.NewGame();   
    }
    
    public void TestMatch()
    {
        GameController.NewMatch();
    }

    public void EndPlayerTurn()
    {
        MatchController.EndPlayerTurn();
    }
    
    public void DrawCard()
    {
        MatchController.DrawCard();
    }
    
    public void DiscardCard(Card card)
    {
        MatchController.DiscardCard(card);
    }
    
    public void DrawHand()
    {
        MatchController.DrawHand();
    }
}

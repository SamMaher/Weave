using System.Text.RegularExpressions;
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
}

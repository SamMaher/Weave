using System;
using System.Collections;
using UnityEngine;

/// <summary>
///     Match turn state
/// </summary>
public class MatchTurn : IState {

    public enum NextMatchTurn {
        PlayerTurn,
        EnemyTurn
    }
    
    public bool MatchTurnComplete { get; set; }
    public NextMatchTurn NextTurn { get; set; }

    public void StartRunning()
    {
        MatchTurnComplete = false;
        
        GameController.Game.StartCoroutine(ImagineWeAreWaitingGameStuff());
    }

    public bool IsRunning()
    {
        return !MatchTurnComplete;
    }

    public IState Exit()
    {
        switch (NextTurn)
        {
            case NextMatchTurn.PlayerTurn: return new PlayerTurn();
            case NextMatchTurn.EnemyTurn: return new EnemyTurn();
            default: throw new Exception("NextMatchTurn state not handled!");
        }
    }
    
    private IEnumerator ImagineWeAreWaitingGameStuff()
    {
        yield return new WaitForSeconds(2);
        MatchTurnComplete = true;
    }
}
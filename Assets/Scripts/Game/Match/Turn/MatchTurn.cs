using System;
using System.Collections;
using Boo.Lang;
using UnityEngine;

/// <summary>
///     ManagerController turn state
/// </summary>
public class MatchTurn : IState {

    public enum NextMatchTurn {
        PlayerTurn,
        EnemyTurn
    }
    
    public bool MatchTurnComplete { get; set; }
    public NextMatchTurn NextTurn { get; set; }

    public void Enter()
    {
        MatchTurnComplete = false;

        // TODO : We will pick up the list of match events/animations etc. run them, then return to a character turn
        // var registeredEvents = GetRegisteredMatchEvents();
        // Run registered events
        
        CoroutineHandler.Handler.StartCoroutine(ImagineWeAreWaitingGameStuff());
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
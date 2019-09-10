using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
///     // TODO
/// </summary>
public class MatchStart : IState {
    
    public bool MatchReady { get; set; }

    public void Enter()
    {
        MatchReady = false;
        
        CoroutineHandler.Handler.StartCoroutine(ImagineWeAreWaitingToLoadMatch());
    }

    public bool IsRunning()
    {
        return !MatchReady;
    }

    public IState Exit()
    {
        return new MatchTurn()
        {
            NextTurn = MatchTurn.NextMatchTurn.PlayerTurn
        };
    }
    
    private IEnumerator ImagineWeAreWaitingToLoadMatch()
    {
        yield return new WaitForSeconds(4);
        MatchReady = true;
    }
}
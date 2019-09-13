using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        MatchController.Controller.CharacterManager.NewEncounter();
        
        yield return new WaitForSeconds(1);
        MatchReady = true;
    }
}
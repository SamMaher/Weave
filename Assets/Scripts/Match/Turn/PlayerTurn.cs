using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
///     Player turn state
/// </summary>
public class PlayerTurn : IState { 

    public bool EndPlayerTurn { get; set; }
    
    public void StartRunning()
    {
        EndPlayerTurn = false;
        
        GameController.Game.StartCoroutine(WaitThenEndTurn());
    }

    public bool IsRunning()
    {
        return !EndPlayerTurn;
    }

    public IState Exit()
    {
        return new MatchTurn()
        {
            NextTurn = MatchTurn.NextMatchTurn.EnemyTurn
        };
    }

    private IEnumerator WaitThenEndTurn()
    {
        yield return new WaitForSeconds(2);
        EndPlayerTurn = true;
    }
}
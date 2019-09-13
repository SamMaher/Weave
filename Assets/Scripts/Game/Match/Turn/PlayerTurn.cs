using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTurn : IState { 

    public bool EndPlayerTurn { get; set; }
    
    public void Enter()
    {
        EndPlayerTurn = false;
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
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTurn : IState, IMatchState {
    
    public bool EnemyActionsComplete { get; set; }
    public Player Player { get; set; }
    public List<Enemy> Enemies { get; set; }

    public void Enter()
    {
        EnemyActionsComplete = false;
        var characterManager = MatchController.Controller.CharacterManager;
        Player = characterManager.GetPlayer();
        Enemies = characterManager.GetEnemies();
        
        // Loop through and run each enemies moves
        foreach (var enemy in Enemies)
        foreach (var move in enemy.Moves)
        {
            var moveInfo = move.GetMoveInfo(enemy);
            if (!moveInfo.Valid) continue;
            move.Invoke(moveInfo);
            break;
        }
        
        CoroutineHandler.Handler.StartCoroutine(ImagineWeAreWaitingForAnimations());
    }

    public bool IsRunning()
    {
        return !EnemyActionsComplete;
    }

    public IState Exit()
    {
        return new MatchTurn()
        {
            NextTurn = MatchTurn.NextMatchTurn.PlayerTurn
        };
    }
    
    private IEnumerator ImagineWeAreWaitingForAnimations()
    {
        yield return new WaitForSeconds(1);
        EnemyActionsComplete = true;
    }
}
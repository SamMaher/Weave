using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
///     Enemy turn state
/// </summary>
public class EnemyTurn : IState {
    
    public bool EnemyActionsComplete { get; set; }
    public Player Player { get; set; }
    public List<Enemy> Enemies { get; set; }

    public void Enter()
    {
        EnemyActionsComplete = false;
        var characterManager = MatchController.Controller.CharacterManager;
        Player = characterManager.GetPlayer();
        Enemies = characterManager.GetEnemies();

        // Loop through and run each enemies moves // TODO : Let's do this once a frame
        foreach (var enemy in Enemies)
        foreach (var move in enemy.Moves)
        {
            var moveInfo = move.GetMoveInfo(enemy);
            if (!moveInfo.Valid) continue;
            // TODO : Potentially handle random chance? 'Chance' condition, that rolls to determine validity.
            // Or, weight every condition, additively, highest met move is done
            move.Invoke(moveInfo); // TODO : Create animation
            break;
        }
        
        // TODO : Queue animations
        CoroutineHandler.Handler.StartCoroutine(ImagineWeAreWaitingForAnimations());
    }

    public bool IsRunning() // TODO : Let's lock this to FixedUpdate to avoid thread shtuff?
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
    
    private IEnumerator ImagineWeAreWaitingForAnimations() // TODO : Util for Coroutines?
    {
        yield return new WaitForSeconds(2);
        EnemyActionsComplete = true;
    }
}
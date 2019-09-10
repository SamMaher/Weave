using UnityEngine;

/// <summary>
/// 	Enemy Character
/// </summary>
public class Enemy : Character {

    public EnemyMove[] Moves { get; set; }
    
    public override string GetIdentifier() // TODO : Interface this, anything that's loggable should be 'Entity'
    {
        return $"{Id}:{Name}"; // TODO : Add some sort of reasonable UID to this for logging
    }
}
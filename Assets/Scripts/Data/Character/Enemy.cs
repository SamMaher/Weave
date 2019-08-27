using UnityEngine;

/// <summary>
/// 	Enemy Character
/// </summary>
public class Enemy : Character {
    
    public string Id { get; set; }
    public string Name { get; set; }
    public EnemyMove[] Moves { get; set; }
    
    public override string GetIdentifier() // TODO : Interface this, anything that's loggable should be 'IIdentifiable'
    {
        return $"{Id}:{Name}"; // TODO : Add some sort of reasonable UID to this for logging
    }
}
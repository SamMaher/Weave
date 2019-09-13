using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SocialPlatforms;

public class Target : Condition {
    
    public TargetType TargetType { get; set; }
    public int? MinimumHealth { get; set; }
    public int? MaximumHealth { get; set; }
    public int? MinimumHealthLost { get; set; }
    public int? MinimumArmour { get; set; }

    public override List<Character> FilterTargets(List<Character> targets)
    {
        var potentialTargets = FilterByTargetType(targets);
        if (!potentialTargets.Any()) return null;
        
        var validTargets = potentialTargets
            .Where(target => 
                (MinimumHealth == null || target.Health >= MinimumHealth)
                && (MaximumHealth == null || target.Health <= MaximumHealth)
                && (MinimumHealthLost == null || (target.MaxHealth - target.Health) >= MinimumHealthLost)
                && (MinimumArmour == null || target.Armour >= MinimumArmour))
            .ToList();

        return validTargets;
    }

    private List<Character> FilterByTargetType(List<Character> targets)
    {
        switch (TargetType)
        {
            case TargetType.All: return targets;
            case TargetType.Player: return GetPlayerFromCharacters(targets);
            case TargetType.Enemy: return GetEnemiesFromCharacters(targets);
            default: return null;
        }
    }

    private List<Character> GetEnemiesFromCharacters(List<Character> targets)
    {
        return targets
            .Where(target => target is Enemy)
            .ToList();
    }
    
    private List<Character> GetPlayerFromCharacters(List<Character> targets)
    {
        return targets
            .Where(target => target is Player)
            .ToList();
    }
}
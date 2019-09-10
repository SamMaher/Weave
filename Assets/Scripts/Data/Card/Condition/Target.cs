using System.Collections.Generic;
using System.Linq;

/// <summary>
///     Valid target for this action
/// </summary>
public class Target : Condition {
    
    public TargetType TargetType { get; set; }
    public int? MinimumHealth { get; set; }
    public int? MaximumHealth { get; set; }
    public int? MinimumHealthLost { get; set; } // TODO: Separate the logic into the other classes? HealthLost.cs etc?
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

    private List<Character> FilterByTargetType(List<Character> targets) // TODO : Break this into helper class or the enum itself if re-used
    {
        var matchController = MatchController.Controller;
        var allies = matchController.CharacterManager.GetAllies();
        var enemies = matchController.CharacterManager.GetEnemies().Cast<Character>().ToList(); // TODO : Not nice
        
        var isPlayerTurn = matchController.MatchStateManager.Current is PlayerTurn;
        
        switch (TargetType)
        {
            case TargetType.Enemy: return (isPlayerTurn) ? enemies : allies;
            case TargetType.Ally: return (isPlayerTurn) ? allies : enemies;
            case TargetType.All: return matchController.CharacterManager.GetCharacters();
            default: return null;
        }
    }
}
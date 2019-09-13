using System.Collections.Generic;
using System.Linq;

public class MinimumTargets : Condition {
    
    public override List<Character> FilterTargets(List<Character> targets)
    {
        var validTargets = targets
            .Where(target => true) // TODO: NOT IMPLEMENTED
            .ToList();

        return validTargets;
    }
}
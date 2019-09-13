using System.Linq;
using UnityEngine;

public class Attribute {
    
    public string Name { get; set; }
    public int Value { get; set; }
    public Modifier[] Modifiers { get; set; }

    public int GetValue()
    {
        return Modifiers.Aggregate(
            Value,
            (currentValue, modifier) 
                => modifier.CalculateModifier(currentValue)
        );
    }
}
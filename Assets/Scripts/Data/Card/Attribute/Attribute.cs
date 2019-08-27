using System.Linq;

/// <summary>
///     Defines values for Card Moves
/// </summary>
public class Attribute {
    
    public string Name { get; set; }
    private int _value { get; set; }
    public int Value
    {
        get { return CalculateValue(); }
        set { _value = value; }
    }
    
    public Modifier[] Modifiers { get; set; }

    public int CalculateValue() // TODO : Use backing field for this
    {
        return Modifiers.Aggregate(
            _value, 
            (currentValue, modifier) 
                => modifier.CalculateModifier(currentValue)
        );
    }
}
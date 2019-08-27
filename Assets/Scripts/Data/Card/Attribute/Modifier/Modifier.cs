using System;

/// <summary>
///     Modifies an AttributeName
/// </summary>
public abstract class Modifier {

    public int Value { get; set; }
    
    public abstract int CalculateModifier(int value);
}
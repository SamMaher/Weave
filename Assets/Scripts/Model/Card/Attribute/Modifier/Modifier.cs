using System;

public abstract class Modifier {

    public int Value { get; set; }
    
    public abstract int CalculateModifier(int value);
}
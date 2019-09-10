using System;
using UnityEngine;

/// <summary>
///     Changes an AttributeName when an event occurs
/// </summary>
public class Increment : Modifier, IEventListener {
    
    public EventName EventName { get; set; } // TODO: Inherit from EventModifier
    public int IncrementedValue { get; set; }

    public void StartListening() // TODO : Seems clunky - perhaps put this in constructors called when the match starts?
    {
        EventHandler.StartListening(EventName, IncrementValue);
    }
    
    public void StopListening()
    {
        EventHandler.StopListening(EventName, IncrementValue);
    }
    
    public void IncrementValue(object sender, EventData eventData)
    {
        IncrementedValue += Value;
    }

    public override int CalculateModifier(int value)
    {
        return value + IncrementedValue;
    }
}
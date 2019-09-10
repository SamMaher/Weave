using System;
using System.Linq;
using System.Runtime.Remoting.Messaging;

/// <summary>
///     Card data model
/// </summary>
public class Card : Entity {
    
    public string Text { get; set; }
    public Condition[] Conditions { get; set; }
    public Action[] Actions { get; set; }
    public Zone Zone { get; set; }
    public Rarity Rarity { get; set; }

    public void StartListening() // TODO : Make this process more robust. Perhaps differentiate Card Transport from Model, create the Model at match start
    {
        foreach (var modifier in Actions
            .OfType<IAttribute>()
            .SelectMany(action => action.Attribute.Modifiers))
        {
            (modifier as IEventListener)?.StartListening();
        }
    }
}
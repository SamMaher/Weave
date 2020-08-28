using System.Linq;

public class Card : Entity {
    
    public string Text { get; set; }
    public Condition[] Conditions { get; set; }
    public Action[] Actions { get; set; }
    public CardZone Zone { get; set; }
    public Rarity Rarity { get; set; }

    public void StartListening()
    {
        foreach (var modifier in Actions
            .OfType<IAttribute>()
            .SelectMany(action => action.Attribute.Modifiers))
        {
            (modifier as IEventListener)?.StartListening();
        }
    }
}
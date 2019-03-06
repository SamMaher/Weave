/// <summary>
///     Changes an attribute when an event occurs
/// </summary>
public class Increment : Modifier {
    public EventName eventName { get; set; }
    public int value { get; set; }
}
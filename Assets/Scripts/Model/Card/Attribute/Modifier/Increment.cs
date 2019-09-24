public class Increment : Modifier, IEventListener {
    
    public EventName EventName { get; set; }
    public int IncrementedValue { get; set; }

    public void StartListening()
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
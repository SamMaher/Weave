/// <summary>
///     Indicates that this object listens to an event
/// </summary>
public interface IEventListener {
    
    EventName EventName { get; set; }

    void StartListening();

    void StopListening();
}
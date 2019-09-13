public interface IEventListener {
    
    EventName EventName { get; set; }

    void StartListening();

    void StopListening();
}
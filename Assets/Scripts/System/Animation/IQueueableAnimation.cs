public interface IQueueableAnimation {
    
    bool Completed { get; set; }
    
    void Animate(float deltaTime);
}
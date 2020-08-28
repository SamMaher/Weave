public interface IState {
    
    void Enter();

    bool IsRunning();

    IState Exit();
}
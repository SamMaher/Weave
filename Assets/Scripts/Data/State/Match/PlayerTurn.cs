/// <summary>
///     Player turn state
/// </summary>
public class PlayerTurn : IState {
    public void Enter()
    {
        throw new System.NotImplementedException();
    }

    public bool Run()
    {
        throw new System.NotImplementedException();
    }

    public IState Exit()
    {
        return new MatchTurn();
    }
}
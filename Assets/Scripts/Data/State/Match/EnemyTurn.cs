/// <summary>
///     Enemy turn state
/// </summary>
public class EnemyTurn : IState {
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
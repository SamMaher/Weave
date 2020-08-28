public class PlayerTurn : IState, IMatchState
{
    public bool EndPlayerTurn { get; set; }
    
    public void Enter()
    {
        EndPlayerTurn = false;
    }

    public bool IsRunning()
    {
        return !EndPlayerTurn;
    }

    public IState Exit()
    {
        return new MatchTurn()
        {
            NextTurn = MatchTurn.NextMatchTurn.EnemyTurn
        };
    }
}
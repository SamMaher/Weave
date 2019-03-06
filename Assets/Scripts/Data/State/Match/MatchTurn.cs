/// <summary>
///     Match turn state
/// </summary>
public class MatchTurn : IState {
    public static bool playerTurnNext = false;

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
        // TODO : Implement actual turn checking logic here
        if (playerTurnNext)
        {
            playerTurnNext = false;
            return new PlayerTurn();
        }
        else
        {
            playerTurnNext = true;
            return new EnemyTurn();
        }
    }
}
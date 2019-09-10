/// <summary>
/// 	Handles ManagerController States, turn order etc.
/// </summary>
public class MatchStateManager : StateManager {
    
    public MatchStateManager()
    {
        States = new[]
        {
            typeof(MatchStart),
            typeof(MatchTurn),
            typeof(PlayerTurn),
            typeof(EnemyTurn)
        };

        Current = new MatchStart();
    }

    public TurnChanged EndPlayerTurn()
    {
        var stateChanged = Next();
        var turnChanged = TurnChanged.FromStateChanged(stateChanged);
        return turnChanged;
    }
}
/// <summary>
/// 	Handles Match States, turn order etc.
/// </summary>
public class MatchStateManager : StateManager {
    
    public MatchStateManager()
    {
        States = new[]
        {
            typeof(PlayerTurn),
            typeof(EnemyTurn),
            typeof(MatchTurn),
        };

        Current = new MatchTurn();
    }

    public TurnChanged EndPlayerTurn()
    {
        var stateChanged = Next();
        var turnChanged = TurnChanged.FromStateChanged(stateChanged);
        return turnChanged;
    }
}
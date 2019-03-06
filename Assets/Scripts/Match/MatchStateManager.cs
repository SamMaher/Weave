/// <summary>
/// 	Handles Match States, turn order etc.
/// </summary>
public class MatchStateManager : StateManager {
    public MatchStateManager()
    {
        states = new[]
        {
            typeof(PlayerTurn),
            typeof(EnemyTurn),
            typeof(MatchTurn),
        };

        current = new MatchTurn();
    }
}
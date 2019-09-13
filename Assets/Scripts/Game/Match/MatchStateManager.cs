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

    public bool IsPlayerTurn()
    {
        return MatchController.Controller.MatchStateManager.Current is PlayerTurn;
    }

    public TurnChanged EndPlayerTurn()
    {
        if (!IsPlayerTurn()) throw new NotPlayerTurnException();
            
        var stateChanged = Next();
        var turnChanged = new TurnChanged(stateChanged.FromStateName, stateChanged.ToStateName);
        
        return turnChanged;
    }
}
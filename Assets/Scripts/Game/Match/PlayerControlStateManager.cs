public class PlayerControlStateManager : StateManager
{
    public bool IsPlayerActing { get; set; }
    public bool IsPlayerIdle { get; set; }

    public PlayerControlStateManager()
    {
        States = new[]
        {
            typeof(Idle),
            typeof(Blocked),
            typeof(Choosing),
            typeof(Acting)
        };

        Current = new Idle();
        IsPlayerIdle = true;
    }

    public TurnChanged SetPlayerActing()
    {
        ClearStateVariables();
        IsPlayerActing = true;

        var newActingState = new Acting();
        var stateChanged = Next(newActingState);
        var turnChanged = new TurnChanged(stateChanged.FromStateName, stateChanged.ToStateName);
        
        return turnChanged;
    }

    public TurnChanged SetPlayerIdle()
    {
        ClearStateVariables();
        IsPlayerIdle = true;

        var newIdleState = new Idle();
        var stateChanged = Next(newIdleState);
        var turnChanged = new TurnChanged(stateChanged.FromStateName, stateChanged.ToStateName);

        return turnChanged;
    }

    public TurnChanged SetPlayerInputBlocked()
    {
        ClearStateVariables();

        var newBlockedState = new Blocked();
        var stateChanged = Next(newBlockedState);
        var turnChanged = new TurnChanged(stateChanged.FromStateName, stateChanged.ToStateName);

        return turnChanged;
    }

    public TurnChanged SetPlayerChoosing()
    {
        ClearStateVariables();

        var newChoosingState = new Choosing();
        var stateChanged = Next(newChoosingState);
        var turnChanged = new TurnChanged(stateChanged.FromStateName, stateChanged.ToStateName);

        return turnChanged;
    }

    private void ClearStateVariables()
    {
        IsPlayerActing = false;
        IsPlayerIdle = false;
    }
}
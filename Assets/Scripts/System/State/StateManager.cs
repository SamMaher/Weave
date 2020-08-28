using System;
using System.Collections;

public abstract class StateManager {
    
    protected Type[] States { get; set; }
    public IState Current { get; set; }

    public void Start()
    {
        CoroutineHandler.Handler.StartCoroutine(StartStates());
    }

    private IEnumerator StartStates()
    {
        Current.Enter();
        while (true)
        {
            while (Current.IsRunning()) yield return null;
            var eventData = Exit();
            EventHandler.Notify(EventName.TurnEnded, eventData);
        }
    }

    protected StateChanged Exit()
    {
        var exitState = Current.Exit();
        return Next(exitState);
    }

    protected StateChanged Next(IState newState)
    {
        var fromStateName = Current.GetType().ToString();
        Current = newState;
        var toStateName = Current.GetType().ToString();
        Current.Enter();

        return new StateChanged(fromStateName, toStateName);
    }
}
using System;
using System.Collections;
using UnityEngine;

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
            var eventData = Next();
            EventHandler.Notify(EventName.TurnEnded, eventData);
        }
    }

    protected StateChanged Next(IState newState = null)
    {
        var fromStateName = Current.GetType().ToString();
        var exitState = Current.Exit();
        Current = newState ?? exitState;
        var toStateName = Current.GetType().ToString();
        Current.Enter();

        return new StateChanged(fromStateName, toStateName);
    }
}
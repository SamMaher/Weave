using System;
using System.Collections;
using UnityEngine;

/// <summary>
/// 	Handles States
/// </summary>
public abstract class StateManager {
    
    protected Type[] States { get; set; }
    public IState Current { get; set; }

    public IEnumerator Start()
    {
        Current.StartRunning();
        while (true)
        {
            while (Current.IsRunning()) yield return null;
            Next();
        }
    }

    protected StateChanged Next(IState newState = null)
    {
        var fromStateName = Current.GetType().ToString();
        var exitState = Current.Exit();
        Current = newState ?? exitState;
        var toStateName = Current.GetType().ToString();
        Current.StartRunning();

        return new StateChanged(fromStateName, toStateName);
    }
}
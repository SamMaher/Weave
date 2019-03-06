using System;

/// <summary>
/// 	Handles States
/// </summary>
public class StateManager {
    public Type[] states;
    public IState current;

    public void Run()
    {
        if (!current.Run()) return;
        var nextState = current.Exit();
        current = nextState;
        current.Enter();
    }

    public void Next(IState newState = null)
    {
        var exitState = current.Exit();
        current = newState ?? exitState;
        current.Enter();
    }
}
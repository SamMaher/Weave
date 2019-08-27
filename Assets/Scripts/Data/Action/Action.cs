using System;

/// <summary>
///     Effect when played
/// </summary>
public abstract class Action {
    
    public abstract void Invoke(ActionInfo actionInfo);
}
using System;
using System.Collections.Generic;

/// <summary>
///     Conditions required for an Action to be performed To be played
/// </summary>
public abstract class Condition {

    public abstract List<Character> FilterTargets(List<Character> targets);
}
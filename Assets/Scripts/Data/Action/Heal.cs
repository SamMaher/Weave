﻿/// <summary>
///     Action for healing a Character by a given amount
/// </summary>
public class Heal : Action, IAttribute {
    
    public Attribute Attribute { get; set; }
    
    public override void Invoke(ActionInfo actionInfo)
    {
        GameManager.Game.Match.HealCharacter(actionInfo.Target, Attribute.Value);
    }
}
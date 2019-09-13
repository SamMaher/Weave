using UnityEngine;

public class Damage : Action, IAttribute {
    
    public Attribute Attribute { get; set; }

    public override void Invoke(ActionInfo actionInfo)
    {
        MatchController.DamageCharacter(actionInfo.Target, Attribute.GetValue());
    }
}
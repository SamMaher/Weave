/// <summary>
///     Damages a Character by the given amount
/// </summary>
public class Damage : Action, IAttribute {
    
    public Attribute Attribute { get; set; }

    public override void Invoke(ActionInfo actionInfo)
    {
       MatchController.DamageCharacter(actionInfo.Target, Attribute.Value);
    }
}
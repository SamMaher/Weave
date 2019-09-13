public class Heal : Action, IAttribute {
    
    public Attribute Attribute { get; set; }
    
    public override void Invoke(ActionInfo actionInfo)
    {
        MatchController.HealCharacter(actionInfo.Target, Attribute.GetValue());
    }
}
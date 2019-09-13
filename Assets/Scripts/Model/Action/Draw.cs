public class Draw : Action, IAttribute {
    
    public Attribute Attribute { get; set; }
    
    public override void Invoke(ActionInfo actionInfo)
    {
        MatchController.DrawCard();
    }
}
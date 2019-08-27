/// <summary>
///     Modifies an AttributeName if a Value is within a range
/// </summary>
public class Threshold : Modifier { // TODO : How should we incorporate 'Count' -> i.e. Has 2 Damage for every Card drawn this turn
    
    public string AttributeName { get; set; }
    public int? Above { get; set; }
    public int? Below { get; set; }
    
    public override int CalculateModifier(int value)
    {
        var attributeValue = GameManager.Game.Match.Attributes.Value(AttributeName);
        if ((Above == null || attributeValue > Above) 
            && (Below == null || attributeValue < Below))
        {
            return value + Value;
        }
        return Value;
    }
}
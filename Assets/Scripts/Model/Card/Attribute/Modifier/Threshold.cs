public class Threshold : Modifier {
    
    public string AttributeName { get; set; }
    public int? Above { get; set; }
    public int? Below { get; set; }
    
    public override int CalculateModifier(int value)
    {
        var attributeValue = AttributeHandler.Value(AttributeName);
        if ((Above == null || attributeValue > Above) 
            && (Below == null || attributeValue < Below))
        {
            return value + Value;
        }
        return Value;
    }
}
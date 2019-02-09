/// <summary>
///     Card data model
/// </summary>
public class Card : IProduct {
    
    public string id { get; set; }
    public string name { get; set; }
    public string text { get; set; }
    public Condition[] conditions { get; set; }
    public Action[] actions { get; set; }
    public Zone zone { get; set; }
}
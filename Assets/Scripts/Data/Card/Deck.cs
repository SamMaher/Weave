using System.Collections.Generic;

/// <summary>
/// 	Represents a Deck
/// </summary>
public class Deck : IProduct {
    
    public string Id { get; set; }
    public string Name { get; set; }
    public Dictionary<string, int> CardList { get; set; }
}
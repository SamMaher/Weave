using System.Collections.Generic;

/// <summary>
/// 	Represents a Deck
/// </summary>
public class Deck : IProduct {
    public string id;
    public string name;
    public Dictionary<string, int> cardList;
}
using System;

/// <summary>
///     Card data model
/// </summary>
public class Card : IProduct {
    // TODO : Rarity
    public string Id { get; set; }
    public string Name { get; set; }
    public string Text { get; set; }
    public Condition[] Conditions { get; set; }
    public Action[] Actions { get; set; }
    public Zone Zone { get; set; }
}
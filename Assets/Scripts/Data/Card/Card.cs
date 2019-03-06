using System;

/// <summary>
///     Card data model
/// </summary>
public class Card : IProduct {
    // TODO : Rarity
    public string id;
    public string name;
    public string text;
    public Condition[] conditions;
    public Action[] actions;
    public Zone zone;
}
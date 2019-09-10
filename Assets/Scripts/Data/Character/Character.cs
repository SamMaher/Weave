using System;
using UnityEngine;

/// <summary>
/// 	Character data model
/// </summary>
public abstract class Character : Entity {

    public int MaxHealth { get; set; }
    public int Health { get; set; }
    public int Armour { get; set; }

    public abstract string GetIdentifier();
}
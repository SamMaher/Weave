using System;
using UnityEngine;

/// <summary>
/// 	Character data model
/// </summary>
public class Character {
    public int maxHealth { get; set; }
    private int _health { get; set; }

    public int health
    {
        get { return _health; }
        set { _health = Mathf.Clamp(value, 0, maxHealth); }
    }

    public int armour { get; set; }

    public virtual bool Dead
    {
        get { return (health <= 0); }
        set { health = (value) ? 0 : Math.Max(health, 1); }
    }
}
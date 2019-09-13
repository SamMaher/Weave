using System;
using UnityEngine;

public abstract class Character : Entity {

    public int MaxHealth { get; set; }
    public int Health { get; set; }
    public int Armour { get; set; }
}
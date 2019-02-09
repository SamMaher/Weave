using System;
using UnityEngine;

/// <summary>
/// Character data model
/// </summary>
public class Character {

	public string name;
	public int maxHealth = 5;
	private int _health;
	public int health
	{
		get { return _health; }
		set { _health = Mathf.Clamp(value, 0, maxHealth); }
	}
	public int armour = 1;
	public virtual bool Dead
	{
		get { return (health <= 0); }
		set { health = (value) ? 0 : Math.Max(health, 1); }
	}
}

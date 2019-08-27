using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

/// <summary>
/// 	Manages Character data
/// </summary>
public class CharacterManager {

    private Factory<Enemy> CharacterFactory;
    private Dictionary<string, Enemy> Set;
    private List<Character> Characters { get; set; }

    public CharacterManager()
    {
        CharacterFactory = new Factory<Enemy>();
        
        Set = CharacterFactory.Load("enemy").ToDictionary(enemy => enemy.Id);

        Characters = new List<Character>() { new Player() };
    }
    
    #region Get

    public List<Character> GetCharacters() => Characters;

    public Player GetPlayer() => Characters.OfType<Player>().First();

    public List<Character> GetAllies() => Characters.Except(GetEnemies()).ToList();

    public List<Enemy> GetEnemies() => Characters.OfType<Enemy>().ToList();
    
    #endregion

    public CharacterDamaged DamageCharacter(Character target, int damage)
    {
        var targetHealthAfterDamage = Math.Max(0, target.Health - damage);
        var damageToDeal = target.Health - targetHealthAfterDamage;
        target.Health -= damageToDeal;

        return new CharacterDamaged(target, damage);
    }

    public CharacterHealed HealCharacter(Character target, int heal)
    {
        var targetHealthAfterHeal = Math.Min(target.MaxHealth, target.Health + heal);
        var healthToHeal = targetHealthAfterHeal - target.Health;
        target.Health += healthToHeal;
        
        return new CharacterHealed(target, heal);
    }
}
using System;
using System.CodeDom;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CharacterManager {

    private Player Player { get; set; }
    private List<Enemy> Enemies { get; set; }
    
    #region Get

    public List<Character> GetCharacters()
    {
        var allCharactersList = new List<Character>();
        
        allCharactersList.AddRange(Enemies);
        allCharactersList.Add(Player);

        return allCharactersList;
    }

    public Player GetPlayer() => Player;

    public List<Enemy> GetEnemies() => Enemies;
    
    #endregion

    public void NewEncounter()
    {
        var encounterProvider = new EncounterProvider();
        var enemyProvider = new EnemyProvider();

        var encounter = encounterProvider.GetRandomEncounter();

        Player = new Player();
        Enemies = enemyProvider.CloneEnemiesFromEncounter(encounter).ToList();
    }
    
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
using Boo.Lang;

public class EnemyProvider : JsonProvider<Enemy> {

    protected override string GetJsonDataFileName() => "enemy";
    
    public Enemy[] CloneEnemiesFromEncounter(Encounter encounter)
    {
        var enemies = new List<Enemy>();

        foreach (var enemyIdentity in encounter.EnemyList)
        {
            enemies.Add(Read(enemyIdentity));
        }
                
        var createdEnemies = Clone(enemies.ToArray());
        return createdEnemies;
    }
}
/// <summary>
/// 	Player Character
/// </summary>
public class Player : Character {
    
    public Player()
    {
        MaxHealth = 10;
        Health = MaxHealth;
        Armour = 5;
    }

    public override string GetIdentifier()
    {
        return "Player";
    }
}
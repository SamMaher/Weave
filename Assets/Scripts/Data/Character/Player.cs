/// <summary>
/// 	Player Character
/// </summary>
public class Player : Character {
    public Player()
    {
        MaxHealth = 6;
        Health = MaxHealth;
        Armour = 3;
    }

    public override string GetIdentifier()
    {
        return "Player";
    }
}
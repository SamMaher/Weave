public class PlayerManager
{
    public string EquippedDeck = "A001"; // TODO : Player settings to JSON
    public int MaxHandSize = 8;
    public int BaseHandSize = 4;
    
    public void SetEquippedDeck(string identity)
    {
        EquippedDeck = identity;
    }
}

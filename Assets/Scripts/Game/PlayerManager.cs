public class PlayerManager {

    public string EquippedDeck = "DA01"; // TODO : Player settings to JSON
    public int MaxHandSize = 8;
    public int BaseHandSize = 4;
    
    public void SetEquippedDeck(string identity)
    {
        EquippedDeck = identity; // TODO : Exception if deck doesn't exist?
    }
}

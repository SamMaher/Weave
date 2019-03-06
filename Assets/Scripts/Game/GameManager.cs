/// <summary>
/// 	Manages Game data and Game flow
/// </summary>
public class GameManager {
    
    private static GameManager _Game { get; set; }

    public static GameManager Game => _Game ?? (_Game = new GameManager());

    public CardsManager Cards { get; set; }
    public MatchManager Match { get; set; }

    private GameManager()
    {
        Cards = new CardsManager();
        Match = new MatchManager();
    }
}
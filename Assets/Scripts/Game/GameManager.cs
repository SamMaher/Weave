/// <summary>
/// 	Manages Game data and Game flow
/// </summary>
public class GameManager {
    
    private static GameManager _Game { get; set; }

    public static GameManager Game => _Game ?? (_Game = new GameManager());

    public CardsProvider Cards { get; set; }
    public MatchManager Match { get; set; }

    private GameManager()
    {
        Cards = new CardsProvider();
        Match = new MatchManager();
    }
}
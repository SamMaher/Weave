using System.Collections.Generic;

public class GameController : ManagerController {

    private static GameController _controller;
    public static GameController Controller
    {
        get 
        {            
            if (_controller != null) return _controller;
            _controller = new GameController();
            return _controller;
        }
    }

    public PlayerManager PlayerManager;
    
    protected override void AddManagers()
    {
        PlayerManager = new PlayerManager();
    }

    protected override void RemoveManagers()
    {
        PlayerManager = null;
    }

    public static void NewGame()
    {
        Controller.New();
    }

    public static void NewMatch()
    {
        var eventData = MatchController.NewMatch();
        
        EventHandler.Notify(EventName.NewMatch, eventData);
    }
}
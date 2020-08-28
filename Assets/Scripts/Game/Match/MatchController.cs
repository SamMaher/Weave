public class MatchController : ManagerController {
    
    private static MatchController _controller { get; set; }
    public static MatchController Controller
    {
        get 
        {            
            if (_controller != null) return _controller;
            _controller = new MatchController();
            return _controller;
        }
    }

    public PlayerControlStateManager PlayerControlStateManager;
    public MatchStateManager MatchStateManager;
    public HandManager HandManager;
    public CharacterManager CharacterManager;
    public MatchViewManager MatchViewManager;

    protected override void AddManagers()
    {
        CharacterManager = new CharacterManager();
        MatchStateManager = new MatchStateManager();
        PlayerControlStateManager = new PlayerControlStateManager();
        HandManager = new HandManager();
        MatchViewManager = new MatchViewManager();
    }

    protected override void RemoveManagers()
    {
        MatchStateManager = null;
        HandManager = null;
        CharacterManager = null;
        MatchViewManager = null;
    }

    public static NewMatch NewMatch()
    {
        Controller.New(); 
        Controller.MatchStateManager.Start();
        
        return new NewMatch();
    }
    
    public static void DamageCharacter(Character target, int damage)
    {
        var characterDamaged = Controller.CharacterManager.DamageCharacter(target, damage);
        
        EventHandler.Notify(EventName.CharacterDamaged, characterDamaged);
    }
    
    public static void HealCharacter(Character target, int heal)
    {
        var characterHealed = Controller.CharacterManager.HealCharacter(target, heal);
        
        EventHandler.Notify(EventName.CharacterHealed, characterHealed);
    }

    public static void PlayCard(Card card)
    {
//        var cardMoved = Controller.Match.PlayCard(card, Zone.Discard);
//
//        EventHandler.Notify(EventName.CardDiscarded, cardMoved);
    }

    public static void DrawHand()
    {
        var handDrawn = Controller.HandManager.DrawHand();
        
        EventHandler.Notify(EventName.HandDrawn, handDrawn);
    }

    public static void DrawCard(Card card = null)
    {
        var cardMoved = Controller.HandManager.DrawCard(card);
        
        EventHandler.Notify(EventName.CardDrawn, cardMoved);
    }

    public static void DiscardCard(Card card)
    {
        var cardMoved = Controller.HandManager.MoveCard(card, CardZone.Discard);

        EventHandler.Notify(EventName.CardDiscarded, cardMoved);
    }

    public static void EndPlayerTurn()
    {
        var turnEnded = Controller.MatchStateManager.EndPlayerTurn();
        
        EventHandler.Notify(EventName.TurnEnded, turnEnded);
    }
}
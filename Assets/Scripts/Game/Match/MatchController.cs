using System.Collections.Generic;
using UnityEngine;

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

    public AttributeManager AttributeManager;
    public MatchStateManager MatchStateManager;
    public HandManager HandManager;
    public CharacterManager CharacterManager;

    protected override void AddManagers()
    {
        AttributeManager = new AttributeManager();
        MatchStateManager = new MatchStateManager();
        HandManager = new HandManager();
        CharacterManager = new CharacterManager();
    }

    protected override void RemoveManagers()
    {
        AttributeManager = null;
        MatchStateManager = null;
        HandManager = null;
        CharacterManager = null;
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
        var cardMoved = Controller.HandManager.MoveCard(card, Zone.Discard);

        EventHandler.Notify(EventName.CardDiscarded, cardMoved);
    }

    public static void EndTurn()
    {
        var turnEnded = Controller.MatchStateManager.EndPlayerTurn();
        
        EventHandler.Notify(EventName.TurnEnded, turnEnded);
    }
}
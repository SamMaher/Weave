using System.Diagnostics;
using UnityEditor;

/// <summary>
/// 	Handles Moves and generates event data
/// </summary>
public class MatchManager {
    
    public MatchStateManager States;
    public AttributeProvider Attributes;
    public DeckManager Deck;
    public CharacterManager Characters;

    public MatchManager()
    {
        States = new MatchStateManager(); // TODO : Each manager should be self sufficient, not initiated here
        Attributes = new AttributeProvider();
        Deck = new DeckManager();
        Characters = new CharacterManager();
    }

    public void DamageCharacter(Character target, int damage)
    {
        var characterDamaged = Characters.DamageCharacter(target, damage);
        
        EventManager.Notify(EventName.CharacterDamaged, characterDamaged);
    }
    
    public void HealCharacter(Character target, int heal)
    {
        var characterHealed = Characters.HealCharacter(target, heal);
        
        EventManager.Notify(EventName.CharacterHealed, characterHealed);
    }

    public void DrawCard(Card card = null)
    {
        var cardMoved = Deck.DrawCard(card);
        
        EventManager.Notify(EventName.CardDrawn, cardMoved);
    }

    public void DiscardCard(Card card)
    {
        var cardMoved = Deck.MoveCard(card, Zone.Discard);

        EventManager.Notify(EventName.CardDiscarded, cardMoved);
    }

    public void EndTurn()
    {
        var turnEnded = States.EndPlayerTurn();
        
        EventManager.Notify(EventName.TurnEnded, turnEnded);
    }
}
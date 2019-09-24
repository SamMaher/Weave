using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class HandView : UiView {

    private List<CardView> CardViews { get; set; } = new List<CardView>();
    
    // Animation Dummy Values
    private readonly Vector2 _originPosition = Vector2.zero;
    private readonly float _cardSpacing = 1.05f;
    private readonly float _handViewWidth = 1000f;
    private readonly float _cardViewWidth = 200f;

    public override void Update()
    {
        base.Update();
        
        if (CardViews == null || !CardViews.Any()) return;
        var cardsToAnimate = CardViews.Where(cardView => !cardView.IsCurrent());
        
        var cardsToAnimateCount = cardsToAnimate.Count();
        if (cardsToAnimateCount <= 0) return;
        
        var cardsSpacedWidth = _handViewWidth / cardsToAnimateCount;
        var cardsSpreadWidth = _cardViewWidth * _cardSpacing;
        var handSpacing = Mathf.Min(cardsSpacedWidth, cardsSpreadWidth);
        
        var handPosition = transform.position;
        var halfCardWidth = _cardViewWidth / 2;
        var leftmostCardOffset = (cardsToAnimateCount * handSpacing) / 2;
        var handXOffset = handPosition.x + halfCardWidth - leftmostCardOffset;
        
        for (var i = 0; i < cardsToAnimateCount; i++)
        {
            var cardView = CardViews[i];
            var cardSpacing = i * handSpacing;
            var cardXOffset = handXOffset + cardSpacing;
            var targetPosition = new Vector2(cardXOffset, handPosition.y);
            cardView.TargetPosition = targetPosition;
        }
    }

    public void AddHand()
    {
        var handManager = MatchController.Controller.HandManager;

        var currentHand = handManager.GetHand();

        foreach (var card in currentHand) AddCard(card);
    }

    public void AddCard(Card card)
    {
        var cardView = UiViewHandler.Handler.Instantiate<CardView, Card>("Card", card);
        
        CardViews.Insert(0, cardView);
    }

    public void RemoveCard(Card card)
    {
        var cardToRemove = CardViews.FirstOrDefault(cardView => cardView.EntityReference == card);
        
        CardViews.Remove(cardToRemove);
    }
}
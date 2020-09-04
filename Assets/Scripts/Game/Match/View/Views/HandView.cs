using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class HandView : UiView {

    private List<CardView> CardViews { get; set; } = new List<CardView>();

    public UiView DeckView;

    public override void OnEveryFrame()
    {
        //PositionCardsInHand();
    }

    public void PositionCardsInHand() // TODO: Refactor the logic relative to screen space not world units.
    {
        var cardCount = CardViews.Count;
        if (cardCount <= 0) return;

        const float cardViewsWidth = 1.5f;

        var maxHandSize = GameController.Controller.PlayerManager.MaxHandSize;
        var minCardOverlap = cardViewsWidth * 0.10f;
        var maxCardOverlap = cardViewsWidth * 0.60f;

        var cardsByMaxCards = (float)cardCount / maxHandSize;
        var overlapBetweenCards = Mathf.Lerp(minCardOverlap, maxCardOverlap, cardsByMaxCards);

        var spacePerCard = (cardViewsWidth - overlapBetweenCards);
        var handWidth = cardCount * spacePerCard;

        var currentHandPosition = transform.position;
        var halfHandWidth = (handWidth / 2);
        var halfSpaceForCard = (spacePerCard / 2);
        var firstCardXPosition = currentHandPosition.x - halfHandWidth + halfSpaceForCard;
        var firstCardYPosition = currentHandPosition.y;

        var angleIncrementPerCard = 5;
        var angleSpread = cardCount * angleIncrementPerCard;
        var initialCardAngle = (angleSpread / 2) - (angleIncrementPerCard / 2);

        const float cardPositioningSpeed = 8;
        
        for (var i = 0; i < cardCount; i++)
        {
            var card = CardViews[i];
            if (card.IsHeld) continue;

            var newCardXPosition = firstCardXPosition + (spacePerCard * i);
            var newCardTargetPosition = new Vector2(newCardXPosition, firstCardYPosition);

            card.SetTargetPosition(newCardTargetPosition, cardPositioningSpeed);

            var newZRotationAngle = initialCardAngle - (angleIncrementPerCard * i);
            card.SetTargetRotation(newZRotationAngle, 2);
        }
    }

    public void AddHand()
    {
        var handManager = MatchController.Controller.HandManager;

        var currentHand = handManager.GetHand();

        foreach (var card in currentHand) AddCard(card);

        PositionCardsInHand();
    }

    public void AddCard(Card card)
    {
        var currentDeckPosition = DeckView.transform.localPosition;
        var cardView = UiViewHandler.Handler.InstantiateEntityView<CardView, Card>("Card", card, currentDeckPosition, UiViewLayer.Foreground);
        
        CardViews.Insert(0, cardView);

        PositionCardsInHand();
    }

    public void RemoveCard(Card card)
    {
        var cardToRemove = CardViews.FirstOrDefault(cardView => cardView.EntityReference == card);
        
        CardViews.Remove(cardToRemove);

        PositionCardsInHand();
    }
}
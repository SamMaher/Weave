using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class HandView : UiView {

    private List<CardView> CardViews { get; set; } = new List<CardView>();

    public UiView DeckView;
    
    // Magic
    private readonly float CardSpacing = 1.05f;
    
    // Inspector
    public float HandViewWidth;
    public float CardViewWidth;

    public override void UpdateView()
    {
        // TODO
    }

    public void AddHand()
    {
        var handManager = MatchController.Controller.HandManager;

        var currentHand = handManager.GetHand();

        foreach (var card in currentHand) AddCard(card);
    }

    public void AddCard(Card card)
    {
        var currentDeckPosition = DeckView.transform.localPosition;
        var cardView = UiViewHandler.Handler.InstantiateEntityView<CardView, Card>("Card", card, currentDeckPosition, UiViewLayer.Foreground);
        
        CardViews.Insert(0, cardView);
    }

    public void RemoveCard(Card card)
    {
        var cardToRemove = CardViews.FirstOrDefault(cardView => cardView.EntityReference == card);
        
        CardViews.Remove(cardToRemove);
    }
}
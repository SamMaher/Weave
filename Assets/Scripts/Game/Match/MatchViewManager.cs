using System.Collections.Generic;

public class MatchViewManager {
    
    private FieldView FieldView { get; set; }
    private HandView HandView { get; set; }

    public MatchViewManager()
    {
        FieldView = UiViewHandler.Handler.InstantiateUiView<FieldView>("Field");
        HandView = UiViewHandler.Handler.InstantiateUiView<HandView>("Hand");

        StartListening();
    }

    public void StartListening()
    {
        EventHandler.StartListening(EventName.CardDrawn, DrawCard);
    }

    public void StopListening()
    {
        EventHandler.StopListening(EventName.CardDrawn, DrawCard);
    }
    
    private void DrawCard(object sender, EventData eventData)
    {
        var cardMoved = eventData as CardMoved;
        if (cardMoved == null) return;

        var card = cardMoved.Card;
        switch (card.Zone)
        {
            case CardZone.Hand:
                DrawCardToHand(card);
                break;
            default:
                break;
        }
    }

    private void DrawCardToHand(Card card)
    {
        HandView.AddCard(card);
    }
    
    public void MarkCharactersTargetable(List<Character> characters)
    {
        // TODO : Highlights given characters and lets them be targeted by the pointer
    }
}
using System.Collections.Generic;

public class MatchViewManager {
    
    private FieldView FieldView { get; set; }
    private HandView HandView { get; set; }

    public MatchViewManager()
    {
        FieldView = UiViewHandler.Handler.Instantiate<FieldView>("Field");
        HandView = UiViewHandler.Handler.Instantiate<HandView>("Hand");

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
        
        HandView.AddCard(cardMoved.Card);
    }
    
    public void MarkCharactersTargetable(List<Character> characters)
    {
        // TODO : Highlights given characters and lets them be targeted by the pointer
    }
}
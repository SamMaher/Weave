/// <summary>
/// 	Handles actions and generates event data
/// </summary>
public static class ActionManager {

	//When the player is not acting
	private static void Idle()
	{
		Reap();
		EventManager.Notify(EventName.Reaper, null);
		EventManager.Notify(EventName.Idle, null);
	}

	// Check to see if any characters have died (after damage taken etc.)
	private static void Reap() // TODO Check that reap is model related, not view
	{

	}

	//Draw a single card from the deck
	public static void DrawCard()
	{
		CardMovedEventData eventData = cardManager.DrawCard();
		EventManager.Notify(EventManager.CARD_DRAWN, eventData);
	}
}

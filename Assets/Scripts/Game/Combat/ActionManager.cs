/// <summary>
/// 	Handles actions and generates event data
/// </summary>
public static class ActionManager {

	private static void Idle()
	{
		Reap();
		EventManager.Notify(EventName.Reaper, null);
		EventManager.Notify(EventName.Idle, null);
	}

	private static void Reap()
	{
		
	}

	public static void DrawCard()
	{

	}
}

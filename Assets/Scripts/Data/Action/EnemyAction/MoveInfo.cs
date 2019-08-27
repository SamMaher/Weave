/// <summary>
/// // TODO : Rewrite all summaries...
/// </summary>
public class MoveInfo { // TODO : This could potentially be move down a folder if cards/the player uses them
	
    public bool Valid { get; set; }
    public Character Source { get; set; }
    public Character Target { get; set; }
}

public static class MoveInfoExtensions {

	public static ActionInfo GetActionInfo(this MoveInfo moveInfo, Action action)
	{
		return new ActionInfo
		{
			Action = action,
			Source = moveInfo.Source,
			Target = moveInfo.Target
		};
	}
}

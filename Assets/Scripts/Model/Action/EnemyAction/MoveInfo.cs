public class MoveInfo {
	
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
			Target = moveInfo.Target,
		};
	}
}

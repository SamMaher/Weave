/// <summary>
/// 	Handles combat states, turn order etc.
/// </summary>
public static class CombatStateManager {

	/// <summary>
	/// 	The current process of the state
	/// </summary>
	public enum Process 
	{
		Idle,
		Active,
		Paused,
		Done
	}

	/// <summary>
	/// 	Mutates the current state per command
	/// </summary>
	public enum Command 
	{
		Enter,
		Pause,
		Exit
	}
}

using System.Linq;

/// <summary>
/// 	Moves performed by AI based on their conditions
/// </summary>
public class EnemyMove {

	public Condition[] Conditions;
	public Action[] Actions;

	public MoveInfo GetMoveInfo(Character sourceCharacter)
	{
		var potentialTargets = GameManager.Game.Match.Characters.GetCharacters();
		var validTargets = Conditions.Aggregate(
			potentialTargets,
			(targets, condition) 
				=> condition.FilterTargets(targets)
		);
		
		var chosenTarget = validTargets != null && validTargets.Any()
			? validTargets.ChooseRandom()
			: null;
		
		var targetCondition = Conditions.OfType<Target>().SingleOrDefault();
		var moveIsValid = targetCondition == null || chosenTarget != null;

		var moveInfo = new MoveInfo
		{
			Valid = moveIsValid,
			Source = sourceCharacter,
			Target = chosenTarget
		};

		return moveInfo;
	}
	
	public void Invoke(MoveInfo moveInfo)
	{	
		foreach (var action in Actions)
		{
			var actionInfo = moveInfo.GetActionInfo(action);
			action.Invoke(actionInfo);
		}
	}
}

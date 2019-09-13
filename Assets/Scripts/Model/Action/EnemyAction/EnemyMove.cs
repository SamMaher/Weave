using System;
using System.Linq;
using UnityEngine;

public class EnemyMove {

	public Condition[] Conditions;
	public Action[] Actions;

	public MoveInfo GetMoveInfo(Character sourceCharacter)
	{
		var potentialTargets = MatchController.Controller.CharacterManager.GetCharacters();
		var validTargets = Conditions.Aggregate(
			potentialTargets,
			(targets, condition) 
				=> condition.FilterTargets(targets)
		);
		
		var chosenTarget = validTargets != null && validTargets.Any()
			? validTargets.SelectRandom()
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

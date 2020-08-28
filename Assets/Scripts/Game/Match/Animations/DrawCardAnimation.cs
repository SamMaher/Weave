using UnityEngine;

public class DrawCardAnimation : ViewAnimation {

	public readonly float moveSpeed = 1;
	private readonly Vector3 _origin;
	private readonly Vector3 _extent;
	private Vector3 _target;

	public DrawCardAnimation(Transform viewTransform)
	{
		ViewTransform = viewTransform;
		_origin = ViewTransform.position;
		_target = _extent = _origin + (Vector3.right * 5);
	}

	public override void Animate(float animationDelta)
	{
		var current = ViewTransform.position;
		var distance = _target - current;
		var magnitude = distance.sqrMagnitude;

		Vector3 movement;
		if (_target == _extent)
		{
			if (magnitude < 0.01f)
			{
				_target = _origin;
			}
			movement = Vector3.Lerp(current, _target, Time.deltaTime * moveSpeed);
		}
		else
		{
			if (magnitude < 0.01f)
			{
				ViewTransform.position = _origin;
				Completed = true;
			}
			movement = Vector3.Lerp(current, _target, Time.deltaTime * moveSpeed);
		}

		ViewTransform.position = movement;
	}
}

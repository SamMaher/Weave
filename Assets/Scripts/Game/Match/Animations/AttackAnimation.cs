using System.Collections;
using UnityEngine;

public class AttackAnimation : TimedViewAnimation {
    
    public AttackAnimation(Transform viewTransform, float timeToAnimate)
    {
        TimeToAnimate = timeToAnimate;
        ViewTransform = viewTransform;
    }

    protected override void AnimateView(float animationDelta)
    {
        var transformPosition = ViewTransform.position;
        var amountToShakeX = transformPosition.x + Mathf.Sin(Time.time * animationDelta) * 1f;
        var shakeFromPosition = new Vector3(amountToShakeX, transformPosition.y);
        ViewTransform.Translate(shakeFromPosition);
    }
}

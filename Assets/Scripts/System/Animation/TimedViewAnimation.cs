using System.Collections;
using UnityEngine;

public abstract class TimedViewAnimation : ViewAnimation {

    protected float TimeToAnimate { get; set; }
    private float CurrentAnimationTimer { get; set; }

    public override void Animate(float animationDelta)
    {
        AnimateView(animationDelta);
        CountAnimationTimer(animationDelta);
    }

    protected abstract void AnimateView(float animationDelta);

    private void CountAnimationTimer(float animationDelta)
    {
        CurrentAnimationTimer += animationDelta;
        if (CurrentAnimationTimer >= TimeToAnimate) Completed = true;
    }
}
using System.Collections.Generic;
using UnityEngine;

public class AnimationChannel: Queue<IQueueableAnimation> {

    public float AnimationSpeed { get; set; } = 1;
    private float _animationDelta => Time.deltaTime * AnimationSpeed;

    public void Animate()
    {
        if (this.Count <= 0) return;
        var current = this.Peek();
        current.Animate(_animationDelta);
        if (current.Completed) this.Dequeue();
    }
}
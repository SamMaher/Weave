using UnityEngine;

public class SpriteAnimation : IQueueableAnimation {
    
    private Animation Animation { get; }
    
    public bool Completed { get; set; }

    public SpriteAnimation(Animation animation)
    {
        Animation = animation;
    }
    
    public void Animate(float animationDelta)
    {
        throw new System.NotImplementedException();
    }
}
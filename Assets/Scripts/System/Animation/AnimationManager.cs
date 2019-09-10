using System.Collections.Generic;
using UnityEngine;

public class AnimationManager {

    private static Dictionary<AnimationChannelName, AnimationChannel> _channels;

    public void SetAnimationSpeed(AnimationChannelName channelName, float targetSpeed)
    {
        _channels[channelName].AnimationSpeed = targetSpeed;
    }
    
    public void QueueAnimation(AnimationChannelName channelName, IQueueableAnimation animation)
    {
        _channels[channelName].Enqueue(animation);
    }
}
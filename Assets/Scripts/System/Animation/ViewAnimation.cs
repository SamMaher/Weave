using System.Collections;
using UnityEngine;

public abstract class ViewAnimation : IQueueableAnimation {
    
    public bool Completed { get; set; }
    
    public Transform ViewTransform { get; set; } // TODO : Replace with a 'View' object

    public abstract void Animate(float animationDelta);
}
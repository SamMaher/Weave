using UnityEngine;

public class CoroutineHandler : MonoBehaviour {

    private static CoroutineHandler _coroutineHandler;
    public static CoroutineHandler Handler => _coroutineHandler;
    
    private void Awake()
    {
        if (_coroutineHandler != null && _coroutineHandler != this)
        {
            Destroy(this.gameObject);
        } else {
            _coroutineHandler = this;
        }
    }
}
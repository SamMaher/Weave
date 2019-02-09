using UnityEngine;

public class Test : MonoBehaviour {
    private void Start()
    {
        var cards = new Factory<Card>("cards").Load();

        foreach (var card in cards) Debug.Log(card.name);
    }
}
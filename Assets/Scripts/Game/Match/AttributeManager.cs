using System;
using UnityEngine;

public class AttributeManager {

    private readonly CharacterManager _characterManager;
    
    public AttributeManager()
    {
        _characterManager = MatchController.Controller.CharacterManager;
    }

    public int Value(string matchAttribute)
    {
        var matchAttributeEnum = (MatchAttribute) Enum.Parse(typeof(MatchAttribute), matchAttribute);
        return Value(matchAttributeEnum);
    }

    private int Value(MatchAttribute matchAttribute)
    {
        switch (matchAttribute)
        {
            case (MatchAttribute.PlayerHealth): return _characterManager.GetPlayer().Health;
            default: throw new AttributeNotImplementedException(matchAttribute.ToString());
        }
    }
}

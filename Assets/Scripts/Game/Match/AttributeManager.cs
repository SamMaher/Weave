using System;

/// <summary>
///     Provides match attributes
/// </summary>
public class AttributeManager {

    public int Value(string matchAttribute)
    {
        var matchAttributeEnum = (MatchAttribute) Enum.Parse(typeof(MatchAttribute), matchAttribute);
        return Value(matchAttributeEnum);
    }

    private int Value(MatchAttribute matchAttribute)
    {
        var characterManager = MatchController.Controller.CharacterManager;

        switch (matchAttribute)
        {
            case (MatchAttribute.PlayerHealth): return characterManager.GetPlayer().Health;
            default: throw new AttributeNotImplementedException(matchAttribute.ToString());
        }
    }
}

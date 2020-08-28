using System;

public static class AttributeHandler {

    public static int Value(string matchAttribute)
    {
        var matchAttributeEnum = (MatchAttribute) Enum.Parse(typeof(MatchAttribute), matchAttribute);
        return Value(matchAttributeEnum);
    }

    private static int Value(MatchAttribute matchAttribute)
    {
        switch (matchAttribute)
        {
            case (MatchAttribute.PlayerHealth): return GetPlayerHealth();
            default: throw new AttributeNotImplementedException(matchAttribute.ToString());
        }
    }

    private static int GetPlayerHealth()
    {
        return MatchController
            .Controller
            .CharacterManager
            .GetPlayer()
            .Health;
    }
}

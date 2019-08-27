using System;

/// <summary>
///     Provides match attributes
/// </summary>
public class AttributeProvider  {

    public int Value(string matchAttribute)
    {
        var matchAttributeEnum = (MatchAttribute) Enum.Parse(typeof(MatchAttribute), matchAttribute);
        return Value(matchAttributeEnum);
    }

    private int Value(MatchAttribute matchAttribute)
    {
        var characters = GameManager.Game.Match.Characters;

        switch (matchAttribute)
        {
            case (MatchAttribute.PlayerHealth): return characters.GetPlayer().Health;
            default: throw new NotImplementedException($"AttributeName {matchAttribute} is not supported");
        }
    }
}

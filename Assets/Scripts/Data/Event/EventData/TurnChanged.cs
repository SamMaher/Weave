/// <summary>
///     Describes the healing of a Character
/// </summary>
public class TurnChanged : StateChanged {

    public string FromTurnName { get; set; }
    public string ToTurnName { get; set; }

    public TurnChanged(string fromTurnName, string toTurnName) : base(fromTurnName, toTurnName) {}

    public static TurnChanged FromStateChanged(StateChanged stateChanged)
    {
        return new TurnChanged(stateChanged.FromState, stateChanged.ToState);
    }

    public override string ToString()
    {
        return $"Turn Changed From: {FromTurnName}, To: {ToTurnName}";
    }
}

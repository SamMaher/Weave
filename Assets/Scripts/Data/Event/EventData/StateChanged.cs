/// <summary>
///     Describes the healing of a Character
/// </summary>
public class StateChanged : EventData {

    public string FromState { get; set; }
    public string ToState { get; set; }

    public StateChanged(string fromState, string toState)
    {
        FromState = fromState;
        ToState = toState;
    }

    public override string ToString()
    {
        return $"State Changed From: {FromState}, To: {ToState}";
    }
}

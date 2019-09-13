public class StateChanged : EventData {

    public string FromStateName { get; set; }
    public string ToStateName { get; set; }

    public StateChanged(string fromStateName, string toStateName)
    {
        FromStateName = fromStateName;
        ToStateName = toStateName;
    }

    public override string ToString()
    {
        return $"State Changed From: {FromStateName}, To: {ToStateName}";
    }
}

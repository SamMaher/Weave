/// <summary>
///     Valid target for this action
/// </summary>
public class Target : Condition {
    public TargetType TargetType { get; set; }
    public int MinimumHealth { get; set; }
}
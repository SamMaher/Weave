/// <summary>
///     Conditions based on targetted cards
/// </summary>
public class Target : Condition {
    public TargetType targetType { get; set; }
    public int minimumHealth { get; set; }
}
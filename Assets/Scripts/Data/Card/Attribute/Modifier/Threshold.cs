/// <summary>
///     Modifies an attribute if a Value is within a range
/// </summary>
public class Threshold : Modifier {
    public int minimum { get; set; }
    public int maximum { get; set; }
}
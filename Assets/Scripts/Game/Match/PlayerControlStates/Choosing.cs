public class Choosing : IState, IPlayerControlState
{
    public static EntityView<Entity> InspectedView { get; set; }

    public void Enter() { }

    public bool IsRunning() => true;

    public IState Exit()
    {
        return null;
    }
}
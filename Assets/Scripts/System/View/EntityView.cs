public abstract class EntityView<T> : UiView where T : Entity {
    
    public T EntityReference { get; private set; }

    public void SetEntityReference(T entityReference)
    {
        EntityReference = entityReference;
        MatchViewToEntity();
    }
    
    public override void Update()
    {
        base.Update();
        
        MatchViewToEntity(); // TODO : This doesn't seem very performant, can be refactored to event system
    }

    public abstract void MatchViewToEntity();
}
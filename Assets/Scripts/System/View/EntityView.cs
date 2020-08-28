public abstract class EntityView<T> : UiView where T : Entity {
    
    public T EntityReference { get; private set; }

    public void SetEntityReference(T entityReference)
    {
        EntityReference = entityReference;

        UpdateView();
    }
}
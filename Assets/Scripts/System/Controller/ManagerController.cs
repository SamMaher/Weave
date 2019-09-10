public abstract class ManagerController {
    
    public void New()
    {
        End();
        AddManagers();
    }
    
    public void End()
    {
        RemoveManagers();
    }

    protected abstract void AddManagers();

    protected abstract void RemoveManagers();
}
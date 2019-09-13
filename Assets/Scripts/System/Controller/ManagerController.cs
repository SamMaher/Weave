public abstract class ManagerController {
    
    protected void New()
    {
        End();
        AddManagers();
    }
    
    protected void End()
    {
        RemoveManagers();
    }

    protected abstract void AddManagers();

    protected abstract void RemoveManagers();
}
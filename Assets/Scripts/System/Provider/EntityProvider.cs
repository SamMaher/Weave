using System.Collections.Generic;

public abstract class EntityProvider<T> where T: Entity {
    
    protected abstract bool Persist();
    
    protected abstract bool Create(T entity);
    
    protected abstract T Read(string identity);
    
    protected abstract bool Update(T entity);
    
    protected abstract bool Delete(string identity);
}
using System;
using System.Collections.Generic;
using System.Linq;

public abstract class JsonEntityProvider<T>: EntityProvider<T> where T : Entity {

    private static JsonFactory<T> JsonFactory;
    private static Dictionary<string, T> Store { get; set; }

    protected JsonEntityProvider()
    {
        // If store is not null, we don't have to instantiate the context
        if (Store != null) return;

        var dataFilePath = GetJsonDataFileName();
        if (dataFilePath == null) throw new DataFilePathNotProvidedException();
        
        JsonFactory = new JsonFactory<T>();
        Store = JsonFactory
            .Load(dataFilePath)
            .ToDictionary(entity => entity.ToIdentity());
    }

    protected abstract string GetJsonDataFileName();

    protected override bool Persist()
    {
        var entities = Store.Values.ToArray();
        Array.Sort(entities, Entity.Sort());
        JsonFactory.Save(GetJsonDataFileName(), entities);
        return false;
    }

    protected override bool Create(T entity)
    {
        var newEntityId = entity.ToIdentity();
        if (Store[newEntityId] != null) return false;
        Store.Add(entity.ToIdentity(), entity);
        return true;
    }

    protected override T Read(string identity)
    {
        return Store[identity];
    }

    protected override bool Update(T entity)
    {
        var oldEntity = Read(entity.ToIdentity());
        if (oldEntity == null) return false;
        Store[entity.ToIdentity()] = entity;
        return true;
    }

    protected override bool Delete(string identity)
    {
        var oldEntity = Read(identity);
        if (oldEntity == null) return false;
        Store.Remove(identity);
        return true;
    }
    
    protected T Clone(T entity)
    {
        return JsonFactory.Clone(entity);
    }

    protected T[] Clone(T[] entities)
    {
        return JsonFactory.Clone(entities);
    }

    protected string[] GetIdentities()
    {
        return Store.Select(entity => entity.Key).ToArray();
    }
}
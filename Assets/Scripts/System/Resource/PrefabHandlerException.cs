using System;
using UnityEditor;

public abstract class PrefabHandlerException : Exception {}

public class PrefabNotFoundException : PrefabHandlerException {

    private readonly string _prefabName;

    public PrefabNotFoundException(string prefabName)
    {
        _prefabName = prefabName;
    }
    
    public override string ToString()
    {
        return $"Prefab {_prefabName} not found, please add this reference!";
    }
}

public class PrefabDoesntHaveSpecifiedComponent : PrefabHandlerException {

    private readonly string _prefabName;

    public PrefabDoesntHaveSpecifiedComponent(string prefabName)
    {
        _prefabName = prefabName;
    }
    
    public override string ToString()
    {
        return $"Prefab {_prefabName} doesn't have the specified component!";
    }
}
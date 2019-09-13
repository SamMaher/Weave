using System;
using UnityEditor;

public abstract class IdentityTypeException : Exception {}

public class IdentityTypeNotSupportedException : IdentityTypeException {
        
    public override string ToString()
    {
        return $"Identity Type is not supported!";
    }
}

public class CannotComparePartialIdentityException : IdentityTypeException {
        
    public override string ToString()
    {
        return $"Comparing partial identity is not valid, as the Guid substring may not be unique.";
    }
}
    
public class DuplicateGuidException : IdentityTypeException {

    private readonly string _guid;

    public DuplicateGuidException(string guid)
    {
        _guid = guid;
    }
    
    public override string ToString()
    {
        return $"Two entities have the same Guid of {_guid}! Why tho?";
    }
}
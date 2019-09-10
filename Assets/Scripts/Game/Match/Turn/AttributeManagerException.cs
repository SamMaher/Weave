using System;

public abstract class AttributeManagerException : Exception {}

public class AttributeNotImplementedException : AttributeManagerException {

    private readonly string _attributeName;
    
    public AttributeNotImplementedException(string attributeName)
    {
        _attributeName = attributeName;
    }
        
    public override string ToString()
    {
        return $"Attribute {_attributeName} not implemented!";
    }
}
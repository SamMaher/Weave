using System;

public abstract class IdentityTypeException : Exception {}

public class IdentityTypeNotSupportedException : IdentityTypeException {
        
    public override string ToString() // TODO : Give all exceptions some meaning, pass in values to print
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
        
    public override string ToString()
    {
        return $"Two entities have the same Guid! Why tho?";
    }
}
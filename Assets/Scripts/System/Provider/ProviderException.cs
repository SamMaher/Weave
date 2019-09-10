using System;

public abstract class ProviderException : Exception {}

public class DataFilePathNotProvidedException : ProviderException {
        
    public override string ToString()
    {
        return $"File path not given!";
    }
}
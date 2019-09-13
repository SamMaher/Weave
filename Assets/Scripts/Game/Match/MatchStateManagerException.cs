using System;

public abstract class MatchStateManagerException : Exception {}

public class NotPlayerTurnException : MatchStateManagerException {
    
    public NotPlayerTurnException() {}
        
    public override string ToString()
    {
        return $"It's not the Players turn, can't end player turn!";
    }
}
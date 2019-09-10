using System;
using System.Collections;
using static System.String;

public class Entity : IComparable {

    private Guid _guid;

    public Guid Guid
    {
        get
        {
            if (_guid == Guid.Empty) _guid = new Guid();
            return _guid;
        }
    }
    public string Id { get; set; }
    public string Name { get; set; }

    public string ToIdentity(IdentityType identityType = IdentityType.Id)
    {
        switch (identityType)
        {
            case IdentityType.Id: return Id;
            case IdentityType.Name: return Name;
            case IdentityType.Guid: return Guid.ToString();
            case IdentityType.Basic: return $"{Id}:{Name}";
            case IdentityType.Partial: return $"{Guid.ToString().Substring(0, 3)}:{Id}:{Name}";
            case IdentityType.Full: return $"{Guid}:{Id}:{Name}";
            default: throw new IdentityTypeNotSupportedException();
        }
    }
    
    public int CompareTo(object objectToCompare)
    {
        var entityToCompare = objectToCompare as Entity;
        if (entityToCompare == null) return -1;

        var identity = ToIdentity();
        var toCompareIdentity = entityToCompare.ToIdentity();
        var comparison = Compare(identity, toCompareIdentity, StringComparison.Ordinal);
        
        return comparison;
    }
    
    public bool HasSameIdentity(Entity toCompare, IdentityType identityType = IdentityType.Id)
    {
        if (identityType == IdentityType.Partial) throw new CannotComparePartialIdentityException();
        
        var identity = ToIdentity(identityType);
        var toCompareIdentity = toCompare.ToIdentity(identityType);
        return (identity == toCompareIdentity);
    }

    public static IComparer Sort() => new SortByToCompare();
    
    private class SortByToCompare: IComparer
    {
        int IComparer.Compare(object entityA, object entityB)
        {
            var A = entityA as Entity;
            var B = entityB as Entity;

            return (A.CompareTo(B));
        }
    }
}
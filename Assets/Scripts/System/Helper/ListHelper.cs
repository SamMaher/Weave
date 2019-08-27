using System;
using System.Collections.Generic;

/// <summary>
///     Helper class for selecting a random list elements
/// </summary>
public static class ListHelper {

    private const int _seed = 1;
    private static Random _random;
    public static Random Random
    {
        get
        {
            if (_random == null) _random = new Random(_seed);
            return _random;
        }
        set { _random = value; }
    }
    
    public static void SetSeed(int seed)
    {
        Random = new Random(seed);
    }
    
    public static T ChooseRandom<T>(this List<T> list)
    {
        var setCount = list.Count;
        if (setCount <= 0) return default(T);
        var randomIndex = Random.Next(list.Count);
        return list[randomIndex];
    }
}
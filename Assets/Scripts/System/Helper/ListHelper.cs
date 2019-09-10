using System;
using System.Collections.Generic;

/// <summary>
///     Helper class for selecting a random list elements
/// </summary>
public static class ListHelper {

    private const int _seed = 1;
    private static Random _random;
    private static Random Random
    {
        get
        {
            if (_random != null) return _random;
            _random = new Random(_seed);
            return _random;
        }
    }
    
    public static void SetSeed(int seed)
    {
        _random = new Random(seed);
    }
    
    public static T SelectRandom<T>(this List<T> list)
    {
        var setCount = list.Count;
        if (setCount <= 0) return default(T);
        var randomIndex = Random.Next(list.Count);
        return list[randomIndex];
    }

    public static void Shuffle<T>(this List<T> list)
    {
        var r = new Random();

        for (int i = 0, c = list.Count; i < c; i++)
        {
            var n = i + (int) (r.NextDouble() * (c - i));
            var item1 = list[n];
            list[n] = list[i];
            list[i] = item1;
        }
    }
}
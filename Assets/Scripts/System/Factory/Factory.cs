using System;
using System.Linq;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using UnityEngine;

/// <summary>
///     Generates objects from JSON input
/// </summary>
public class Factory<T> where T : IProduct {
    private readonly JsonSerializerSettings Settings;

    public Factory()
    {
        Settings = new JsonSerializerSettings
        {
            TypeNameHandling = TypeNameHandling.Auto,
            Binder = new TypeBinder(typeof(T))
        };
    }

    public T[] Load(string fileName)
    {
        var filePath = "Data/" + fileName;
        var textAsset = Resources.Load<TextAsset>(filePath);
        var json = textAsset.text;

        var data = JsonConvert.DeserializeObject<T[]>(json, Settings);
        Resources.UnloadAsset(textAsset);

        return data;
    }

    public T Clone(T source)
    {
        return Clone(new[] {source})[0];
    }

    public T[] Clone(T[] source)
    {
        var json = JsonConvert.SerializeObject(source, Settings);
        return JsonConvert.DeserializeObject<T[]>(json, Settings);
    }

    private class TypeBinder : SerializationBinder {
        private readonly Type[] AssemblyTypes;

        public TypeBinder(Type T)
        {
            AssemblyTypes = typeof(T).Assembly.GetTypes();
        }

        public override Type BindToType(string assemblyName, string typeName)
        {
            return AssemblyTypes.SingleOrDefault(t => t.Name == typeName);
        }
    }
}
using System;
using System.Linq;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using UnityEngine;

/// <summary>
///     Generates IProduct Objects from JSON input
/// </summary>
public class Factory<T> where T : IProduct {
    private readonly string FilePath;

    public Factory(string fileName)
    {
        FilePath = "Data/" + fileName;
    }

    public T[] Load()
    {
        var settings = new JsonSerializerSettings
        {
            TypeNameHandling = TypeNameHandling.Auto,
            Binder = new TypeBinder(typeof(T))
        };

        var textAsset = Resources.Load<TextAsset>(FilePath);
        var json = textAsset.text;
        var data = JsonConvert.DeserializeObject<T[]>(json, settings);
        Resources.UnloadAsset(textAsset);

        return data;
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
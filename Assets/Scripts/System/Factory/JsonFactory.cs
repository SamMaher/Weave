using System;
using System.Linq;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using UnityEngine;

/// <summary>
///     Generates objects From JSON input
/// </summary>
public class JsonFactory<T> where T : Entity {
    
    private readonly JsonSerializerSettings _settings;

    public JsonFactory()
    {
        _settings = new JsonSerializerSettings
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

        var data = JsonConvert.DeserializeObject<T[]>(json, _settings);
        Resources.UnloadAsset(textAsset);

        return data;
    }

    public bool Save(string fileName, Entity[] products)
    {
        // TODO : Implement saving back to the JSON file
        throw new NotImplementedException();
    }

    public T Clone(T source)
    {
        return Clone(new[] {source})[0];
    }

    public T[] Clone(T[] source)
    {
        var json = JsonConvert.SerializeObject(source, _settings);
        return JsonConvert.DeserializeObject<T[]>(json, _settings);
    }

    private class TypeBinder : SerializationBinder {
        
        private readonly Type[] _assemblyTypes;

        public TypeBinder(Type T)
        {
            _assemblyTypes = typeof(T).Assembly.GetTypes();
        }

        public override Type BindToType(string assemblyName, string typeName)
        {
            return _assemblyTypes.SingleOrDefault(t => t.Name == typeName);
        }
    }
}
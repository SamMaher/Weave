using System.Collections.Generic;
using UnityEngine;
using Handler = System.Action<object, EventData>;

public static class EventHandler {
    
    private static readonly Dictionary<EventName, Handler> Events = new Dictionary<EventName, Handler>();

    public static void StartListening(EventName eventName, Handler sender)
    {
        if (!Events.ContainsKey(eventName))
        {
            Events.Add(eventName, sender);
        }
        else
        {
            Events[eventName] += sender;
        }
    }

    public static void StopListening(EventName eventName, Handler sender)
    {
        Events[eventName] -= sender;
    }

    public static void Notify(EventName eventName, EventData eventData)
    {
        Debug.Log($"EVENT: {eventName} - {eventData}"); // TODO : Build a logging system that stores event info
        if (!Events.ContainsKey(eventName)) return;
        Events[eventName](null, eventData);
    }
}
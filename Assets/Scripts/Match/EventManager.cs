using System.Collections.Generic;
using UnityEngine;
using Handler = System.Action<object, EventData>;

/// <summary>
///     Manages all events for a Match
/// </summary>
public static class EventManager {
    private static readonly Dictionary<EventName, Handler> events = new Dictionary<EventName, Handler>();

    public static void StartListening(EventName eventName, Handler sender)
    {
        if (!events.ContainsKey(eventName))
        {
            events.Add(eventName, sender);
        }
        else
        {
            events[eventName] += sender;
        }
    }

    public static void StopListening(EventName eventName, Handler sender)
    {
        events[eventName] -= sender;
    }

    public static void Notify(EventName eventName, EventData eventData)
    {
        if (events.ContainsKey(eventName))
        {
            events[eventName](null, eventData);
            if (eventData != null) Debug.Log($"EVENT: {eventName} - {eventData}");
        }
    }
}
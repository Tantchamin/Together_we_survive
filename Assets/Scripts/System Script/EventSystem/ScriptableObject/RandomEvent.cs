using UnityEngine;

public abstract class RandomEvent : ScriptableObject 
{
    public string eventName;
    [TextArea (4,4)]
    public string eventDescription;
    public EventType eventType;

    public enum EventType
    {
        MinorEvent , 
        MajorEvent
    }

}

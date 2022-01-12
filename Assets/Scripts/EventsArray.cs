using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EventsArray : MonoBehaviour
{
    [SerializeField] private UnityEvent[] Event;

    public void StartEvent(int eventIndex)
    {
        Event[eventIndex].Invoke();
    }
}

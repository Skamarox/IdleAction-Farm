using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections.Generic;

public class UI
{
    private static GraphicRaycaster raycaster;
    private static GraphicRaycaster Raycaster
    {
        get
        {
            if (raycaster == null)
                raycaster = Object.FindObjectOfType<GraphicRaycaster>();
            return raycaster;
        }
    }
    private static EventSystem _eventSystem;
    private static EventSystem _EventSystem
    {
        get 
        {
            if(_eventSystem == null)
                _eventSystem = Object.FindObjectOfType<EventSystem>();
            return _eventSystem;
        }
    }
    private static PointerEventData eventData;
    private static PointerEventData EventData
    {
        get
        {
            if (eventData == null)
                eventData = new PointerEventData(_EventSystem);
            return eventData;
        }
    }

    public static bool IsUI()
    {

        EventData.position = Input.mousePosition;

        List<RaycastResult> results = new List<RaycastResult>();

        Raycaster.Raycast(EventData, results);

        if (results.Count == 0)
            return false;
        return true;
    }
}

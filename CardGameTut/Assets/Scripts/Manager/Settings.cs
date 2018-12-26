using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


public static class Settings
{
    public static GameManager gameManager;
    private static ResourcesManager resourcesManager;

    public static ResourcesManager GetResourcesManager()
    {
        if(resourcesManager == null)
        {
            resourcesManager = Resources.Load("ResourcesManager") as ResourcesManager;
        }
        return resourcesManager;
    }


    public static List<RaycastResult> GetUIObjs()
    {
        PointerEventData pointerData = new PointerEventData(EventSystem.current)
        {
            position = Input.mousePosition,
        };

        List<RaycastResult> results = new List<RaycastResult>();
        EventSystem.current.RaycastAll(pointerData, results);

        return results;
    }
}

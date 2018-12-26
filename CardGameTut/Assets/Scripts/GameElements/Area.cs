using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Area : MonoBehaviour
{

    public AreaLogic areaLogic;

    public void OnDrop()
    {
        areaLogic.Execute();
    }
}

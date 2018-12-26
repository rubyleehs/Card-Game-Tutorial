using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

[CreateAssetMenu(menuName = "Actions/OnMouseLeftClick")]
public class OnMouseLeftClick: Action
{
    public override void Execute(float dt)
    {
        if (!Input.GetMouseButtonDown(0)) return;
        List<RaycastResult> results = Settings.GetUIObjs();

        IClickable c = null;

        for (int r = 0; r < results.Count; r++)
        {
            c = results[r].gameObject.GetComponentInParent<IClickable>();
            if (c != null)
            {
                c.OnMouseLeftClick();
                break;
            }
        }

    }
}
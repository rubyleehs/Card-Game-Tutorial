using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

[CreateAssetMenu(menuName = "Actions/OnMouseHover")]
public class OnMouseHover : Action {

	public override void Execute(float dt)
    {

        List<RaycastResult> results = Settings.GetUIObjs();

        IClickable c = null;

        for (int r = 0; r < results.Count; r++)
        {
            c = results[r].gameObject.GetComponentInParent<IClickable>();
            if(c != null)
            {
                c.OnMouseHover();
                break;
            }
        }
    }
}

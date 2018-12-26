using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Game Elements/My Card Down")]
public class MyCardDown : GameElementLogic
{

    public override void OnMouseLeftClick(CardInstance inst)
    {
        Debug.Log("This is my card, on the table");
    }

    public override void OnMouseHover(CardInstance inst)
    {
        Debug.Log(inst.gameObject.name);
    }
}

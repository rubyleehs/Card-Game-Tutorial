using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class GameElementLogic : ScriptableObject
{
    public abstract void OnMouseLeftClick(CardInstance inst);
    public abstract void OnMouseHover(CardInstance inst);

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardInstance : MonoBehaviour, IClickable
{
    public CardViz viz;
    public GameElementLogic currentLogic;

    private void Start()
    {
        viz = GetComponent<CardViz>();
    }

    public void OnMouseLeftClick()
    {
        if (currentLogic == null) return;
        currentLogic.OnMouseLeftClick(this);
    }

    public void OnMouseHover()
    {
        if (currentLogic == null) return;
        currentLogic.OnMouseHover(this);
    }

}

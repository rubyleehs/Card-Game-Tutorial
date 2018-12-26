using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Game Elements/My Hand Cards")]
public class HandCards : GameElementLogic
{
    public SO.GameEvent onCurrentCardSelected;
    public GameState holdingCard;
    public CardVariable currentCard;

    public override void OnMouseLeftClick(CardInstance inst)
    {
        Debug.Log("This is my hand card");
        currentCard.Set(inst);
        Settings.gameManager.SetState(holdingCard);
        onCurrentCardSelected.Raise();
    }

    public override void OnMouseHover(CardInstance inst)
    {
        Debug.Log(inst.gameObject.name);
    }
}

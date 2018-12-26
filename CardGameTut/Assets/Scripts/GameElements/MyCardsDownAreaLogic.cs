using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Areas/MyCardsDownWhenHoldingCard")]
public class MyCardsDownAreaLogic : AreaLogic
{
    public CardVariable card;
    public CardType creatureType;
    public SO.TransformVariable areaGrid;
    public GameElementLogic cardDownLogic;

    public override void Execute()
    {
        if (card.value == null) return;

        if (card.value.viz.card.cardType == creatureType)
        {
            //PlaceCardDown
            Vector3 scale = card.value.transform.localScale;
            card.value.transform.SetParent(areaGrid.value.transform);
            card.value.transform.localPosition = Vector3.zero;
            card.value.transform.localRotation = Quaternion.identity;
            card.value.transform.localScale = scale;
            card.value.currentLogic = cardDownLogic;
        }
    }

}

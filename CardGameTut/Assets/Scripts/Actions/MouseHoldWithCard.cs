using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


[CreateAssetMenu(menuName = "Actions/OnMouseHoldWithCard")]
public class MouseHoldWithCard : Action {


    public CardVariable currentCard;
    public GameState playerControlState;
    public SO.GameEvent onPlayerControlState;


    public override void Execute(float dt) 
    { 
        bool mouseIsDown = Input.GetMouseButton(0);
        if (!mouseIsDown)
        {
            List<RaycastResult> results = Settings.GetUIObjs();

            //bool isDroppedOnArea = false;

            for (int i = 0; i < results.Count; i++)
            {
                Area a = results[i].gameObject.GetComponentInParent<Area>();
                if(a != null)
                {
                    //isDroppedOnArea = true;
                    a.OnDrop();
                    break;
                }
            }

            currentCard.value.gameObject.SetActive(true);
            currentCard.value = null;
            Debug.Log("Drop Card");
            Settings.gameManager.SetState(playerControlState);
            onPlayerControlState.Raise();
            return;
        }
    }

}

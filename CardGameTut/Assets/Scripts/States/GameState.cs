using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (menuName = "GameState")]
public class GameState : ScriptableObject
{
    public Action[] actions;

    public void Tick(float dt)
    {
        for (int i = 0; i < actions.Length; i++)
        {
            actions[i].Execute(dt);
        }
    }
}

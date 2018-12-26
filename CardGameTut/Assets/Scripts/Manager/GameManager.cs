using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameState currentGameState;

    private void Start()
    {
        Settings.gameManager = this;
    }

    private void Update()
    {
        currentGameState.Tick(Time.deltaTime);
    }

    public void SetState(GameState state)
    {
        currentGameState = state;
    }
}

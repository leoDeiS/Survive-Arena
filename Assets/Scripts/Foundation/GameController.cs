using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoSingleton<GameController>
{

    public event Action OnLevelStarted;
    public event Action<bool> OnLevelEnd;

    private void Start()
    {
        ResumeGame();
    }


    public void PauseGame()
    {
        Cursor.visible = true;
        Time.timeScale = 0;
    }

    public void ResumeGame()
    {
        Cursor.visible = false;
        Time.timeScale = 1;
    }

    public void OpenMainMenu()
    {

    }

    public void EndLevel(bool isWin)
    {
        OnLevelEnd?.Invoke(isWin);
    }
}

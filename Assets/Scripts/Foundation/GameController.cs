using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoSingleton<GameController>
{

    public event Action OnLevelStarted;
    public event Action<bool> OnLevelEnd;


    public void EndLevel(bool isWin)
    {
        OnLevelEnd?.Invoke(isWin);
    }
}

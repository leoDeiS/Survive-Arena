using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuUI : BaseUIBehaviour
{
    [SerializeField] private Button _startButton;
    [SerializeField] private Button _exitButton;

    private void Start()
    {
        _startButton.onClick.AddListener(StartGame);
        _exitButton.onClick.AddListener(Exit);
    }

    private void StartGame()
    {

    }

    private void Exit()
    {
        Application.Quit();
    }
}

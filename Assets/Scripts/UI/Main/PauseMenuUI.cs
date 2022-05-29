using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseMenuUI : BaseUIBehaviour
{
    [SerializeField] private Button _resumeButton;
    [SerializeField] private Button _exitButton;

    private void Start()
    {
        _resumeButton.onClick.AddListener(Resume);
        _exitButton.onClick.AddListener(Exit);
    }

    private void Resume()
    {
        GameController.Instance.ResumeGame();
    }

    private void Exit()
    {
        GameController.Instance.OpenMainMenu();
    }
}

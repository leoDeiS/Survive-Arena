using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameUI : BaseUIBehaviour
{
    [SerializeField] private WeaponUI _weaponUI;
    [SerializeField] private PauseMenuUI _pauseMenu;
    [SerializeField] private PlayerHealthUI _playerHealthUI;


    private bool _pauseMenuOpened;

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            _pauseMenuOpened = !_pauseMenuOpened;
            DisplayPauseMenu(_pauseMenuOpened);
        }
    }

    private void OnPause()
    {
        _weaponUI.Hide();
        _playerHealthUI.Hide();
    }

    private void OnResume()
    {
        _weaponUI.Show();
        _playerHealthUI.Show();
    }

    private void DisplayPauseMenu(bool display)
    {
        if(display)
        {
            GameController.Instance.PauseGame();
            _pauseMenu.Show();
            OnPause();
        }
        else
        {
            GameController.Instance.ResumeGame();
            _pauseMenu.Hide();
            OnResume();
        }
    }
}

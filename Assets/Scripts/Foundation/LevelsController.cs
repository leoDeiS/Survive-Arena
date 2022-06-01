using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelsController : MonoSingleton<LevelsController>
{
    [SerializeField] private GameObject _loadScreen;

    public event Action OnSceneStartedLoading;
    public event Action OnSceneLoaded;

   public void LoadBattleScene()
    {
        StartCoroutine(LoadSceneAsynchrously(1));
    }

    public void LoadMainMenu()
    {
        StartCoroutine(LoadSceneAsynchrously(0));
    }

    public void PreLoadScene()
    {
        StartCoroutine(PreLoading());
    }

    private IEnumerator PreLoading()
    {
        _loadScreen.SetActive(true);
        OnSceneStartedLoading?.Invoke();
        yield return new WaitForSeconds(4f);
        _loadScreen.SetActive(false);
        OnSceneLoaded?.Invoke();
    }

    private IEnumerator LoadSceneAsynchrously(int sceneIndex)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneIndex);
        _loadScreen.SetActive(true);
        OnSceneStartedLoading?.Invoke();
        while(!operation.isDone)
        {
            yield return null;
        }

        yield return new WaitForSeconds(3f);
        _loadScreen.SetActive(false);
        OnSceneLoaded?.Invoke();
    }
}

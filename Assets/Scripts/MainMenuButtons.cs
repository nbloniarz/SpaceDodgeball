using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class MainMenuButtons : MonoBehaviour {

    private bool startLoad = false;
    private string mainGameScene = "";
    public GameObject loadingIndicator;
    public GameObject settingsUI;

    public void startLoadGame(string sceneName) {
        mainGameScene = sceneName;
        startLoad = true;
        loadingIndicator.SetActive(true);
    }

    private void Update() {
        if (startLoad) {
            StartCoroutine(loadMainGame());
            startLoad = false;
        }
    }

    private IEnumerator loadMainGame() {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(mainGameScene);

        while (!asyncLoad.isDone) {
            yield return null;
        }
    }

    public void showSettings() {
        settingsUI.SetActive(true);
    }

    public void hideSettings() {
        settingsUI.SetActive(false);
    }
}

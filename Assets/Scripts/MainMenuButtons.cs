using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuButtons : MonoBehaviour {

    private bool startLoad = false;
    private string mainGameScene = "";
    public GameObject loadingIndicator;
    public GameObject settingsUI;
	public GameObject numberOfPlayers;

	private void Awake() {
		numberOfPlayers = GameObject.FindWithTag("Player Count");
		numberOfPlayers.GetComponent<Text>().text = GameManagerController.numberOfPlayers.ToString();
	}

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

	public void IncreasePlayerCount() {
		if(GameManagerController.numberOfPlayers < GameManagerController.maxPlayers) {
			GameManagerController.numberOfPlayers += 1;
			numberOfPlayers.GetComponent<Text>().text = GameManagerController.numberOfPlayers.ToString();
		}
	}

	public void DecreasePlayerCount() {
		if (GameManagerController.numberOfPlayers > 1) {
			GameManagerController.numberOfPlayers -= 1;
			numberOfPlayers.GetComponent<Text>().text = GameManagerController.numberOfPlayers.ToString();
		}
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class GameMenu : MonoBehaviour {

    public GameObject pauseMenu;
    private bool pauseVisible;
    public string mainMenuSceneName;

	// Use this for initialization
	void Start () {
        pauseVisible = false;
	}
	
	// Update is called once per frame
	void Update () {
        if(pauseVisible == false && Input.GetButton("pauseButton")){
            showPauseMenu();
        }
        if (pauseVisible == true && Input.GetButton("pauseButton")) {
            showPauseMenu();
        }
    }

    public void showPauseMenu() {
        pauseMenu.SetActive(true);
        pauseVisible = true;
        Time.timeScale = 0f;
    }

    public void hidePauseMenu() {
        pauseMenu.SetActive(false);
        pauseVisible = false;
        Time.timeScale = 1f;
    }

    public void exitToMainMenu() { 
        Time.timeScale = 0f;
        SceneManager.LoadScene(mainMenuSceneName);
    }
}

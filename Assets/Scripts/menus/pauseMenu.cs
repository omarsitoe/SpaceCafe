using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class pauseMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;
    [SerializeField] public GameObject pauseMenuUI;

    void Start() {
        GameIsPaused = false;
        pauseMenuUI.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        // Checks if the escape key has been pressed
       if(Input.GetKeyDown(KeyCode.Escape)) {
            //if game was already paused, resume. Vice versa
            if(GameIsPaused) {
                Resume();
            }
            else {
                Pause();
            }
        }
    }

    //resumes the game
    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }

    //pauses the game
    void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    //brings us to the menu scene
    public void LoadMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
    }

    //quits the game
    public void QuitGame()
    {
        Debug.Log("Quitting...");
        Application.Quit();
    }

    //reloads the scene
    public void Restart()
    {
        SceneManager.LoadScene("MainLevel");
        Time.timeScale = 1f;
    }
}

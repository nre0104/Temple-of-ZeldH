using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPause : MonoBehaviour
{
    public static bool GameisPaused = false;
    public GameObject pauseMenuUI;
    public string sceneStr;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if(GameisPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameisPaused = true;
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameisPaused = false;
    }

    public void QuitGame()
    {
        Debug.Log("You have quit the game");
        if (UnityEditor.EditorApplication.isPlaying == true)
        {
            UnityEditor.EditorApplication.isPlaying = false;
        }
        else
        {
            Application.Quit();
        }
    }

    public void LoadMenu()
    {
        Debug.Log("LoadMenu");
        Time.timeScale = 1f;
        SceneManager.LoadScene(sceneStr, LoadSceneMode.Single);
    }


    public void Restart()
    {
        Debug.Log("Restart Current Level");
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }


}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPause : MonoBehaviour
{
    public static bool GameisPaused = false;
    public GameObject pauseMenuUI;
    public string sceneStr;
    static MenuPause _instance;

    public static MenuPause Instance
    {
        get
        {
            if (_instance == null)
            {
                GameObject go = new GameObject();
                _instance = go.AddComponent<MenuPause>();
            }
            return _instance;
        }
    }

    void Start()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = false;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Cursor.visible = true;

            if (GameisPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
        else
        {
            Cursor.visible = false;
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

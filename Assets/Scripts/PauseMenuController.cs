using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Scripts
{
    public class PauseMenuController : MonoBehaviour
    {
        public static bool GameisPaused = false;
        public GameObject pauseMenuUI;
        public string mainMenuScene;
        static PauseMenuController _instance;

        public static PauseMenuController Instance
        {
            get
            {
                if (_instance == null)
                {
                    GameObject go = new GameObject();
                    _instance = go.AddComponent<PauseMenuController>();
                }
                return _instance;
            }
        }

        void Start()
        {
            //Cursor.lockState = CursorLockMode.None;
            //Cursor.visible = false;
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                Cursor.visible = true;

                if (GameisPaused)
                {
                    Resume(); 
                    Cursor.lockState = CursorLockMode.Locked;
                    //Cursor.visible = false;
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
            SceneManager.LoadScene(mainMenuScene, LoadSceneMode.Single);
        }


        public void Restart()
        {
            Debug.Log("Restart Current Level");
            Time.timeScale = 1f;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }


    }
}

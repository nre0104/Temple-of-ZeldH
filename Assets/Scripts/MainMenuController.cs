using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

namespace Assets.Scripts
{
    public class MainMenuController : MonoBehaviour, IPointerEnterHandler
    {
        public bool playHoverSound;
        public AudioClip hoverSound;

        public string sceneName;

        void Start()
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }

        public void OnPointerEnter(PointerEventData eventdata)
        {
            if (playHoverSound)
            {
                AudioSource buttonAudioSource = GetComponent<AudioSource>();
                buttonAudioSource.clip = hoverSound;
                buttonAudioSource.Play();
            }
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

        public void StartGame()
        {
            SceneManager.LoadScene(sceneName, LoadSceneMode.Single);
        }
    }
}

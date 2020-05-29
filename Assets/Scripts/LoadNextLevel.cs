using System;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Scripts
{
    public class LoadNextLevel : MonoBehaviour
    {
        public String nextLevel;
        public Canvas youWinCanvas;
   
        void OnTriggerEnter(Collider col)
        {
            if (col.transform.gameObject.CompareTag("Player") && 
                SceneManager.GetActiveScene().name == "SampleScene_Level1")
            {
                SceneManager.LoadScene(nextLevel, LoadSceneMode.Single);
            }
            else if(col.transform.gameObject.CompareTag("Player") &&
                    SceneManager.GetActiveScene().name == "SampleScene_Level2")
            {
                HealthController health = col.GetComponent<HealthController>();

                Instantiate(youWinCanvas);
                Debug.Log("Player Win");

                Invoke("LoadMenu", 1f);
            }

        }

        void LoadMenu()
        {
            PauseMenuController.Instance.mainMenuScene = "StartGameMenu";
            PauseMenuController.Instance.LoadMenu();
        }
    }
}

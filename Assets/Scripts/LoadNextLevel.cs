using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadNextLevel : MonoBehaviour
{
   
    void OnTriggerEnter(Collider col)
    {
        if (col.transform.gameObject.name.Contains("Player") && 
          SceneManager.GetActiveScene().buildIndex == 2)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
        else if(col.transform.gameObject.name.Contains("Player") &&
          SceneManager.GetActiveScene().buildIndex == 3)
        {
            MenuPause.Instance.sceneStr = "StartGameMenu";
            MenuPause.Instance.LoadMenu();
        }

    }
}

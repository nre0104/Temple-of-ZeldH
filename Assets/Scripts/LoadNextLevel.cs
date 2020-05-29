﻿using System;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Scripts
{
    public class LoadNextLevel : MonoBehaviour
    {
        public String nextLevel;
   
        void OnTriggerEnter(Collider col)
        {
            if (col.transform.gameObject.CompareTag("Player") && 
                SceneManager.GetActiveScene().buildIndex == 2)
            {
                SceneManager.LoadScene(nextLevel, LoadSceneMode.Single);
            }
            else if(col.transform.gameObject.CompareTag("Player") &&
                    SceneManager.GetActiveScene().buildIndex == 3)
            {
                PauseMenuController.Instance.mainMenuScene = "StartGameMenu";
                PauseMenuController.Instance.LoadMenu();
            }

        }
    }
}

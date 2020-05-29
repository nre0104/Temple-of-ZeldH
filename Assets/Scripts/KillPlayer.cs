﻿using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillPlayer : MonoBehaviour
{

    void OnTriggerEnter(Collider col)
    {
        if (col.transform.gameObject.CompareTag("Player"))
        {
            HealthController health = col.GetComponent<HealthController>();

            Debug.Log("Kill player");

            PauseMenuController.Instance.mainMenuScene = "StartGameMenu";
            PauseMenuController.Instance.LoadMenu();
        }
    }
}

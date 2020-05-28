using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillPlayer : MonoBehaviour
{

    void OnTriggerEnter(Collider col)
    {
        if (col.transform.gameObject.name.Contains("Player 2"))
        {
            Debug.Log("Kill player");
            col.transform.gameObject.GetComponent<TargetController>().Die();

            PauseMenuController.Instance.mainMenuScene = "StartGameMenu";
            PauseMenuController.Instance.LoadMenu();
        }
    }
}

using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillPlayer : MonoBehaviour
{
    public GameObject youDiedCanvas;

    void OnTriggerEnter(Collider col)
    {
        if (col.transform.gameObject.CompareTag("Player"))
        {
            HealthController health = col.GetComponent<HealthController>();

            Instantiate(youDiedCanvas);
            Debug.Log("Kill player");

            Invoke("LoadMenu", 3f);
        }
    }

    void LoadMenu()
    {
        PauseMenuController.Instance.mainMenuScene = "StartGameMenu";
        PauseMenuController.Instance.LoadMenu();
    }
}

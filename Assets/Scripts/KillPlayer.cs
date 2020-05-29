using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillPlayer : MonoBehaviour
{
    public GameObject youDiedCanvas;
    public GameObject pauseCanvas;

    void OnTriggerEnter(Collider col)
    {
        if (col.transform.gameObject.CompareTag("Player"))
        {
            pauseCanvas.SetActive(false);

            HealthController health = col.GetComponent<HealthController>();

            Instantiate(youDiedCanvas);
            Debug.Log("Kill player");

            Invoke("LoadMenu", 1f);
        }
    }

    void LoadMenu()
    {
        PauseMenuController.Instance.mainMenuScene = "StartGameMenu";
        PauseMenuController.Instance.LoadMenu();
    }
}

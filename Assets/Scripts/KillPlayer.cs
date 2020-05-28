using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillPlayer : MonoBehaviour
{

    void OnTriggerEnter(Collider col)
    {
        if (col.transform.gameObject.name.Contains("Player"))
        {
            Debug.Log("Kill player");
            col.transform.gameObject.GetComponent<TargetController>().Die();

            MenuPause.Instance.sceneStr = "StartGameMenu";
            MenuPause.Instance.LoadMenu();
        }
    }
}

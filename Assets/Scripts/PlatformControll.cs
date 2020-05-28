using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformControll : MonoBehaviour
{
    public GameObject player;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject == player) {
            other.transform.parent = transform;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        player.transform.parent = null;
    }
}

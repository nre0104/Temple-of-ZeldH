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
            Debug.Log(other.transform.parent);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == player)
        {
            player.transform.parent = null;
            Debug.Log(other.transform.parent + " hoffentlich null");
        }
    }
}

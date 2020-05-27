﻿using UnityEngine;

namespace Assets.Scripts
{
    public class InteractableBehaviour : MonoBehaviour
    {

        void OnTriggerEnter(Collider other)
        {
            Debug.Log("Trigger");
            gameObject.GetComponent<Collider>().isTrigger = false;
            gameObject.GetComponent<Rigidbody>().isKinematic = false;
        }

        void OnTriggerExit(Collider other)
        {
            Debug.Log("Trigger");
            gameObject.GetComponent<Collider>().isTrigger = true;
            gameObject.GetComponent<Rigidbody>().isKinematic = true;
        }
    }
}

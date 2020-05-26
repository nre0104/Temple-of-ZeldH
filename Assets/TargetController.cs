using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetController : MonoBehaviour
{

    public float Health;
    

    void Start()
    {
        
    }


    private void OnCollisionEnter(Collision collision)
    {
        if(collision.transform.tag == "Arrow" || collision.transform.tag == "Sword")
        {
            Health--;
            if (Health < 1) {
                Destroy(gameObject);
            }
        }
    }
}

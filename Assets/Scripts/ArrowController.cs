using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowController : MonoBehaviour
{
    Rigidbody myBody;
    private float lifeTimer = 3f;
    private float timer;

    void Start()
    {
        myBody = GetComponent<Rigidbody>();
    }

    void Update()
    {
        timer += Time.deltaTime;
        if(timer>= lifeTimer)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.tag != "Arrow")
        {
            Stick();
        }
    }

    private void Stick()
    {
        myBody.constraints = RigidbodyConstraints.FreezeAll;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowController : MonoBehaviour
{
    Rigidbody myBody;
    private float lifeTimer = 3f;
    private float timer;
    private bool hitSomething = false;

    void Start()
    {
        myBody = GetComponent<Rigidbody>();
        transform.rotation = Quaternion.LookRotation(myBody.velocity);
    }

    void Update()
    {
        timer += Time.deltaTime;
        if(timer>= lifeTimer)
        {
            Destroy(gameObject);
        }

        if (!hitSomething)
        {
            transform.rotation = Quaternion.LookRotation(myBody.velocity);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.tag != "Arrow")
        {
            hitSomething = true;
            Stick();
        }
    }

    private void Stick()
    {
        myBody.constraints = RigidbodyConstraints.FreezeAll;
    }
}

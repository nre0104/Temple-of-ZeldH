using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    public Camera cam;
    public GameObject arrowPrefab;
    public Transform arrowSpawn;
    public float shootForce = 20f;


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            // TODO: Fix rotation of arrows
            GameObject go = Instantiate(arrowPrefab, arrowSpawn.position, transform.rotation * Quaternion.Euler(90, 90, 90));
            Rigidbody rb = go.GetComponent<Rigidbody>();

            rb.velocity = cam.transform.forward * shootForce;
        }
    }
}

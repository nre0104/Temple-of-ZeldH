using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordHitController : MonoBehaviour
{
    public Camera Cam;
    public float maxDistance;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Ray ray = new Ray(Cam.transform.position, Cam.transform.forward);
            Debug.DrawLine(ray.origin, ray.GetPoint(maxDistance));

            RaycastHit hit;
            if (Physics.Raycast(ray,out hit, maxDistance))
            {
                // TODO: Make damage
                Debug.Log(hit.collider.gameObject.name);
            }
         
        }
    }
}

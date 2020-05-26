using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordHitController : MonoBehaviour
{
    public Camera Cam;
    public float maxdistance;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Ray ray = new Ray(Cam.transform.position, Cam.transform.forward);
            Debug.DrawLine(ray.origin, ray.GetPoint(maxdistance));

            RaycastHit hit;
            if (Physics.Raycast(ray,out hit, maxdistance))
            {
                Debug.Log(hit.collider.gameObject.name);
            }
         
        }
    }
}

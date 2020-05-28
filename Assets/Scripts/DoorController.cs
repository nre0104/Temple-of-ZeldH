using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour
{
    public GameObject Door;
    public bool doorIsOpening;
    public Material greenMaterial;

    void Update()
    {
        if(doorIsOpening)
        {
            Door.transform.Translate(Vector3.up * Time.deltaTime * 300);
        }

        if(Door.transform.position.y > 4f)
        {
            doorIsOpening = false;
        }
    }

    void OnMouseDown()
    {
        doorIsOpening = true;
        GetComponent<Renderer>().material = greenMaterial;
    }
}

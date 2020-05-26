using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playercontroller : MonoBehaviour
{
    public GameObject Sword;
    public GameObject Bow;
    public float PlayerHealt;
    public bool activWeap = true;
    // Start is called before the first frame update
    void Start()
    {
        Sword.SetActive(activWeap);
        Bow.SetActive(!activWeap);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse2))
        {
            activWeap = !activWeap;
            Sword.SetActive(activWeap);
            Bow.SetActive(!activWeap);
        }
    }
}

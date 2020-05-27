using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveControler : MonoBehaviour
{
    public float speed = 4;
    public float rotSpeed = 80;
    public float gravity = 8;
    public float rot = 0f;

    public Vector3 moveDir = Vector3.zero;

    public CharacterController controller;
    public Animator anim;

    private void Start()
    {
        controller = GetComponent<CharacterController>();
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        movment();
        getInput();
    }

    void movment()
    {

        if (Input.GetKey(KeyCode.W))
        {
             if (anim.GetBool("atk") == true)
             {
                return;
             }
             else if (anim.GetBool("atk") == false) { 
                 anim.SetBool("running", true);
                 anim.SetInteger("condition", 1);
                 moveDir = new Vector3(0, 0, 1);
                 moveDir *= speed;
                 moveDir = transform.TransformDirection(moveDir);
                 }
             }

                if (Input.GetKeyUp(KeyCode.W))
                {
                    anim.SetBool("running", false);
                    anim.SetInteger("condition", 0);
                    moveDir = new Vector3(0, 0, 0);
                }


        rot += Input.GetAxis("Horizontal") * rotSpeed * Time.deltaTime;
        transform.eulerAngles = new Vector3(0, rot, 0);




        moveDir.y -= gravity * Time.deltaTime;
        controller.Move(moveDir * Time.deltaTime);
    }

    void getInput()
    {
        if (Input.GetMouseButton(0))
        {
            if(anim.GetBool("running") == true)
            {
               anim.SetBool("running", false);
               anim.SetInteger("condition", 0);
            }
            if(anim.GetBool("running") == false)
            {
               attacking();
            }
        }
        
    }

    void attacking()
    {
        StartCoroutine("attackRoutine");
    }

    IEnumerator attackRoutine()
    {
        anim.SetBool("atk", true);
        anim.SetInteger("condition", 2);
        yield return new WaitForSeconds(1);
        anim.SetInteger("condition", 0);
        anim.SetBool("atk", false);
    }
}

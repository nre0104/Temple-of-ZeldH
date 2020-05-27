using System.Collections;
using UnityEngine;

namespace Assets.Scripts
{
    public class MovementController : MonoBehaviour
    {
        public float speed = 4;
        public float rotSpeed = 80;
        public float gravity = 8;
        public float rot = 0f;
        public float jumpSpeed = 8f;

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
            // jump();
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

            /*
        if (Input.GetKeyDown(KeyCode.Space))
        {
            anim.SetBool("jumping", true);
            anim.SetInteger("condition", 3);
            moveDir = new Vector3(0, 3, 0);
            moveDir *= speed;
            moveDir = transform.TransformDirection(moveDir);
        }

        if(anim.GetBool("jumping") == false && anim.GetBool("running") == false)
        {
            anim.SetInteger("condition", 0);
        }

        if (controller.isGrounded)
        {
            anim.SetBool("jumping", false);
        }
        */

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
}

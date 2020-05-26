﻿using System;
using UnityEngine;

namespace Assets.Scripts
{
    public class PlayerSkillsManager : MonoBehaviour
    {
        public GameObject hand;
        public GameObject bombObject;
        public int throwForce;

        public GameObject icePrefab;
        public Camera camera;
        public String waterTag;
        public float maxDistToCreateIce;

        public int timeFactor;

        public LayerMask interactionLayer;
        public float freezeTime;
        private GameObject frozenObject;

        public float magnetismRange;
        private GameObject objInUse;

        void Update()
        {
            if (Input.GetKey(KeyCode.Alpha1))
            {
                PlaceIce();
            }
            if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                ThrowBomb();
            }
            if (Input.GetKeyDown(KeyCode.Alpha3))
            {
                SlowTime();
            }
            if (Input.GetKeyDown(KeyCode.Alpha4))
            {
                SpeedUpTime();
            }
            if (Input.GetKey(KeyCode.E))
            {
                FreezeObject();
            }
            if (Input.GetKey(KeyCode.R))
            {
                UseMagnetism();
            }
            if (Input.GetKeyUp(KeyCode.R))
            {
                ReleaseMagnetism();
            }
        }

        void PlaceIce()
        {
            Ray ray = new Ray(camera.transform.position, camera.transform.forward);
            Debug.DrawLine(ray.origin, ray.GetPoint(maxDistToCreateIce), Color.red);

            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, maxDistToCreateIce))
            {
                if (hit.transform.gameObject.CompareTag(waterTag))
                {
                    Instantiate(icePrefab, new Vector3(hit.transform.position.x, hit.transform.position.y + icePrefab.gameObject.transform.localPosition.y, hit.transform.position.z), Quaternion.identity);
                    
                    Debug.Log("ICE");
                }
            }
        }

        void FreezeObject()
        {
            Ray ray = new Ray(camera.transform.position, camera.transform.forward);
            Debug.DrawLine(ray.origin, ray.GetPoint(maxDistToCreateIce), Color.red);

            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, maxDistToCreateIce, interactionLayer) && frozenObject == null)
            {
                hit.transform.gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
                frozenObject = hit.transform.gameObject;
                Invoke("UnFreezeObject", freezeTime);

                Debug.Log("FREEZE");
            }
        }

        void UnFreezeObject()
        {
            frozenObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
            frozenObject = null;
        }

        void SlowTime()
        {
            if (Time.timeScale >= 1f)
            {
                SetStandardTime();


                Time.timeScale /= timeFactor;
                SetPlayerToNormalSpeed();

                Debug.Log("SLOW");
            }
            else
            {
                SetStandardTime();
            }
        }

        void SpeedUpTime()
        {

            if (Time.timeScale <= 1f)
            {
                SetStandardTime();

                Time.timeScale *= timeFactor;
                SetPlayerToNormalSpeed();

                Debug.Log("SPEED");
            }
            else
            {
                SetStandardTime();
            }
        }

        void SetStandardTime()
        {
            if (Time.timeScale != 1f)
            {
                Time.timeScale = 1f;

                Debug.Log("NORMAL");
            }
        }

        // TODO: Set player to normal speed
        void SetPlayerToNormalSpeed()
        {
            if (Time.timeScale < 1f)
            {
                
            }
            if (Time.timeScale > 1f)
            {
                
            }
        }

        void UseMagnetism()
        {
            Ray ray = new Ray(camera.transform.position, camera.transform.forward);
            Debug.DrawLine(ray.origin, ray.GetPoint(magnetismRange), Color.cyan);

            if (objInUse == null)
            {
                RaycastHit hit;

                if (Physics.Raycast(ray, out hit, magnetismRange, interactionLayer))
                {
                    if (hit.transform.gameObject.GetComponent<Rigidbody>() != null)
                    {
                        objInUse = hit.transform.gameObject;
                        objInUse.transform.parent = camera.transform;

                        objInUse.GetComponent<Rigidbody>().isKinematic = true;
                    }
                }
            }
        }

        void ReleaseMagnetism() 
        {
            if (objInUse != null)
            {
                objInUse.GetComponent<Rigidbody>().isKinematic = false;
                objInUse.transform.parent = null;
                objInUse = null;
            }
        }

        void ThrowBomb()
        {
            GameObject bomb = Instantiate(bombObject, hand.transform.position, Quaternion.identity);
            Rigidbody r = bomb.GetComponent<Rigidbody>();
            r.AddForce(hand.transform.forward * throwForce * 1.05f);

            Debug.Log("BOMB");
        }
    }
}
﻿using System;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

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

        public int timeDividerMultiplier;

        void Start()
        {

        }

        void Update()
        {
            if (Input.GetKeyDown(KeyCode.Alpha1))
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

        void SlowTime()
        {
            if (Time.timeScale > 1f)
            {
                SetStandardTime();

                Time.timeScale /= timeDividerMultiplier;
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

            if (Time.timeScale < 1f)
            {
                SetStandardTime();

                Time.timeScale *= timeDividerMultiplier;
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

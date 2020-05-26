using System;
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
            Debug.DrawLine(ray.origin, ray.GetPoint(maxDistToCreateIce));

            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, maxDistToCreateIce))
            {
                if (hit.transform.gameObject.CompareTag(waterTag) && hit.transform.gameObject.GetComponent<Rigidbody>() != null)
                {
                    Instantiate(icePrefab, new Vector3(hit.transform.position.x, hit.transform.position.y, hit.transform.position.z), Quaternion.identity);

                    Debug.Log("ICE");
                }
            }
        }

        void SlowTime()
        {
            if (Time.timeScale == 1f)
            {
                Time.timeScale = 0.25f;

                Debug.Log("SLOW");
            }
            else
            {
                SetStandardTime();
            }
        }

        void SpeedUpTime()
        {

            if (Time.timeScale == 1f)
            {
                Time.timeScale = 1.5f;

                Debug.Log("SPEED");
            }
            else
            {
                SetStandardTime();
            }
        }

        void SetStandardTime()
        {
            if (Time.timeScale != 1.0f)
            {
                Time.timeScale = 1f;

                Debug.Log("NORMAL");
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

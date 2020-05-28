using System;
using UnityEngine;

namespace Assets.Scripts
{
    public class SkillsController : MonoBehaviour
    {
        public Camera spawnPoint;
        public GameObject bombObject;
        public int throwForce;

        public GameObject icePrefab;
        public Camera camera;
        public String waterTag;
        public float maxDistToCreateIce;

        public LayerMask interactionLayer;
        public float freezeRange;
        public float freezeTime;
        private GameObject frozenObject;

        public float magnetismRange;
        private Vector3 magnitismPossition;
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
                TimeManager.Instance.SlowDownTime();
            }
            if (Input.GetKeyDown(KeyCode.Alpha4))
            {
                TimeManager.Instance.SpeedUpTime();
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
                    Destroy(hit.transform.gameObject);

                    Debug.Log("ICE");
                }
            }
        }

        void FreezeObject()
        {
            Ray ray = new Ray(camera.transform.position, camera.transform.forward);
            Debug.DrawLine(ray.origin, ray.GetPoint(freezeRange), Color.red);

            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, freezeRange, interactionLayer) && frozenObject == null)
            {
                hit.transform.gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
                frozenObject = hit.transform.gameObject;
                Invoke("UnFreezeObject", freezeTime);

                Debug.Log("FREEZE");
            }
        }

        void UnFreezeObject()
        {
            if (frozenObject != null)
            {
                frozenObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
                frozenObject = null;
            }
        }

        void UseMagnetism()
        {
            Ray ray = new Ray(camera.transform.position, camera.transform.forward);
            Debug.DrawLine(ray.origin, ray.GetPoint(magnetismRange), Color.cyan);
            float magnitismRangMax = magnetismRange;
            float magnitismRangMin = 3f;

            if (objInUse == null)
            {
                RaycastHit hit;

                if (Physics.Raycast(ray, out hit, magnetismRange, interactionLayer))
                {
                    if (hit.transform.gameObject.GetComponent<Rigidbody>() != null)
                    {
                        objInUse = hit.transform.gameObject;
                        magnitismPossition = hit.transform.gameObject.transform.position;

                        objInUse.transform.parent = camera.transform;
                        objInUse.GetComponent<Rigidbody>().isKinematic = true;
                        objInUse.GetComponent<Collider>().isTrigger = true;
                    }
                }
            }
            
            // TODO: Maximize/minimize the range
            if (objInUse != null)
            {
                float distance = Vector3.Distance(transform.position, magnitismPossition);
                if (Input.GetAxis("Mouse ScrollWheel") > 0f) // +
                {
                    if(distance < magnitismRangMax)
                    {
                        Vector3 len = objInUse.transform.position += camera.transform.forward;
                        magnitismPossition = objInUse.transform.position;
                        distance += Vector3.Distance(transform.position, magnitismPossition);
                        Debug.Log(distance);
                    }
                }
                else if (Input.GetAxis("Mouse ScrollWheel") < 0f) // --
                {
                    if(distance > magnitismRangMin)
                    {
                        Vector3 len = objInUse.transform.position -= camera.transform.forward;
                        magnitismPossition = objInUse.transform.position;
                        distance -= Vector3.Distance(transform.position, magnitismPossition);
                        Debug.Log(distance);
                    }
                }
            }
        }

        void ReleaseMagnetism() 
        {
            if (objInUse != null)
            {
                objInUse.GetComponent<Collider>().isTrigger = false;
                objInUse.GetComponent<Rigidbody>().isKinematic = false;
                objInUse.transform.parent = null;
                objInUse = null;
            }
        }

        void ThrowBomb()
        {
            GameObject bomb = Instantiate(bombObject, spawnPoint.transform.position, Quaternion.identity);
            Rigidbody r = bomb.GetComponent<Rigidbody>();
            r.AddForce(spawnPoint.transform.forward * throwForce * 1.05f);

            Debug.Log("BOMB");
        }
    }
}

using System;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts
{
    public class SkillsController : MonoBehaviour
    {

        public Camera spawnPoint;
        public GameObject bombObject;
        public int throwForce;

        public GameObject icePrefab;
        public Transform iceTransform;
        public Camera camera;
        public String waterTag;
        public float maxDistToCreateIce;
        public Queue<GameObject> turnedIce = new Queue<GameObject>();

        public LayerMask interactionLayer;
        public float freezeRange;
        public float freezeTime;
        private GameObject frozenObject;
        public Material FreezeMaterial;
        private Material StashMaterial;

        public float magnetismRange;
        private Vector3 magnitismPossition;
        public Transform magnetismTransform;
        private GameObject objInUse;

        private Vector3 skillshotPosition;
        private float skillshotSize;

        private void Awake()
        {
            iceTransform.gameObject.SetActive(false);
            magnetismTransform.gameObject.SetActive(false);
        }


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
                    Instantiate(icePrefab, new Vector3(hit.transform.position.x, hit.transform.position.y + icePrefab.gameObject.transform.localPosition.y*1.8f, hit.transform.position.z), Quaternion.identity);
                    turnedIce.Enqueue(hit.transform.gameObject);
                    hit.transform.gameObject.SetActive(false);
                    Invoke("Melt", 5f);
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
                GameObject obj = hit.transform.gameObject;
                StashMaterial = obj.GetComponent<Renderer>().material;
                obj.GetComponent<Renderer>().material = FreezeMaterial;
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
                frozenObject.GetComponent<Renderer>().material = StashMaterial;
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
                        skillshotPosition = hit.point;
                        HandleMagAnimation();
                        objInUse = hit.transform.gameObject;
                        magnitismPossition = hit.transform.gameObject.transform.position;

                        objInUse.transform.parent = camera.transform;
                        objInUse.GetComponent<Rigidbody>().isKinematic = true;
                        objInUse.GetComponent<Collider>().isTrigger = true;
                    }
                }
            }
            
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
                    }
                }
                else if (Input.GetAxis("Mouse ScrollWheel") < 0f) // --
                {
                    if(distance > magnitismRangMin)
                    {
                        Vector3 len = objInUse.transform.position -= camera.transform.forward;
                        magnitismPossition = objInUse.transform.position;
                        distance -= Vector3.Distance(transform.position, magnitismPossition);
                    }
                }
            }
        }

        void ReleaseMagnetism() 
        {
            if (objInUse != null)
            {
                StopAnimation();
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

        void StopAnimation()
        {
            magnetismTransform.gameObject.SetActive(false);
        }

        void HandleMagAnimation()
        {
            magnetismTransform.gameObject.SetActive(true);
            magnetismTransform.LookAt(skillshotPosition);
            skillshotSize = Vector3.Distance(transform.position,skillshotPosition);
            magnetismTransform.localScale = new Vector3(1, 1, skillshotSize);
        }

        void HandleIceAnimation()
        {
            iceTransform.gameObject.SetActive(true);
            iceTransform.LookAt(skillshotPosition);
            skillshotSize = Vector3.Distance(transform.position, skillshotPosition);
            iceTransform.localScale = new Vector3(1, 1, skillshotSize);
        }

        void Melt()
        {
            GameObject go =  turnedIce.Dequeue();
            go.SetActive(true);
        }
    }
}

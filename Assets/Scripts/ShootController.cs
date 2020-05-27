using UnityEngine;

namespace Assets.Scripts
{
    public class ShootController : MonoBehaviour
    {
        public Camera cam;
        public GameObject arrowPrefab;
        public Transform arrowSpawn;
        public float shootForce = 20f;

        // Update is called once per frame
        void Update()
        {
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                GameObject go = Instantiate(arrowPrefab, arrowSpawn.position, arrowSpawn.rotation);
                Rigidbody rb = go.GetComponent<Rigidbody>();

                rb.velocity = cam.transform.forward * shootForce;
            }
        }
    }
}

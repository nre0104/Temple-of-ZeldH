using UnityEngine;

namespace Assets.Scripts
{
    public class IceController : MonoBehaviour
    {
        public float meltingTime;
        public GameObject puddlePrefab;

        void Start()
        {
            Invoke("Melt", meltingTime);
        }

        void Melt()
        {
            gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;

            GameObject obj = Instantiate(puddlePrefab, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
            obj.transform.parent = null;

            Destroy(gameObject);
        }
    }
}

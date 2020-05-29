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

            Destroy(gameObject);
        }
    }
}

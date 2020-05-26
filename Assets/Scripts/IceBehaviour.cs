using UnityEngine;

namespace Assets.Scripts
{
    public class IceBehaviour : MonoBehaviour
    {
        public float meltingTime;

        void Start()
        {
            Invoke("Melt", meltingTime);
        }

        void Melt()
        {
            Destroy(this.gameObject);
        }
    }
}

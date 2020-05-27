using UnityEngine;

namespace Assets.Scripts
{
    public class IceMeltingController : MonoBehaviour
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

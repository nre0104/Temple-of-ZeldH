using UnityEngine;

namespace Assets.Scripts
{
    public class TargetController : MonoBehaviour
    {

        public float Health;

        private void OnCollisionEnter(Collision collision)
        {
            if(collision.transform.tag == "Arrow" || collision.transform.tag == "Sword")
            {
                Health--;
                if (Health < 1) {
                    Destroy(gameObject);
                }
            }
        }
    }
}

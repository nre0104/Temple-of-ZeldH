using UnityEngine;

namespace Assets.Scripts
{
    public class HealthController : MonoBehaviour
    {
        public float Health = 1f;

        public void TakeDamage(float amount)
        {
            Health -= amount;
            Destroy();
        }

        void Destroy()
        {
            if (Health <= 0f)
            {
                Destroy(gameObject);
            }
        }
    }
}

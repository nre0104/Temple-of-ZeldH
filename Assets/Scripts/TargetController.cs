using UnityEngine;

namespace Assets.Scripts
{
    public class TargetController : MonoBehaviour
    {
        public float Health = 50f;

        public void TakeDamage(float amount)
        {
            Health -= amount;
            Destroy();
        }

        public void Die()
        {
            Health = 0f;
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

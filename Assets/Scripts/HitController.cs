using UnityEngine;

namespace Assets.Scripts
{
    public class HitController : MonoBehaviour
    {
        public float damage;
        
        void OnCollisionEnter(Collision collision) 
        {
            Debug.Log("SwordHit");

            if (collision.transform.GetComponent<HealthController>() != null)
            { 
                collision.transform.GetComponent<HealthController>().TakeDamage(damage);
            }
        }
    }
}

using UnityEngine;

namespace Assets.Scripts
{
    public class SwordHitController : MonoBehaviour
    {
        public float damage;
        
        void OnCollisionEnter(Collision collision) 
        {
            if (collision.transform.GetComponent<TargetController>() != null)
            {
                collision.transform.GetComponent<TargetController>().TakeDamage(damage);
            }
        }
    }
}

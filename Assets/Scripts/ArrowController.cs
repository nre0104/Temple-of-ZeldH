using UnityEngine;

namespace Assets.Scripts
{
    public class ArrowController : MonoBehaviour
    {
        public float damage;
        private Rigidbody myBody;
        private float lifeTimer = 3f;
        private float timer;

        void Start()
        {
            myBody = GetComponent<Rigidbody>();
        }

        void Update()
        {
            timer += Time.deltaTime;
            if(timer>= lifeTimer)
            {
                Destroy(gameObject);
            }
        }

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.transform.GetComponent<HealthController>() != null)
            {
                collision.transform.GetComponent<HealthController>().TakeDamage(damage);
            }

            if (collision.collider.tag != "Arrow")
            {
                Stick();
            }
        }

        private void Stick()
        {
            myBody.constraints = RigidbodyConstraints.FreezeAll;
        }
    }
}

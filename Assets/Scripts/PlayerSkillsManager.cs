using UnityEngine;

namespace Assets.Scripts
{
    public class PlayerSkillsManager : MonoBehaviour
    {
        public GameObject hand;
        public GameObject bombObject;
        public int throwForce;

        // Start is called before the first frame update
        void Start()
        {
            
        }

        // Update is called once per frame
        void Update()
        {
            
        }

        void PlaceIce()
        {

        }

        void SlowTime()
        {
            if (Time.timeScale == 1f)
            {
                Time.timeScale = 0.25f;

            }
        }

        void SpeedUpTime()
        {

            if (Time.timeScale == 1f)
            {
                Time.timeScale = 1.5f;

            }
        }

        void SetStandardTime()
        {
            if (Time.timeScale != 1.0f)
            {
                Time.timeScale = 1f;
            }
        }

        void ThrowBomb()
        {
            GameObject bomb = Instantiate(bombObject, hand.transform.position, Quaternion.identity);
            Rigidbody r = bomb.GetComponent<Rigidbody>();
            r.AddForce(hand.transform.forward * throwForce * 1.05f);
        }
    }
}

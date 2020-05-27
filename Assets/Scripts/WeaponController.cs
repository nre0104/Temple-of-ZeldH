using UnityEngine;

namespace Assets.Scripts
{
    public class WeaponController : MonoBehaviour
    {
        public GameObject Sword;
        public GameObject Bow;
        public bool ActiveWeapon = true;

        void Start()
        {
            Sword.SetActive(ActiveWeapon);
            Bow.SetActive(!ActiveWeapon);
        }

        void Update()
        {
            if (Input.GetKeyDown(KeyCode.Mouse2))
            {
                ActiveWeapon = !ActiveWeapon;
                Sword.SetActive(ActiveWeapon);
                Bow.SetActive(!ActiveWeapon);
            }
        }
    }
}

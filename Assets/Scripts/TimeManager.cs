using UnityEngine;

namespace Assets.Scripts
{
    public class TimeManager : MonoBehaviour
    {
        static TimeManager _instance;

        public int slowDownFactor = 4;
        public int speedUpFactor = 4;

        // Start is called before the first frame update
        public static TimeManager Instance
        {
            get
            {
                if (_instance == null)
                {
                    GameObject go = new GameObject();
                    _instance = go.AddComponent<TimeManager>();
                }
                return _instance;
            }
        }

        public void SlowDownTime()
        {
            if (Time.timeScale >= 1f)
            {
                SetStandardTime();

                Time.timeScale /= slowDownFactor;
                Debug.Log("SLOW");
            }
            else
            {
                SetStandardTime();
            }
        }

        public void SpeedUpTime()
        {

            if (Time.timeScale <= 1f)
            {
                SetStandardTime();

                Time.timeScale *= speedUpFactor;
                Debug.Log("SPEED");
            }
            else
            {
                SetStandardTime();
            }
        }

        void SetStandardTime()
        {
            if (Time.timeScale != 1f)
            {
                Time.timeScale = 1f;
                Debug.Log("NORMAL");
            }
        }
    }
}

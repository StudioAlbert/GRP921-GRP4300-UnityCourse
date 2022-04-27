using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SOCarGame
{
    public class GameManager : MonoBehaviour
    {
        [SerializeField] private float bonusTime;
        [SerializeField] private float startTime;
        [SerializeField] UIManager uiManager;
        //[SerializeField] GameObject car;

/*        private float timeElapsed;
        public float TimeElapsed => timeElapsed;*/
        public SOFloatValue TimeElapsed;
        public SOFloatValue CurrentLap;

        public static bool GameOver;
        private bool gameStarted = false;

        // Start is called before the first frame update
        void Start()
        {
            // TimeElapsed.Value = 0;
            // CurrentLap.Value = 0;

            GameOver = false;

            StartCoroutine("CountDown");

        }

        // Update is called once per frame
        void Update()
        {
            if (gameStarted)
            {
                if (GameOver)
                {
                    TimeElapsed.Value = 0;
                }
                else
                {
                    TimeElapsed.Value -= Time.deltaTime;
                }

                if (TimeElapsed.Value < 5)
                    uiManager.PlayTimeRemaining();

                if (TimeElapsed.Value <= 0)
                {
                    GameOver = true;
                    uiManager.PlayGameOver();
                }
            }


            //uiManager.UpdateTimeElapsed(timeElapsed);

            // Transform rb.velocity to understandable km/h
            //uiManager.UpdateCarSpeed(car.GetComponent<Rigidbody>().velocity.magnitude);

        }

        public void OnLapChanged()
        {

            if (gameStarted)
            {
                TimeElapsed.Value += bonusTime;
                uiManager.PlayBonusTime(bonusTime);

                CurrentLap.Value += 1;
                //uiManager.UpdateLap(currentLap);

            }
            else
            {
                TimeElapsed.Value = startTime;
                uiManager.PlayBonusTime(startTime);
            }

            if (CurrentLap.Value == 0)
            {
                gameStarted = true;
            }

        }

        IEnumerator CountDown()
        {
            uiManager.HideRacePanel();
            uiManager.ShowPreracePanel();
            yield return new WaitForSeconds(3);

            uiManager.HidePreracePanel();
            uiManager.ShowRacePanel();

        }
    }

}
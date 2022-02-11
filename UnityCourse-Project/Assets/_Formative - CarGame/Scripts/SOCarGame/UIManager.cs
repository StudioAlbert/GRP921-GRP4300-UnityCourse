using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace SOCarGame
{
    public class UIManager : MonoBehaviour
    {

        [SerializeField] Text ChronoTextSec;
        [SerializeField] Text ChronoTextMsec;
        [SerializeField] Text BonusTimeText;
        [SerializeField] Text LapValueText;
        [SerializeField] Text SpeedValueText;

        [SerializeField] GameObject RaceIsOverPanel;
        [SerializeField] GameObject PreracePanel;
        [SerializeField] GameObject RacePanel;



        // ----------------------------------------------------------------------------------------------
        [SerializeField] Animator ChronoAnimator;
        [SerializeField] Animator BonusTimeAnimator;

        // External Values
        public SOFloatValue CarSpeed;
        public SOFloatValue TimeElapsed;
        public SOFloatValue CurrentLap;

        // Start is called before the first frame update
        void Start()
        {
            RaceIsOverPanel.SetActive(false);
        }

        void Update()
        {
            UpdateCarSpeed();
            UpdateTimeElapsed();
            UpdateLap();
        }

        // Update is called once per frame
        public void UpdateTimeElapsed()
        {
            int intPart = Mathf.FloorToInt(TimeElapsed.Value);
            int decimalPart = Mathf.FloorToInt(1000 * (TimeElapsed.Value - intPart));

            ChronoTextSec.text = intPart.ToString();
            ChronoTextMsec.text = decimalPart.ToString("000");

        }
        private void UpdateLap()
        {
            LapValueText.text = CurrentLap.Value.ToString();
        }
        private void UpdateCarSpeed()
        {
            SpeedValueText.text = (CarSpeed.Value * (3600f / 1000f)).ToString("000.00");
        }

        public void PlayGameOver()
        {
            //UIAnimator.Play("GameOver");
            RaceIsOverPanel.SetActive(true);
        }



        public void PlayTimeRemaining()
        {
            ChronoAnimator.Play("TimeRemaining");
        }

        public void PlayBonusTime(float bonusTime)
        {
            BonusTimeText.text = "+ " + bonusTime + " sec.";
            BonusTimeAnimator.SetTrigger("BonusTime");
        }

        public void ShowPreracePanel()
        {
            PreracePanel.SetActive(true);
        }

        public void ShowRacePanel()
        {
            RacePanel.SetActive(true);
        }

        public void HidePreracePanel()
        {
            PreracePanel.SetActive(false);
        }

        public void HideRacePanel()
        {
            RacePanel.SetActive(false);
        }
    }

}
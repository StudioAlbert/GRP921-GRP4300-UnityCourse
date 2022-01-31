using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{

    [SerializeField]
    Text ChronoTextSec;
    [SerializeField]
    Text ChronoTextMsec;
    [SerializeField]
    Text BonusTimeText;
    [SerializeField]
    Text LapValueText;
    [SerializeField]
    Text SpeedValueText;

    [SerializeField]
    GameObject RaceIsOverPanel;
    [SerializeField]
    GameObject PreracePanel;
    [SerializeField]
    GameObject RacePanel;



    // ----------------------------------------------------------------------------------------------
    [SerializeField]
    Animator ChronoAnimator;
    [SerializeField]
    Animator BonusTimeAnimator;

    // Start is called before the first frame update
    void Start()
    {
        RaceIsOverPanel.SetActive(false);
    }

    // Update is called once per frame
    public void UpdateTimeElapsed(float timeElapsed)
    {
        int intPart = Mathf.FloorToInt(timeElapsed);
        int decimalPart = Mathf.FloorToInt(1000 * (timeElapsed - intPart));

        ChronoTextSec.text = intPart.ToString();
        ChronoTextMsec.text = decimalPart.ToString("000");

    }

    public void UpdateLap(int currentLap)
    {
        LapValueText.text = currentLap.ToString();
    }

    public void PlayGameOver()
    {
        //UIAnimator.Play("GameOver");
        RaceIsOverPanel.SetActive(true);
    }

    internal void UpdateCarSpeed(float velocity)
    {
        SpeedValueText.text = (velocity * (3600f / 1000f)).ToString("000.00");
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

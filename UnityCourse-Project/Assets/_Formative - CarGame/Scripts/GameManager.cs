using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private float bonusTime;
    [SerializeField]
    private float startTime;
    [SerializeField]
    UIManager uiManager;
    [SerializeField]
    GameObject car;

    private float timeElapsed;
    public float TimeElapsed => timeElapsed;

    private int currentLap;

    public static bool GameOver;
    private bool gameStarted = false;
    
    // Start is called before the first frame update
    void Start()
    {
        timeElapsed = 0;
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
                timeElapsed = 0;
            }
            else
            {
                timeElapsed -= Time.deltaTime;
            }

            if (timeElapsed < 5)
                uiManager.PlayTimeRemaining();

            if (timeElapsed <= 0)
            {
                GameOver = true;
                uiManager.PlayGameOver();
            }
        }
        

        uiManager.UpdateTimeElapsed(timeElapsed);

        // Transform rb.velocity to understandable km/h
        uiManager.UpdateCarSpeed(car.GetComponent<Rigidbody>().velocity.magnitude);

    }

    public void OnLapChanged()
    {
        
        if (gameStarted)
        {
            timeElapsed += bonusTime;
            uiManager.PlayBonusTime(bonusTime);

            currentLap += 1;
            uiManager.UpdateLap(currentLap);

        }
        else
        {
            timeElapsed = startTime;
            uiManager.PlayBonusTime(startTime);
        }

        if (currentLap == 0)
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

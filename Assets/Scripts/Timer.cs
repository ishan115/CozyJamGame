using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    [SerializeField]
    private float timeToStart;
    [SerializeField]
    private Text timerUI;

    private bool slowTime = false;
    private float slowDownLength = 5f;

    private float timeRemaining;
    // Start is called before the first frame update
    void Start()
    {
        timeRemaining = timeToStart;
    }

    // Update is called once per frame
    void Update()
    {
        if (slowTime != true)
        {
            timeRemaining -= Time.deltaTime;
        }
        else
        {
            timeRemaining -= Time.deltaTime / 2;
        }
       /* if (Input.GetButtonDown("Fire1"))
        {
            timeRemaining += 5;
        }
        */
        int timeRounded = Mathf.RoundToInt(timeRemaining);
        string timeText = timeRounded.ToString();
        timerUI.text = timeText;
    }

    //May wish to make these have parameters that change based on which object is hit
    public void AddTime()
    {
        timeRemaining += 5;
    }

    public void SubtractTime()
    {
        timeRemaining -= 5;
    }

    public void SlowTimer()
    {
        slowTime = true;
        StartCoroutine("SlowTimerLength");
    }

    private IEnumerator SlowTimerLength()
    {
        yield return new WaitForSeconds(slowDownLength);
        slowTime = false;
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    public Text timeText;
    private float time = 10f;
    private Slider slTimer;
    private float fSliderBarTime;

    private void Awake()
    {
        slTimer = GetComponent<Slider>();
    }

    private void Update()
    {
        TimeCheck();
        TimeSlider();
    }

    private void TimeCheck()
    {
        time -= Time.deltaTime;
        timeText.text = string.Format("{0:N1}", time);
    }

    public void TimeSlider()
    {
        if (slTimer.value > 0.0f)
        {
            if(Time.timeScale == 1)
            {
                slTimer.value -= 1;
            }
        }
        else
        {
            Time.timeScale = 0;
            //die();
            SceneManager.LoadScene("GameOver");
        }
    }
}

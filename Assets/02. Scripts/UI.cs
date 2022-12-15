using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    public GameObject start;
    public GameObject die;
    public int nowHp;
    public Text lastTimeText;
    public Text timeText;
    private float time;

    private void Awake()
    {
        start.SetActive(true);
        die.SetActive(false);
    }

    private void Update()
    {
        nowHp = GameObject.FindObjectOfType<PlayerCtr>().hp;
        Dead();
        TimeCheck();
    }

    private void Dead()
    {
        if (nowHp < 1)
        {
            nowHp = 3;
            Debug.Log(nowHp);
            die.SetActive(true);
            lastTimeText.text = timeText.text;
        }
        
    }

    public void OnClickStart()
    {
        start.SetActive(false);
        Time.timeScale = 1;
    }

    public void OnClickRestart()
    {
        die.SetActive(false);
        Time.timeScale = 1;
        
        Debug.Log("Check");
    }

    private void TimeCheck()
    {
        time += Time.deltaTime;
        timeText.text = string.Format("{0:N2}", time);
    }
}

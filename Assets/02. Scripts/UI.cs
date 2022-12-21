using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UI : MonoBehaviour
{
    public Text lastTimeText;
    
    private void Awake()
    {
        
    }

    private void Update()
    {
        
    }

    public void OnClickStart()
    {
        SceneManager.LoadScene("Main");
        //Time.timeScale = 1;
    }

    public void OnClickRestart()
    {
        SceneManager.LoadScene("Main");
    }
}

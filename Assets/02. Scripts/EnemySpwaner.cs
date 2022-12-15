using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpwaner : MonoBehaviour
{
    public GameObject enemy;
    public Transform spwanPosition;
    private float time = 10;

    private void Start()
    {

    }

    private void Update()
    {
        time -= Time.deltaTime;
        if (time < 0)
        {
            enemy.transform.position = spwanPosition.position;
            time = 10;
        }
    }
}

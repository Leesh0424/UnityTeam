using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using static UnityEngine.EventSystems.EventTrigger;

public class Enemy : MonoBehaviour
{
    public Transform target;
    public NavMeshAgent agent;
    public Transform spwanPosition;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        UpdateRun();
        if (Time.timeScale == 0)
        {
            transform.position = spwanPosition.position;
        }
    }

    private void UpdateRun()
    {
        agent.speed = 9f;
        agent.destination = target.transform.position;
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            transform.position = spwanPosition.position;
            Debug.Log("hit");
        }
    }
}

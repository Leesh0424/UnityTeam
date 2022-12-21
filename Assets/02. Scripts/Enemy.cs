using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using static UnityEngine.EventSystems.EventTrigger;

public class Enemy : MonoBehaviour
{
    public Transform target;
    public Transform runAwayPos;
    public NavMeshAgent agent;
    public Transform spwanPosition;

    public ParticleSystem hitEffect;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        StartCoroutine(Run());
        if (Time.timeScale == 0)
        {
            transform.position = spwanPosition.position;
        }
    }

    IEnumerator Run()
    {
        agent.speed = 9f;
        agent.destination = target.transform.position;
        yield return null;
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

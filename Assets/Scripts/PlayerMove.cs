using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField]
    float movspd = 10.0f;
    void Start()
    {
        
    }
    void Update()
    {
        Move();
    }
    void Move()
    {
        if(Input.GetKey(KeyCode.W))
        {
            transform.Translate(Vector3.forward * movspd * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(Vector3.back * movspd * Time.deltaTime);
            transform.localEulerAngles = new Vector3(0, 180f, 0);
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(Vector3.left * movspd * Time.deltaTime);
            transform.localEulerAngles = new Vector3(0, 90f, 0);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector3.right * movspd * Time.deltaTime);
            transform.localEulerAngles = new Vector3(0, -90f, 0);
        }
    }
}

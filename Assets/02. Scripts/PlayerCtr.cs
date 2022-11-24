using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerCtr : MonoBehaviour
{
    private int hp = 1;

    public float speed = 5f;    //속도

    void FixedUpdate()
    {
        float hor = Input.GetAxis("Horizontal");        //왼쪽, 오른쪽 키 
        float ver = Input.GetAxis("Vertical");          //앞, 뒤 키

        transform.Translate(Vector3.forward * speed * ver * Time.deltaTime);      //이동
        transform.Rotate(Vector3.up * speed * hor);    // 회전
    }
}

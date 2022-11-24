using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerCtr : MonoBehaviour
{
    private int hp = 1;

    public float speed = 5f;    //�ӵ�

    void FixedUpdate()
    {
        float hor = Input.GetAxis("Horizontal");        //����, ������ Ű 
        float ver = Input.GetAxis("Vertical");          //��, �� Ű

        transform.Translate(Vector3.forward * speed * ver * Time.deltaTime);      //�̵�
        transform.Rotate(Vector3.up * speed * hor);    // ȸ��
    }
}

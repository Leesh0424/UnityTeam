using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerCtr : MonoBehaviour
{
    public GameObject Cam;
    public CharacterController SelectPlayer;
    public float Speed;
    public int hp = 3;
    public Transform spawnPoint;

    private float Gravity;
    private Vector3 MoveDir;
    private bool FlyingMode;

    public float shakeTime;
    public float shakeSpeed;
    public float shakeAmount;
    private Transform cam;

    void Start()
    {
        Speed = 10f;
        Gravity = 7f;
        MoveDir = Vector3.zero;
        FlyingMode = false;
        cam = GameObject.FindGameObjectWithTag("MainCamera").transform;
        shakeTime = 0.3f;
        shakeSpeed = 2f;
        shakeAmount = 10f;
    }

    void Update()
    {
        Move();
        Health();
    }

    public Text healthText;

    public void Health()
    {
        healthText.text = string.Format($"HP : {hp}");
    }

    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.CompareTag("Enemy"))
        {
            hp -= 1;
            StartCoroutine(Shake());
            Debug.Log(hp);
        }
        if (hp < 1)
        {
            Die();
        }

    }

    public void Die()
    {
        transform.position = spawnPoint.position;
        hp = 3;
        SceneManager.LoadScene("GameOver");
    }

    private void Move()
    {
        if (SelectPlayer == null) return;

        if (Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0)
        {
            var offset = Cam.transform.forward;
            offset.y = 0;
            transform.LookAt(SelectPlayer.transform.position + offset);
        }
        if (SelectPlayer.isGrounded)
        {
            MoveDir = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
            MoveDir = SelectPlayer.transform.TransformDirection(MoveDir);
            MoveDir *= Speed;


        }
        else
        {
            if (MoveDir.y < 0)
            {
                FlyingMode = true;
            }

            if (FlyingMode)
            {
                MoveDir.y *= 0.95f;

                if (MoveDir.y > -1) MoveDir.y = -1;

                MoveDir.x = Input.GetAxis("Horizontal");
                MoveDir.z = Input.GetAxis("Vertical");
            }
            else
                MoveDir.y -= Gravity * Time.deltaTime;
        }
        SelectPlayer.Move(MoveDir * Time.deltaTime);
    }

    IEnumerator Shake()
    {
        Vector3 originPosition = cam.localPosition;
        float elapsedTime = 0.0f;
        while (elapsedTime < shakeTime)
        {
            Vector3 randomPoint = originPosition + Random.insideUnitSphere * shakeAmount; cam.localPosition = Vector3.Lerp(cam.localPosition, randomPoint, Time.deltaTime * shakeSpeed);
            yield return null;
            elapsedTime += Time.deltaTime;
        }
        cam.localPosition = originPosition;
    }
}
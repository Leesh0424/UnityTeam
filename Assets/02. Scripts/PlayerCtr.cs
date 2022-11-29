using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerCtr : MonoBehaviour
{
    public GameObject Cam; 
    public CharacterController SelectPlayer; 
    public float Speed; 
    public float JumpPow;

    private float Gravity; 
    private Vector3 MoveDir;
    private bool JumpButtonPressed;  
    private bool FlyingMode;  

    void Start()
    {
        Speed = 5.0f;
        Gravity = 10.0f;
        MoveDir = Vector3.zero;
        JumpPow = 5.0f;
        JumpButtonPressed = false;
        FlyingMode = false;
    }

    void Update()
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

            if (JumpButtonPressed == false && Input.GetButton("Jump"))
            {
                SelectPlayer.transform.rotation = Quaternion.Euler(0, 45, 0);
                JumpButtonPressed = true;
                MoveDir.y = JumpPow;
            }
        }
        else
        {
            if (MoveDir.y < 0 && JumpButtonPressed == false && Input.GetButton("Jump"))
            {
                FlyingMode = true;
            }

            if (FlyingMode)
            {
                JumpButtonPressed = true;

                MoveDir.y *= 0.95f;

                if (MoveDir.y > -1) MoveDir.y = -1;

                MoveDir.x = Input.GetAxis("Horizontal");
                MoveDir.z = Input.GetAxis("Vertical");
            }
            else
                MoveDir.y -= Gravity * Time.deltaTime;
        }

        if (!Input.GetButton("Jump"))
        {
            JumpButtonPressed = false;  
            FlyingMode = false;        
        }
        SelectPlayer.Move(MoveDir * Time.deltaTime);
    }
}

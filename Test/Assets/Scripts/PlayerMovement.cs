using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public CharacterController2D characterController;

    public float runSpeed = 40f;

    private float horizontalMove = 0f;

    public int Move;

    public Joystick joystick;

    public bool jump = false;



    void Update()
    {
        //horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;
        horizontalMove = joystick.Horizontal * runSpeed;





    }


    private void FixedUpdate()
    {
        characterController.Move(horizontalMove * Time.fixedDeltaTime, jump);



        jump = false;

    }


    public void Jump()
    {
        jump = true;
    }

}

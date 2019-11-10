using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public CharacterController2D characterController;

    public float runSpeed = 40f;

    private float horizontalMove = 0f;


    private bool jump = false;



    void Update()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;
        





        if (Input.GetButtonDown("Jump"))
        {
            jump = true;
        }




    }


    private void FixedUpdate()
    {
        characterController.Move(horizontalMove * Time.fixedDeltaTime, jump);

        

        jump = false;
        
    }

}

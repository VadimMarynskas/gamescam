using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float speed = 10, jumpVelocity = 10;
    public LayerMask playerMask;
    public bool canMoveInAir = true;
    Transform myTrans, tagGround;
    Rigidbody2D myBody;
    bool isGrounded = false;
    float hInput;
    Animator animator;
    void Start()
    {

        myBody = this.GetComponent<Rigidbody2D>();
        myTrans = this.transform;
        tagGround = GameObject.Find(this.name + "/tag_ground").transform;
        animator = GetComponent<Animator>();
    }
    void FixedUpdate()
    {
        isGrounded = Physics2D.Linecast(myTrans.position, tagGround.position, playerMask);


#if !UNITY_ANDROID && !UNITY_IPHONE && !UNITY_BLACKBERRY && !UNITY_WINRT || UNITY_EDITOR
        hInput = Input.GetAxisRaw("Horizontal");
        if (Input.GetButtonDown("Jump"))
            Jump();
#endif

        Move(hInput);
        animator.SetFloat("Horisontal", myBody.velocity.x);
        animator.SetFloat("Vertical", myBody.velocity.y);

        animator.SetBool("isGrounded", isGrounded);

    }

    void Move(float horizonalInput)
    {
        if (!canMoveInAir && !isGrounded)
            return;

        Vector2 moveVel = myBody.velocity;
        moveVel.x = horizonalInput * speed;
        myBody.velocity = moveVel;
    }

    public void Jump()
    {
        if (isGrounded)
            myBody.AddForce(jumpVelocity * Vector2.up);
    }

    public void StartMoving(float horizonalInput)
    {
        hInput = horizonalInput;
    }


}

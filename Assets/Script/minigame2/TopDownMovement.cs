using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopDownMovement : MonoBehaviour
{
    //Component
    Rigidbody2D rb;

    //Player
    public float walkSpeed = 4f;
    public float speedLimiter = 0.7f;
    float inputHorizontal;
    float inputVertical;

    public bool facingRight = true;

    public Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
        inputHorizontal = Input.GetAxisRaw("Horizontal");
        inputVertical = Input.GetAxisRaw("Vertical");


        
        
        if (inputHorizontal > 0 && !facingRight)
        {
            Flip();
        }
        if (inputHorizontal < 0 && facingRight)
        {
            Flip();
        }

    }

    private void FixedUpdate()
    {        
        if (inputHorizontal != 0 || inputVertical != 0)
        {
            rb.velocity = new Vector2(inputHorizontal * walkSpeed, inputVertical * walkSpeed);

            if (inputHorizontal != 0 && inputVertical != 0)
            {
                inputHorizontal *= speedLimiter;
                inputVertical *= speedLimiter;
            }
        }
        
        else
        {
            rb.velocity = new Vector2(0, 0);
        }

        if (inputHorizontal == 0 && inputVertical == 0)
        {
            animator.SetFloat("Speed", 0);
        }

        else
        {
            animator.SetFloat("Speed", 1);
        }


    }

    void Flip ()
    {
        facingRight = !facingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }


}
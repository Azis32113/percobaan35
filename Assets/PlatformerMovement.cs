using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PlatformerMovement : MonoBehaviour
{
    // Start is called before the first frame update
    //Movement
    public float speed;
    public float jump;
    public int jumpCount;
    public int jumpAdder;
    float moveVelocity;

    public bool facingRight = true;
    

    public Animator animator;
    //Grounded Vars
    bool grounded = false;

    void Update()
    {
        //animator controller
        animator.SetFloat("Speed", Mathf.Abs(moveVelocity));

        //HorizonMovement
        moveVelocity = 0;

        //Left Right Movement
        if (Input.GetKey(KeyCode.A))
        {
            moveVelocity = -speed;            
        }

        if (Input.GetKey(KeyCode.A) && facingRight)
        {
            Flip(); 
        }


        if (Input.GetKey(KeyCode.D) )
        {
            moveVelocity = speed;
        }

        if (Input.GetKey(KeyCode.D) && !facingRight)
        {
            Flip();
        }




        //Jumping
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.Z) || Input.GetKeyDown(KeyCode.W))
        {
            if (grounded == true)
            {
                GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, jump);
                jumpCount--;

                if (jumpCount <= 0)
                {
                    grounded = false;
                    jumpCount = jumpAdder;
                }

                
            }
             
        }


        

        GetComponent<Rigidbody2D>().velocity = new Vector2(moveVelocity, GetComponent<Rigidbody2D>().velocity.y);

    }
    //Check if Grounded
    void OnCollisionEnter2D (Collision2D Collision)
    {
        if (Collision.gameObject.CompareTag("Ground"))
        {
            grounded = true;
            
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

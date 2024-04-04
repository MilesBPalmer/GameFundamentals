using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerScript : MonoBehaviour
{
    //when we wish to call Rigidbody2D we can do so with its new name rb2D.
    private Rigidbody2D rb2D;

    //float = decimal point number, they require numebrs to end with 'f' (10.1f) - int = integer, whole number (10) - bool = true or false statement.
    private float moveSpeed;
    private float jumpForce;
    private float moveHorizontal;
    private float moveVertical;

    bool isJumping;

    // Start is called before the first frame update
    void Start()
    {
        //here we assign rb2D to reference the gameObject of this script which in this case is the player and assign its Rigidbody2D to the empty Rigidbody2D container seen above.
        rb2D = gameObject.GetComponent<Rigidbody2D>();

        moveSpeed = 1.5f;
        jumpForce = 20f;
        isJumping = false;
    }

    // Update is called once per frame
    void Update()
    {
        //Input.GetAxisRaw("Horizontal"); is a built in input that dictates when 'A' 'D' '<-' '->' have been pressed move positon -1, 0, 1, in the direction that has been pressed.
        moveHorizontal = Input.GetAxisRaw("Horizontal");
        //Input.GetAxisRaw("Vertical"); is a built in input that dictates when 'W' 'S' '^' 'v' have been pressed move positon -1, 0, 1, in the direction that has been pressed.
        moveVertical = Input.GetAxisRaw("Vertical");
    }

    //Anything that requires physics we do inside fixedupdate.
    private void FixedUpdate()
    {
        //if moveHorizontal is greater than 0.1f move right (|| = OR) if moveHorizontal is less than -0.1f move left.
        if (moveHorizontal > 0.1f || moveHorizontal < -0.1f)
        {
            //add force to our rb2D, then apply a Vector2 (x, y axis movement) then move the character horizontally multiplied by our moveSpeed, with 0f movement of vertical axis.
            //then apply ForceMode2D.Impulse which makes our movement instantanious.
            rb2D.AddForce(new Vector2(moveHorizontal * moveSpeed, 0f), ForceMode2D.Impulse);
        }

        //if the gameObject is NOT jumping and moveVertical is greater than 0.1f jump up, (&& - both of these conditions need to be true to execute code).
        if (!isJumping && moveVertical > 0.1f)
        {
            //add force to our rb2D, then apply a Vector2 (x, y axis movement) with a 0f movement of the horizontal axis, then move our character vertically multiplied by our jumpForce.
            //then apply ForceMode2D.Impulse which makes our movement instantanious.
            rb2D.AddForce(new Vector2(0f, moveVertical * jumpForce), ForceMode2D.Impulse);
        }
    }

    //OnTriggerEnter2D is a premade command within unity that determines whether our collider has collision with another object, which in this case is the "Platform" tag.
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //if collision occurs with our game object tag, check if it is equal to "Platform" then execute the code within the if statement.
        if(collision.gameObject.tag == "Platform")
        {
            //if the gameObject is triggered by the platform then jumping must be set to false because it is stood on a "Platform".
            isJumping = false;
        }
    }

    //OnTriggerExit2D is a premade command within unity that determines whether our collider has exited collision with another object, which in this case is the "Platform" tag.
    private void OnTriggerExit2D(Collider2D collision)
    {
        //if collision no longer occurs with our game object tag, check if it is not equal to "Platform" then execute the code within the if statement.
        if (collision.gameObject.tag == "Platform")
        {
            //if the gameObject is not triggered by the platform then jumping must be set to true because it is no longer stood on a "Platform".
            isJumping = true;
        }
    }

}

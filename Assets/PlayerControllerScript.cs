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

        moveSpeed = 3f;
        jumpForce = 10f;
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
            rb2D.AddForce(new Vector2(moveHorizontal * moveSpeed, 0f), ForceMode2D.Impulse);
        }

        if (moveVertical > 0.1f || moveVertical < -0.1f)
        {
            rb2D.AddForce(new Vector2(0f, moveVertical * jumpForce), ForceMode2D.Impulse);
        }
    }

}

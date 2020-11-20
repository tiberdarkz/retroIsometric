using UnityEngine;

//##############################################################################
//  This script handels the characters movement and animation of the movement
//
//  It does this by getting the Axis of the WASD keys, and storing them in a
//  a vector2. Then using the Vector2 to change the position of the rigidbody.
//  
//  After that we combine it with the animator, and store these values into the
//  parameters. Those paramets then decide what animation to play, setup trough
//  the animator.
//##############################################################################

public class PlayerMovement : MonoBehaviour
{
    #region Movement Variables
    [Header("Movement Variables")]
    [Tooltip("Increase/Decrease the speed of the player")]
    [Range(0f, 5f)]
    public float moveSpeed = 3f;
    #endregion
    #region Private Variables
    Rigidbody2D Rigidbody;
    Animator anim;
    Vector2 movement;
    #endregion

    private void Start() //Run when object spawns
    {
        //Store the RB and the Animator component in their variables
        Rigidbody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }
    void Update() //Runs every frame
    {
        //Add the Axis to the Vector2
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        //Check if we are not standing still, and then update the X and Y of the animator
        if (movement != Vector2.zero)
        {
            anim.SetFloat("Horizontal", movement.x);
            anim.SetFloat("Vertical", movement.y);
        }
        //Update the speed parameter in the animator
        anim.SetFloat("Speed", movement.sqrMagnitude);
    }

    void FixedUpdate() //Runs the same amount of times on any PC
    {
        //Use the Vector2 to update the position of the RB
        Rigidbody.MovePosition(Rigidbody.position + movement * moveSpeed * Time.fixedDeltaTime);
    }
}

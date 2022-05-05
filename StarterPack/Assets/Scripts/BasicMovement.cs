using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class BasicMovement : MonoBehaviour
{
    public float gravityModifier = 2.0f;

    /// <summary>
    /// Movement of the player
    /// </summary>
    [SerializeField]
    private float movementSpeed = 0.0f;

    /// <summary>
    /// Sensibility of the camera, how fast it will move
    /// </summary>
    //[SerializeField]
    //private float camSensibility = 10f;

    [SerializeField]
    private float jumpForce = 10f;


    /// <summary>
    /// RigidBody of the player
    /// </summary>
    private Rigidbody loRigidBody;



    PlayerInputManager playerInputManager;

    private Vector2 movementInput = Vector2.zero;

    public LayerMask whatIsGround;
    public Transform groundPoint;
    public bool isGrounded;

    public bool playerIsAlive = true;

    private void Start()
    {
        loRigidBody = GetComponent<Rigidbody>();

    }

    // Update is called once per frame
    void Update()
    {
        if (!playerIsAlive)
            return;

        MoveCharacter();
        AddGravity();
    }

    private void AddGravity()
    {
        if (loRigidBody.velocity.y < 0.0f && !IsGrounded())
        {
            loRigidBody.velocity = new Vector3(loRigidBody.velocity.x, -9.8f * gravityModifier, loRigidBody.velocity.z);
        }
    }

    public void Move(InputAction.CallbackContext context)
    {
        movementInput = context.ReadValue<Vector2>();

    }

    public void Jump(InputAction.CallbackContext context)
    {
        if (IsGrounded())
        {
            loRigidBody.AddForce(new Vector3(0f, jumpForce, 0f));
        }
    }


    private bool IsGrounded()
    {
        RaycastHit hit;

        if (Physics.Raycast(groundPoint.position, Vector3.down, out hit, .3f, whatIsGround))
        {
            return true;
        }

        return false;
    }

    /// <summary>
    /// Player movement handler.
    /// </summary>
    private void MoveCharacter()
    {
        loRigidBody.velocity = new Vector3(movementInput.x * movementSpeed, loRigidBody.velocity.y, movementInput.y * movementSpeed);
    }
}

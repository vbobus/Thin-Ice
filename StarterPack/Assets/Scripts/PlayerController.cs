using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float gravityModifier = 2.0f;

    public Rigidbody rb;


    [SerializeField] public float moveSpeed = 5.0f;
    [SerializeField] public float jumpForce = 5.0f;


    float rotationSpeed = 45;
    Vector3 currentEulerAngles;
    float x;
    float y = 0;
    float z = 0;


    private Vector2 moveInput;

    public LayerMask whatIsGround;
    public Transform groundPoint;
    public bool isGrounded;

    //[SerializeField] ParticleSystem runningParticles;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
       movePlayer();
       jumpPlayer();
    }

    void movePlayer()
    {
        moveInput.x=Input.GetAxis("Horizontal");
        moveInput.y=Input.GetAxis("Vertical");
        moveInput.Normalize();


        if(Mathf.Abs(moveInput.x) > 0f)
        {
            transform.Rotate(0f,0f,0.5f);
            transform.Rotate(0f,0f,-0.5f);
        }

        rb.velocity=new Vector3(moveInput.x*moveSpeed, rb.velocity.y, moveInput.y*moveSpeed);
    }


    void jumpPlayer()
    {
        RaycastHit hit;

        if(Physics.Raycast(groundPoint.position, Vector3.down, out hit, .3f, whatIsGround))
        {
            isGrounded = true;
        }
        else
        {
            isGrounded=false;
        }

        if(Input.GetButtonDown("Jump") && isGrounded)
        {
            rb.velocity += new Vector3(0f, jumpForce, 0f);
            if(rb.velocity.y < 0.0f)
             {
             rb.velocity = new Vector3(rb.velocity.x, 9.8f* gravityModifier, rb.velocity.z);
            } 
        } 
    }

    //<< 
    void slidePlayer()
    {
        
         if(Input.GetKeyDown(KeyCode.LeftShift) && isGrounded)
         {
             x=60;
             currentEulerAngles += new Vector3(x, y, z) * Time.deltaTime * rotationSpeed;
             transform.eulerAngles = currentEulerAngles;
         }
         else if(Input.GetKeyUp(KeyCode.LeftShift))
         {
             x=-60;
             currentEulerAngles += new Vector3(x, y, z) * Time.deltaTime * rotationSpeed;
             transform.eulerAngles = currentEulerAngles;
         }

    }
}
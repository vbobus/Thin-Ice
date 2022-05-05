using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ParticleEffects : MonoBehaviour
{
    public bool isGrounded;
    public Transform groundPoint;
    public LayerMask whatIsGround;

    public ParticleSystem explosionParticles;
    public ParticleSystem runningParticles;
    public ParticleSystem splashParticles;

    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame

    void Update()
    {
        groundCheck();
        if(Input.GetButtonDown("Jump") && isGrounded==true)
        {
            runningParticles.Stop();
        }
    }

    void groundCheck()
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
    }

    private void OnCollisionEnter(Collision other) 
    {
        if(other.gameObject.CompareTag("Obstacle"))
        {
            explosionParticles.Play();
        }
        else if(other.gameObject.CompareTag("Water"))
        {
            splashParticles.Play();

        }

        if(isGrounded==true)
        {
            runningParticles.Play();
        }
        else if(other.gameObject.CompareTag("Obstacle"))
        {
            runningParticles.Stop();
        }
    }
}

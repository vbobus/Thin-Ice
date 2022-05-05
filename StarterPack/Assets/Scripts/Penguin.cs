using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Penguin : MonoBehaviour
{

    public int playerNumber;
    public ParticleSystem explosionParticles;
    public ParticleSystem runningParticles;
    public ParticleSystem splashParticles;
    public SpriteRenderer playerSprite;

    private Animator loAnim;

    private void Start()
    {
        playerNumber = GameManager.instance.AddPenguin(this);

        loAnim = GetComponent<Animator>();

        loAnim.SetInteger("State", playerNumber);
    }

 
    public void KillPenguin()
    {
        GetComponent<BasicMovement>().playerIsAlive = false;
        playerSprite.enabled = false;
        GameManager.instance.DeadPenguin(this);
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Obstacle"))
        {
            KillPenguin();
        }


        else if (other.gameObject.CompareTag("Water"))
        {
            splashParticles.Play();

        }
    }
}

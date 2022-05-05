using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class O_BlockEffectController : MonoBehaviour
{
    [Range(0, 1000)]
    public float moveForward;
    [Range(0, 1000)]
    public float moveBackward;
    [Range(0, 1000)]
    public float jumpForce;



    private void OnCollisionStay(Collision collision)
    {
        if(collision.gameObject.TryGetComponent(out BasicMovement playerMovement))
        {
            Rigidbody rb = playerMovement.GetComponent<Rigidbody>();

            if(rb != null)
                rb.AddForce(Vector3.forward * moveForward);
            if (rb != null)
                rb.AddForce(Vector3.back * moveBackward);
            if (rb != null)
                rb.AddForce(Vector3.up * jumpForce);
        }
    }
}

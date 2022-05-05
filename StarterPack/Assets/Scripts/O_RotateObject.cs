using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class O_RotateObject : MonoBehaviour
{
    [SerializeField] private int speed = 1;

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(0f, speed, 0f) * Time.deltaTime);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class O_Geyser : MonoBehaviour
{
    [SerializeField] Vector3 movemnetVector = new Vector3(0f, 0f, 0f);
    float movementFactor;

    [SerializeField] float timePeriod = 4f; // each cycle will be 4 seconds long

    Vector3 startingpos;

    // Initialize starting position
    void Start()
    {
        startingpos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (timePeriod <= 0f) { return; }
        float cycles = Time.time / timePeriod;

        const float tau = Mathf.PI * 2;
        float rawSineWave = Mathf.Sin(cycles * tau);

        movementFactor = rawSineWave / 2f + 0.5f;

        Vector3 offset = movemnetVector * movementFactor;
        transform.position = startingpos + offset;
    }
}


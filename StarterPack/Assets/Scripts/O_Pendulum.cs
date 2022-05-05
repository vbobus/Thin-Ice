using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class O_Pendulum : MonoBehaviour
{
    [SerializeField, Range(0f, 360f)] 
    private float _angle = 90f;
    [SerializeField, Range(0f, 5f)] 
    private float _speed = 2f;

    [SerializeField, Range(0f, 10f)]
    private float startTime = 0f;
    Quaternion _start, _end;

    Quaternion PendulumUpdate(float angle)
    {
        var pendulumRotation = transform.rotation;
        var angleZ = pendulumRotation.eulerAngles.z + angle;

        if (angleZ > 180)
        {
            angleZ -= 360;
        }
        else if(angleZ <180)
        {
            angleZ += 360;
        }
        pendulumRotation.eulerAngles = new Vector3(pendulumRotation.eulerAngles.x, pendulumRotation.eulerAngles.y, angleZ);
        return pendulumRotation;
    }

    void resetTimer()
    {
        startTime = 0f;
    }
    // Start is called before the first frame update
    void Start()
    {
        _start = PendulumUpdate(_angle);
        _end = PendulumUpdate(-_angle);
    }

    private void FixedUpdate()
    {
        startTime += Time.deltaTime;
        transform.rotation = Quaternion.Lerp(_start, _end,(Mathf.Sin(startTime * _speed + Mathf.PI / 2) + 1f) / 2f);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
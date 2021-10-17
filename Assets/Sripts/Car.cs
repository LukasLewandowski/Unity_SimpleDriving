using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car : MonoBehaviour
{
    [SerializeField] private float speed = 10f;
    [SerializeField] private float speedGainedPerSecond = 0.2f;

    // Update is called once per frame
    void Update()
    {
        /** * Time.deltaTime it's how long since the last frame */
        speed = speed + speedGainedPerSecond * Time.deltaTime;
        transform.Translate(Vector3.forward * speed * Time.deltaTime);   
    }
}

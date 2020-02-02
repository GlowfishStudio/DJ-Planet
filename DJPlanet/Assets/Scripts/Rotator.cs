using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{
    public int initialAngle = 5;
    public int rotationSpeed = 20;

    void Start()
    {
        transform.Rotate(0, 0, initialAngle);
        SpriteRenderer sr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, 0, rotationSpeed * Time.deltaTime);
    }
}
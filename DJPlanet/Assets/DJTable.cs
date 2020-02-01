using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DJTable : MonoBehaviour
{
    public float scratchSpeed = 70;
    private bool isDragging = false;
    private Vector3 dragStart;
    private float prevDistance;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            isDragging = true;

            dragStart = Input.mousePosition;
            prevDistance = 0;
        }

        if (Input.GetMouseButtonUp(0))
        {
            isDragging = false;
        }

        if (isDragging)
        {
            float distance = Vector3.Distance(dragStart, Input.mousePosition);

            float distanceChange = prevDistance - distance;

            Debug.Log(distanceChange);

            transform.Rotate(0, 0, scratchSpeed * distanceChange * Time.deltaTime);

            prevDistance = distance;
        }
    }
}

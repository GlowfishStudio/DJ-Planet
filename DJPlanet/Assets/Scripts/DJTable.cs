using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//our input class for gameplay
public class DJTable : MonoBehaviour
{
    public float scratchSpeed = 70;
	public ScratchSoundsController scratchSoundController;
	public float scratchSoundMinRotation = 5f;

    private bool isDragging = false;
    private Vector3 dragStart;
    private float prevDistance;

    // Use this for initialization
    void Start() {

    }

    // Update is called once per frame
    void Update()
    {
        float scrollValue = GetScrollWheelInput();
        if (scrollValue != 0.0f) {
            isDragging = false;
            int scrollFactor = (scrollValue > 0) ? 1 : -1;  //is it positive or negative

            rotateWorld(scrollFactor * 35);

            scrollValue = 0.0f;
            return;
        }

        GetMouseDragInput();
    }

    private void GetMouseDragInput() {

        if (Input.GetMouseButtonDown(0)) {
            isDragging = true;

            dragStart = Input.mousePosition;
            prevDistance = 0;
        }

        if (Input.GetMouseButtonUp(0)) {
            isDragging = false;
        }

        if (isDragging) {
            float distance = Vector3.Distance(dragStart, Input.mousePosition);

            float distanceChange = prevDistance - distance;

            rotateWorld(distanceChange);

            prevDistance = distance;
        }
    }

    private float GetScrollWheelInput() {
        return Input.GetAxis("Mouse ScrollWheel");
    }

    private void rotateWorld(float howMuch)
    {
        transform.Rotate(0, 0, howMuch * scratchSpeed * Time.deltaTime);

        if (howMuch > scratchSoundMinRotation)
        {
            scratchSoundController.playScratchSound();
        }
    }
}

﻿using UnityEngine;
using System.Collections;
using Unity.IO;

public class InputManager : MonoBehaviour {

    // Use this for initialization
    void Start() {

    }

    // Update is called once per frame
    void Update() {
        Debug.Log("SCROLL WHEEL: " + GetScrollWheelInput());
    }

    private float GetScrollWheelInput() {
        return Input.GetAxis("Mouse ScrollWheel");
    }
}

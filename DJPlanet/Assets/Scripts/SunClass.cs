using UnityEngine;
using System.Collections;

public class SunClass : MonoBehaviour {
    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Sub colllided with");
        Debug.Log(other);
    }
}

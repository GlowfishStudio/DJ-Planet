using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DJTwo : MonoBehaviour
{
    Vector3 startPosition;

    private void OnDrawGizmos() {
        Gizmos.DrawWireSphere(startPosition,1);
    }

    private void Update() {
        
        if (Input.GetMouseButtonDown(0)) {
            startPosition = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x,Input.mousePosition.y,Camera.main.nearClipPlane));
        }
        if (Input.GetMouseButton(0)){
            
        }
        startPosition = Vector3.Lerp(startPosition, new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.nearClipPlane), Time.deltaTime);

    }
}

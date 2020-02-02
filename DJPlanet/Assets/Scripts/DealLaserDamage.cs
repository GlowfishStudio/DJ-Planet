using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DealLaserDamage : MonoBehaviour
{
    Collider2D Collider;
    
    // Start is called before the first frame update
    void Awake()
    {
        Collider = this.GetComponent<Collider2D>();
    }

    void OnTriggerEnter2D(Collider2D other) {
        var destructableObject = other.GetComponent<DestructableObjectClass>();
        if(destructableObject != null && destructableObject.Health > 0) {
            destructableObject.Health--;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DealLaserDamage : MonoBehaviour
{
    Collider2D Collider;
    GameController GC;
    
    // Start is called before the first frame update
    void Awake()
    {
        Collider = this.GetComponent<Collider2D>();
        GC = FindObjectOfType<GameController>();
    }

    void OnTriggerEnter2D(Collider2D other) {
        var destructableObject = other.GetComponent<DestructableObjectClass>();
        if(destructableObject != null && destructableObject.Health > 0) {
            destructableObject.dealDamage();
            if (other.GetComponent<PlanetClass>() == null) {
                GC.IncrementScore(100);
            }
        }
    }
}

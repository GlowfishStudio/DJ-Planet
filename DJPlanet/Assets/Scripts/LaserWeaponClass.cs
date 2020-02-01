using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class LaserWeaponClass : MonoBehaviour {

    public List<Vector2> FireDirections;

    private bool CanFire = true;

    public virtual void Awake() {
        CanFire = true;
    }

    public virtual void Update() {

    }

    public virtual bool FireLaser() {

        if (CanFire) {
            CanFire = false;     //TODO: Make sure after animation is over, CanFire = true
            foreach (var fireDirection in FireDirections) {
                //TODO: play laser animation if we can shoot here
                var hit = Physics2D.Raycast(this.transform.position, fireDirection);
                if (hit && hit.collider != null && hit.collider.GetComponent<DestructableObjectClass>()) {
                    var otherObject = hit.collider.GetComponent<DestructableObjectClass>();
                    if (otherObject.Health > 0) {
                        otherObject.Health -= 1;
                    }
                }
            }
            return true;
        }
        return false;
    }
}

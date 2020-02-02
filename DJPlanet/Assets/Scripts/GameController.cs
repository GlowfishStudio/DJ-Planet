using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {
    [HideInInspector]
    public float TimeToFire;
    public float IntervalToFire;

    public GameObject GunsContainer;
    
    void Awake() {
        TimeToFire = IntervalToFire;
    }
    
    void Update() {
        ProcessTimeToFire();
    }

    private void ProcessTimeToFire() {
        TimeToFire -= Time.deltaTime;
        if(TimeToFire <= 0.0) {
            foreach(var gun in GunsContainer.GetComponentsInChildren<LaserWeaponClass>()) {
                gun.FireLaser();
                TimeToFire = IntervalToFire;
            }
        }
    }
}

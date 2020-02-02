using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class LaserWeaponClass : MonoBehaviour {
    
    public GameObject LaserBeam;
    public float LaserSize = 1;
    public int FramesForLaser = 3;
    private int RemainingLaserFrames = 0;

    private bool CanFire = true;

    public virtual void Awake() {
        CanFire = true;
        LaserBeam.SetActive(false);
    }

    public virtual void Update() {
        if(RemainingLaserFrames > 0) {
            RemainingLaserFrames--;
        }

        if (Input.GetKeyDown("space")) {
            FireLaser();
        }

        if(RemainingLaserFrames == 0) {
            LaserBeam.SetActive(false);
            CanFire = true;
        }
        else {
            LaserBeam.SetActive(true);
        }
    }

    public virtual bool FireLaser() {

        if (CanFire) {
            CanFire = false;     //TODO: Make sure after animation is over, CanFire = true
            //TODO: play laser animation if we can shoot here
            LaserBeam.SetActive(true);
            RemainingLaserFrames = FramesForLaser;

            return true;
        }
        return false;
    }
}

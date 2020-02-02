using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameController : MonoBehaviour {

    [HideInInspector]
    public int Score;
    public GameObject Scoreboard;
    private GameObject ScoreboardInstance;

    [HideInInspector]
    public float TimeToFire;
    public float IntervalToFire;
    public GameObject GunsContainer;

    public GameObject AsteroidContainer;
    private GameObject[] Asteroids;
    public int NumberInWave = 2;
    private int AsteroidIndex = 0;
    
    void Awake() {
        Score = 0;
        ScoreboardInstance = GameObject.Instantiate(Scoreboard);
        ScoreboardInstance.GetComponent<TextMesh>().text = Score.ToString();
        TimeToFire = IntervalToFire;
        //Asteroids = AsteroidContainer.GetComponentsInChildren<GameObject>();
        //foreach(var asteroid in Asteroids) {
        //    asteroid.SetActive(false);
        //}
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

    //private void EnableAsteroids() {
    //    int limit = AsteroidIndex + NumberInWave;
    //    for(int i=AsteroidIndex; i < limit; i++) {
    //        if(i >= Asteroids.Length) {
    //            break;
    //        }

    //        var asteroid = Asteroids[i];
    //        asteroid.SetActive(true);
    //    }
    //}

    public void IncrementScore(int addValue) {
        Score += addValue;
        ScoreboardInstance.GetComponent<TextMesh>().text = Score.ToString();
    }
}

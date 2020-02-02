using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleTimer : MonoBehaviour
{
    public float counter;
    public float countAmount;

    public GameObject toTurnOff;
    public GameObject toTurnOn;
    // Start is called before the first frame update
    void Start()
    {
        counter = 0;
    }

    // Update is called once per frame
    void Update()
    {
        counter += Time.deltaTime;

        if (counter >= countAmount) {
            toTurnOff.SetActive(false);
            toTurnOn.SetActive(true);
        }
    }
}

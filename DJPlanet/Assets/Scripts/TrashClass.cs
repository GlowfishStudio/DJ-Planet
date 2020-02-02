using UnityEngine;
using System.Collections;

public class TrashClass : DestructableObjectClass {

    private Vector2 StartPosition;
    public Vector2 EndPosition = Vector2.zero;
    private float StartTime;

    public float Fraction = 0.0f;
    public float Velocity = 10f;

    private void Start() {

        StartTime = Time.deltaTime;
    }

    protected override void Awake() {
        base.Awake();
        StartPosition = this.transform.localPosition;
        Velocity *= Random.Range(0.75f, 1.0f);   //So not every obstacle moves exactly the same speed
    }

    // Update is called once per frame
    protected override void Update() {
        base.Update();

        if (Fraction < 1) {
            Fraction += Time.deltaTime * Velocity;
            transform.localPosition = Vector3.Lerp(StartPosition, EndPosition, Fraction);
        }
    }

    protected override void DestroyObject() {
        base.DestroyObject();
    }
}

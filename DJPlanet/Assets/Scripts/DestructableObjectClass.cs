using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestructableObjectClass : MonoBehaviour
{
    public int MaxHealth = 3;
    public int Health;

    private bool IsDestroyed = false;

    Rigidbody2D _Rigidbody;
    Animator _Animator;
    Collider _Collider;

    protected virtual void Awake()
    {
        _Rigidbody = this.GetComponent<Rigidbody2D>();
        _Animator = this.GetComponentInChildren<Animator>();
        _Collider = this.GetComponentInChildren<Collider>();

        this.IsDestroyed = false;
        this.Health = MaxHealth;
    }

    // Update is called once per frame
    protected virtual void Update()
    {
        if(Health == 0 && IsDestroyed == false) {
            DestroyObject();
            return;
        }
    }

    private void OnCollisionEnter(Collision collision) {
        if(collision.gameObject.GetComponent<PlanetClass>() != null
            || collision.gameObject.GetComponent<SunClass>() != null) {

            this.Health = 0;
        }
    }

    private void DestroyObject() {
        IsDestroyed = true;

        //TODO: play death animation or effect here
    }
}

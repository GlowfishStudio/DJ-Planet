using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestructableObjectClass : MonoBehaviour
{
    public int MaxHealth = 3;
    [HideInInspector]
    public int Health;

    Color healthyColor = Color.white;
    Color damagedColor = Color.black;

    private bool IsDestroyed = false;

    Rigidbody2D _Rigidbody;
    Animator _Animator;
    Collider _Collider;

    SpriteRenderer m_SpriteRenderer;

    protected virtual void Awake()
    {
        _Rigidbody = this.GetComponent<Rigidbody2D>();
        _Animator = this.GetComponentInChildren<Animator>();
        _Collider = this.GetComponentInChildren<Collider>();

        this.IsDestroyed = false;
        this.Health = MaxHealth;
    }

    protected virtual void Start()
    {
        //Fetch the SpriteRenderer from the GameObject
        m_SpriteRenderer = GetComponent<SpriteRenderer>();

        m_SpriteRenderer.color = healthyColor;
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

    protected virtual void DestroyObject() {
        IsDestroyed = true;
        //TODO: Add points for player
        //TODO: play death animation or effect here
        Destroy(this.gameObject);
    }

    public void dealDamage()
    {
        this.Health--;

        float damageRatio = (float)this.Health / (float)this.MaxHealth;

        Color currentColor = new Color(
            (healthyColor.r - damagedColor.r) * damageRatio + damagedColor.r,
            (healthyColor.g - damagedColor.g) * damageRatio + damagedColor.g,
            (healthyColor.b - damagedColor.b) * damageRatio + damagedColor.b
            );

        m_SpriteRenderer.color = currentColor;
    }
}

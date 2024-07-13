using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthController : MonoBehaviour
{
    [SerializeField] float health;
    bool isDead;
    public float sat;

    public Rigidbody2D rb;
    public void TakeDamage(float amount)
    {
        health -= amount;
        CheckHealth();
    }
    public void CheckHealth()
    {
        if (health < 0 && !isDead)
        {
            isDead = true;
            Die();
        }
    }
    void Update()
    {
        
    }

    public void Die()
    {
        print("�ld�");
    }
    void OnParticleCollision(GameObject other)
    {
        TakeDamage(.1f);
        print("azzzuuuuuuuuuuuuu");
    }
    void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.layer==LayerMask.NameToLayer("takeDamage"))
        {
            TakeDamage(1);
            GetComponent<SpriteRenderer>().color = Color.red;
            Vector2 vec=transform.position-other.transform.position;
            GetComponent<PlayerMovementController>().enabled=false;

            GetComponent<Rigidbody2D>().AddForce(vec*sat,ForceMode2D.Impulse);
            Invoke(nameof(finitoAzuuu),.2f);
        }
    }

    void finitoAzuuu()
    {
        GetComponent<SpriteRenderer>().color = Color.white;
        GetComponent<PlayerMovementController>().enabled=true;


    }
    
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthController : MonoBehaviour
{
    [SerializeField] float health;
    bool isDead;

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
    public void Die()
    {
        print("Öldü");
    }
}

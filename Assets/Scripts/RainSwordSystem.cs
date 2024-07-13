using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RainSwordSystem : MonoBehaviour
{
    public float attractionForce = 10f;
    public float damage = 10f;
    // Start is called before the first frame update
    void Start()
    {

    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            Rigidbody2D rb = collision.GetComponent<Rigidbody2D>();
            Vector2 direction = (transform.position - collision.transform.position).normalized;
            rb.AddForce(direction * attractionForce);
            //
            Vector2 hitPoint = transform.position; // Mermi temas ettiði nokta
            //
            Debug.Log("Enemy hitted");
        }

   
    }
}

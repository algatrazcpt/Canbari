using UnityEngine;

public class PlayerControllerTest : MonoBehaviour
{
    public float speed = 5f; // Oyuncu h�z�

    void Update()
    {
        // Oyuncunun hareket etmesi
        float moveHorizontal = Input.GetAxis("Horizontal"); // Sa�a/sola hareket i�in giri� al
        float moveVertical = Input.GetAxis("Vertical"); // Yukar�/a�a�� hareket i�in giri� al

        // Hareket vekt�r� olu�tur
        Vector2 moveDirection = new Vector2(moveHorizontal, moveVertical) * speed * Time.deltaTime;

        // Pozisyonu g�ncelle
        transform.Translate(moveDirection);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag=="mud")
        {
            print("değdi");
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.tag=="mud")
        {
            print("değdi coll");
        }
    }
}

using UnityEngine;

public class PlayerControllerTest : MonoBehaviour
{
    public float speed = 5f; // Oyuncu hýzý

    void Update()
    {
        // Oyuncunun hareket etmesi
        float moveHorizontal = Input.GetAxis("Horizontal"); // Saða/sola hareket için giriþ al
        float moveVertical = Input.GetAxis("Vertical"); // Yukarý/aþaðý hareket için giriþ al

        // Hareket vektörü oluþtur
        Vector2 moveDirection = new Vector2(moveHorizontal, moveVertical) * speed * Time.deltaTime;

        // Pozisyonu güncelle
        transform.Translate(moveDirection);
    }
}

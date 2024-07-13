using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCustomSkilss : MonoBehaviour
{
    // Start is called before the first frame update
    public bool swordRainCoolDown = false;
    public float spawnRange = 0.5f;
    public int numberOfObjects = 5;
    public GameObject objectPrefab;
    public float moveSpeed;
    public float spawnHeight = 1f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Alpha9))
        {
            if (!swordRainCoolDown)
            {
                StartCoroutine("RainSword");
            }
        }
    }
    IEnumerator RainSword()
    {
        
        swordRainCoolDown = true;
        for (int i = 0; i < numberOfObjects; i++)
        {
            // Nesnenin oluþturulma süresini rastgele belirle
            float spawnDelay = Random.Range(0.01f, spawnRange);
            yield return new WaitForSeconds(spawnDelay);

            Vector3 spawnPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            // Nesnenin oluþturulacaðý yeri belirle
            // Vector3 spawnPosition = new Vector3(Random.Range(-spawnRange, spawnRange), spawnHeight, 0f);
            spawnPosition.z = 0f;
            // Nesneyi oluþtur
            GameObject newObj = Instantiate(objectPrefab, new Vector3(spawnPosition.x, spawnPosition.y + spawnHeight, 0), Quaternion.identity);

            // Nesneye bir Rigidbody bileþeni ekle
            Rigidbody2D rb = newObj.AddComponent<Rigidbody2D>();
            rb.gravityScale = 0f; // Nesnelerin yerçekimi etkisi olmasýn
            newObj.GetComponent<BoxCollider2D>().enabled = false;
            // Nesneyi aþaðýya doðru hareket ettir
            rb.velocity = Vector2.down * Random.Range(moveSpeed - 1, moveSpeed + 4);
            StartCoroutine(CheckReachedTargetSwordRain(rb, spawnPosition));
        }
        yield return new WaitForSeconds(5);
        swordRainCoolDown = false;
    }
    IEnumerator CheckReachedTargetSwordRain(Rigidbody2D rb, Vector3 targetPosition)
    {
        while (true)
        {
            if (Vector2.Distance(rb.position, targetPosition) < 0.15f)
            {
                rb.GetComponent<Animator>().SetTrigger("SwordGroundT");
                rb.velocity = Vector2.zero;
                rb.GetComponent<BoxCollider2D>().enabled = true;
                //rb.GetComponent<PlayerSwordRain>().damage = 10f;
                Destroy(rb.gameObject, 0.5f);

                Debug.Log("Hedefe Varýldý");
                break;
            }
            yield return null;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCustomSkilss : MonoBehaviour
{
    // Start is called before the first frame update
    public bool swordRainCoolDown = false;
    public GameObject Sword;
    public Sprite swordRainIcon;
    public GameObject swordRainPreafab;
    public float swordRainSpeed = 8;
    public float swordSpawnInterval = 0.2f;
    public float swordRainCount = 10;
    public float swordRainSpawnRange = 0.5f;
    public float swordRainSpawnHeight = 2f;

    public GameObject[] allLaser;

    int currentLaser = 0;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Player skiill key numpad dýþý 9
        if (Input.GetKeyDown(KeyCode.Alpha9))
        {
            if (!swordRainCoolDown)
            {
                StartCoroutine("RainSword");
            }
        }
        if(Input.GetKeyDown(KeyCode.Alpha8))
        {
            //kristal bulununca
            allLaser[currentLaser].GetComponent<Animator>().SetTrigger("LaserFire");
            if (currentLaser + 1 < 4)
            {
                currentLaser++;
            }
            else
            {
                //laser failed
            }
        }
    }












    IEnumerator RainSword()
    {
        for (int i = 0; i < swordRainCount; i++)
        {
            // Nesnenin oluþturulma süresini rastgele belirle
            float spawnDelay = Random.Range(0.01f, swordRainSpawnRange);
            yield return new WaitForSeconds(spawnDelay);

            Vector3 spawnPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            // Nesnenin oluþturulacaðý yeri belirle
            // Vector3 spawnPosition = new Vector3(Random.Range(-spawnRange, spawnRange), spawnHeight, 0f);
            spawnPosition.z = 0f;
            // Nesneyi oluþtur
            GameObject newObj = Instantiate(swordRainPreafab, new Vector3(spawnPosition.x, spawnPosition.y + swordRainSpawnHeight, 0), Quaternion.identity);

            // Nesneye bir Rigidbody bileþeni ekle
            Rigidbody2D rb = newObj.AddComponent<Rigidbody2D>();
            rb.gravityScale = 0f; // Nesnelerin yerçekimi etkisi olmasýn
            newObj.GetComponent<BoxCollider2D>().enabled = false;
            // Nesneyi aþaðýya doðru hareket ettir
            rb.velocity = Vector2.down * Random.Range(swordRainSpeed - 1, swordRainSpeed + 4);
            StartCoroutine(CheckReachedTargetSwordRain(rb, spawnPosition));
        }
    }
    IEnumerator CheckReachedTargetSwordRain(Rigidbody2D rb, Vector3 targetPosition)
    {
        while (true)
        {
            if (Vector2.Distance(rb.position, targetPosition) < 0.15f)
            {
                ScreenShacker.instance.ShakeSystem(1f, 10, 0.15f);
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

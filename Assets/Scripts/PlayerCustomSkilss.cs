using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using DG.Tweening;
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

    [Header("Transition")]
    public CinemachineVirtualCamera cam;
    public Transform pos;

    public float traTime=3,camSize=9;
    [Header("Voice")]
    public AudioSource voice;
    public AudioClip first,last;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Player skiill key numpad d��� 9
        if (Input.GetKeyDown(KeyCode.Alpha9))
        {
            if (!swordRainCoolDown)
            {
            }
        }

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag=="Player")
        {
            //if(other.GetComponent<PlayerHealthController>().crystalCount>=6)
            
            print(other.GetComponent<PlayerHealthController>().crystalCount);
            DOTween.To(() => cam.m_Lens.OrthographicSize, x => cam.m_Lens.OrthographicSize = x, camSize, traTime).OnComplete(()=>{
                foreach (var item in allLaser)
                {   
                    item.GetComponent<Animator>().SetTrigger("LaserFire");
                    //StartCoroutine(RainSword(pos.position));
                    StartCoroutine(PlayAudioClipsSequentially());
                    
                    
                }
                cam.Follow=pos;

            });
            
        }
        
    }


    IEnumerator PlayAudioClipsSequentially()
    {
        voice.clip = first;
        voice.Play();
        yield return new WaitForSeconds(voice.clip.length);
        voice.loop=true;

        voice.clip = last;
        voice.Play();
    }



    IEnumerator RainSword(Vector2 pos)
    {
        for (int i = 0; i < swordRainCount; i++)
        {
            // Nesnenin olu�turulma s�resini rastgele belirle
            float spawnDelay = Random.Range(0.01f, swordRainSpawnRange);
            yield return new WaitForSeconds(spawnDelay);

            Vector3 spawnPosition = pos+new Vector2(Random.Range(-7.5f,7.5f),Random.Range(1,-1));

            // Nesnenin olu�turulaca�� yeri belirle
            // Vector3 spawnPosition = new Vector3(Random.Range(-spawnRange, spawnRange), spawnHeight, 0f);
            spawnPosition.z = 0f;
            // Nesneyi olu�tur
            GameObject newObj = Instantiate(swordRainPreafab, new Vector3(spawnPosition.x, spawnPosition.y + swordRainSpawnHeight, 0), Quaternion.identity);

            // Nesneye bir Rigidbody bile�eni ekle
            Rigidbody2D rb = newObj.AddComponent<Rigidbody2D>();
            rb.gravityScale = 0f; // Nesnelerin yer�ekimi etkisi olmas�n
            newObj.GetComponent<BoxCollider2D>().enabled = false;
            // Nesneyi a�a��ya do�ru hareket ettir
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
                Debug.Log("Hedefe Var�ld�");
                break;
            }
            yield return null;
        }
    }
}

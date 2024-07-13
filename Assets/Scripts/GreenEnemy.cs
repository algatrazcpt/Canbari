using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;
using DG.Tweening;

public class GreenEnemy : MonoBehaviour
{
    
    private AIDestinationSetter enemyAI;
    private AIPath path;
    private PlayerMovementController player;

    public ParticleSystem attackMud;
    public float timer,finalTimer,health=100;

    private Vector2 direc;
    private float lookAngle;
    Animator anim;
    bool isSee;
    Rigidbody2D rb;

    void Start()
    {
        enemyAI=GetComponent<AIDestinationSetter>();
        rb=GetComponent<Rigidbody2D>();
        path=GetComponent<AIPath>();
        player=FindObjectOfType<PlayerMovementController>();
        anim=GetComponent<Animator>();
        enemyAI.target=player.transform;
    }

    void Update()
    {
        float dis=Vector2.Distance(transform.position,player.transform.position);
        isSee=(dis<5)?true:false;
        if(isSee)
        {
            timer+=Time.deltaTime;
            if(dis>2.5 )
            {
                path.canMove=true;

            }
            else
            {
                path.canMove=false;
                if(timer>finalTimer)
                {
                    timer=0;
                    anim.SetTrigger("Attack");
                    print("sdasda");
                }
            }
        }
        else
        path.canMove = false;
        
    }

    public void attack()
    {
        attackMud.Play();
        direc=player.transform.position-attackMud.transform.position;
        lookAngle=Mathf.Atan2(direc.y,direc.x)*Mathf.Rad2Deg;
        attackMud.transform.rotation=Quaternion.Euler(lookAngle+180,-90,-90);

    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag=="sword")
        {
            Vector2 vec=transform.position-other.transform.position;
            rb.isKinematic=false;
            rb.AddForce(vec*10,ForceMode2D.Impulse);
            Invoke(nameof(finitoAzuuu),.2f);

            health-=25;
            print("Değidi");
            if(health<=0)
            {
                transform.DOScale(Vector2.zero,1).OnComplete(()=>{
                    gameObject.SetActive(false);
                });
            }
        }
    }

     void finitoAzuuu()
    {
            rb.isKinematic=true;    
            rb.velocity=Vector2.zero;


    }

   
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;
using Unity.Mathematics;

public class skeletonEnemy : MonoBehaviour
{


    private AIDestinationSetter enemyAI;
    private AIPath path;
    private PlayerMovementController player;
    public float timer,finalTimer,speed,health=100;
    private Vector2 direc;
    Animator anim;
    public Transform pos;
    public GameObject head;
    public bool isSee;

    Rigidbody2D rb;
    void Start()
    {
        enemyAI=GetComponent<AIDestinationSetter>();
        path=GetComponent<AIPath>();
        player=FindObjectOfType<PlayerMovementController>();
        anim=GetComponent<Animator>();
        rb=GetComponent<Rigidbody2D>();
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

    public void attacksss()
    {
        
        GameObject heads=Instantiate(this.head,pos.position,quaternion.identity);
        Vector2 direc=heads.transform.position-player.transform.position;
        float dis=Mathf.Atan2(direc.y,direc.x)*Mathf.Rad2Deg;
        heads.transform.rotation=Quaternion.Euler(0,0,dis);
        heads.GetComponent<Rigidbody2D>().velocity=-heads.transform.right*speed;
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
            if(health<=80)
            {
                anim.SetTrigger("die");
            }
        }
    }

     void finitoAzuuu()
    {
        rb.isKinematic=true;    
        rb.velocity=Vector2.zero;


    }
    public void die()
    {
        GetComponent<Collider2D>().enabled=false;
        path.enabled=false;
        enemyAI.enabled=false;
    }

}

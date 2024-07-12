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
    public float timer,finalTimer,speed;
    private Vector2 direc;
    Animator anim;
    public Transform pos;
    public GameObject head;
    bool isAttack;
    void Start()
    {
        enemyAI=GetComponent<AIDestinationSetter>();
        path=GetComponent<AIPath>();
        player=FindObjectOfType<PlayerMovementController>();
        anim=GetComponent<Animator>();
        enemyAI.target=player.transform;
    }

    void Update()
    {
        float dis=Vector2.Distance(transform.position,player.transform.position);
        
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

            }
        }
    }

    public void attacksss()
    {
        GameObject heads=Instantiate(this.head,pos.position,quaternion.identity);
        Vector2 direc=heads.transform.position-player.transform.position;
        float dis=Mathf.Atan2(direc.y,direc.x)*Mathf.Rad2Deg;
        heads.transform.rotation=Quaternion.Euler(0,0,dis);
        heads.GetComponent<Rigidbody2D>().velocity=-heads.transform.right*speed;
    }

}

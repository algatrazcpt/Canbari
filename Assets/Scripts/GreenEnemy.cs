using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class GreenEnemy : MonoBehaviour
{
    
    private AIDestinationSetter enemyAI;
    private AIPath path;
    private PlayerMovementController player;

    public ParticleSystem attackMud;
    public float timer,finalTimer;

    private Vector2 direc;
    private float lookAngle;
    Animator anim;
    bool isSee;

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

   
}
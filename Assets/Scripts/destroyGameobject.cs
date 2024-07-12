using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroyGameobject : MonoBehaviour
{
    public float timer=3;

    public bool isObj;

    void OnTriggerEnter2D(Collider2D other)
    {
        if(isObj && other.gameObject.layer==LayerMask.NameToLayer("wall"))
        {
            GetComponent<Collider2D>().isTrigger=false;
            GetComponent<Rigidbody2D>().isKinematic=false;
            Invoke(nameof(finito),Random.Range(0.2f,.4f));
        }
    }
    void finito()
    {
        GetComponent<Rigidbody2D>().isKinematic=true;
        GetComponent<Rigidbody2D>().velocity=Vector2.zero;
        GetComponent<Rigidbody2D>().freezeRotation=true;
        GetComponent<Collider2D>().isTrigger=true;
        Destroy(gameObject, timer);


    }

    
}

using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;

public class CollectableTrigger : MonoBehaviour
{
    public enum skillType { SeeRadius, Speed, Radius, Teleport }
    public skillType _skillType;
   public Collectables collectables;
    private void Start()
    {
        collectables = transform.parent.GetComponent<Collectables>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.CompareTag("Player"))
        {
            print("Girdi");
            if (_skillType == skillType.SeeRadius)
            {
                print("Girdi1");
                collectables._seeRadiusSkill.Used();
            }
            else if (_skillType == skillType.Speed)
            {
                print("Girdi2");
                collectables._speedSkill.Used();
            }
            else if (_skillType == skillType.Radius)
            {
                print("Girdi3");
                collectables._radiusSkill.Used();
            }
            else if (_skillType == skillType.Teleport)
            {
                print("print4");
                collectables._teleportSkill.Used();
                //collectables._teleportSkill.testObject.SetActive(true);
                //collectables._teleportSkill.playerMovementController.moveAble = false;
                //collectables._teleportSkill.playerMovementController.animController.SetFloat("MovementX",0);
                //collectables._teleportSkill.isUsed = true;
            }
            this.gameObject.SetActive(false);
        }
    }
}

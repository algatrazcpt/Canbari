using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedSkill : SkillBase
{
    [SerializeField] PlayerMovementController playerMovementController;
    [SerializeField] float walkSpeedMultiplier = 1.5f;


    private void Update()
    {
        //Test
        if (Input.GetKeyDown(KeyCode.U))
        {
            // Used();
        }
    }
    public override IEnumerator Use()
    {
        print("Speed Used");
        if (!isUsed)
        {
            print("Speed Used2");
            float exWalkSpeed = playerMovementController.walkSpeed;
            playerMovementController.walkSpeed = exWalkSpeed * walkSpeedMultiplier;
            isUsed = true;
            yield return new WaitForSeconds(_duration);
            isUsed = false;
            playerMovementController.walkSpeed = exWalkSpeed;
        }

    }

    public override void Used()
    {
        StartCoroutine(Use());
    }
}

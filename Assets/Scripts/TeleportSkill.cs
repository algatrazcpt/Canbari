using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportSkill : SkillBase
{
    [SerializeField] PlayerMovementController playerMovementController;
    [SerializeField] GameObject testObject;

    public override IEnumerator Use()
    {

        yield return null;
        //throw new System.NotImplementedException();
    }

    private void Start()
    {
        testObject.gameObject.SetActive(false);
    }
    private void Update()
    {
        //Test
        if (Input.GetKeyDown(KeyCode.Space))
        {
            StartCoroutine(Use());
            testObject.gameObject.SetActive(true);
            playerMovementController.moveAble = false;
            isUsed = true;
        }
        if (isUsed)
        {
            // Create a ray from the camera to the mouse position
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            // Check if the ray hits something
            if (Physics.Raycast(ray, out hit))
            {
                testObject.transform.position = hit.point;
                if (Input.GetMouseButtonDown(0))
                {
                    // Move the player to the clicked position
                    playerMovementController.transform.position = hit.point;
                    testObject.gameObject.SetActive(false);
                    Debug.Log("Player teleported to: " + hit.point);
                    isUsed = false;
                    playerMovementController.moveAble = true;
                }

            }

        }
    }
}
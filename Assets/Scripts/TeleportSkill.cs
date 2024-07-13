using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportSkill : SkillBase
{
    public PlayerMovementController playerMovementController;
    public GameObject testObject;
    [SerializeField] float _clampValue=2;

    private void Start()
    {
        testObject.SetActive(false);
    }

    private void Update()
    {
        //Test
        if (Input.GetKeyDown(KeyCode.I))
        {
            //StartCoroutine(Use());
            testObject.SetActive(true);
            playerMovementController.moveAble = false;
            playerMovementController.animController.SetFloat("MovementX", 0);
            isUsed = true;
        }
        if (isUsed)
        {
            // Create a ray from the camera to the mouse position
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            // Debug: Draw the ray in scene view for debugging
            Debug.DrawRay(ray.origin, ray.direction * 100f, Color.green);

            RaycastHit hit;

            // Check if the ray hits something
            if (Physics.Raycast(ray, out hit))
            {
                // Clamp the target position between -2 and 2
                float x = Mathf.Clamp(hit.point.x - playerMovementController.transform.position.x, -_clampValue, _clampValue);
                float y = Mathf.Clamp(hit.point.y - playerMovementController.transform.position.y, -_clampValue, _clampValue);
                float z = Mathf.Clamp(hit.point.z - playerMovementController.transform.position.z, -_clampValue, _clampValue);
                Vector3 clampedPosition = new Vector3(x, y, z);
                if (Input.GetMouseButtonDown(0))
                {
                    // Move the player to the clicked position
                    playerMovementController.transform.position += clampedPosition;
                    testObject.SetActive(false);
                    isUsed = false;
                    playerMovementController.moveAble = true;

                }
                testObject.transform.localPosition = clampedPosition;


            }
        }
    }

    public override IEnumerator Use()
    {
        yield return null;
    }

    public override void Used()
    {
        testObject.SetActive(true);
        playerMovementController.moveAble = false;
        playerMovementController.animController.SetFloat("MovementX", 0);
        isUsed = true;
    }
}

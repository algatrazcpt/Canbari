using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementController : MonoBehaviour
{

    public Animator animController;
    public bool moveAble = true;
    float horizontalInput;
    float verticalInput;
    public float walkSpeed = 20f;
    public Rigidbody2D rg;

    public Vector2 MoveDirection()
    {
        return new Vector2(horizontalInput, verticalInput);
    }
    private void FixedUpdate()
    {
        if (moveAble)
        {
            if (Input.GetButton("Horizontal"))
            {
                horizontalInput = Input.GetAxis("Horizontal");
            }
            else
            {
                horizontalInput = 0f;
            }

            if (Input.GetButton("Vertical"))
            {
                verticalInput = Input.GetAxis("Vertical");
            }
            else
            {
                verticalInput = 0f;
            }
            //rg.velocity=
            rg.velocity = MoveDirection().normalized * walkSpeed * Time.fixedDeltaTime;
            AnimateMove();
        }
        else
        {
            rg.velocity = Vector2.zero;
        }

    }
    private void AnimateMove()
    {
        animController.SetFloat("MovementX", MoveDirection().normalized.x);
        animController.SetFloat("MovmentY", MoveDirection().normalized.y);
    }

    void OnParticleCollision(GameObject other)
    {
        print("azzzuuuuuuuuuuuuu");
    }
}

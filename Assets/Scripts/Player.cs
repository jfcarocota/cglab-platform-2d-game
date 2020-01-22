using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Platform2DUtils.GameplaySystem;


public class Player : Character2D
{
    
    void Update() 
    {
        //GameplaySystem.MovementTdelta(transform, moveSpeed); 
        //GameplaySystem.PhysicsMovement(rb2D, moveSpeed, maxVelX);
        GameplaySystem.PhysicsMovementVel(rb2D, moveSpeed, maxVelX);
        spr.flipX = Flip; 
    }

    void FixedUpdate() 
    {
        if(Grounding)
        {
            if(GameplaySystem.JumpButton)
            {
                rb2D.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
                anim.SetTrigger("jump");
            }
        }
    }

    void LateUpdate()
    {
        anim.SetFloat("moveX", Mathf.Abs(GameplaySystem.Axis.x));
        anim.SetBool("grounding", Grounding);
    }

}

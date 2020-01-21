using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Platform2DUtils.GameplaySystem;

public class Character2D : MonoBehaviour
{
    protected Animator anim;
    protected SpriteRenderer spr;
    protected Rigidbody2D rb2D;
    [SerializeField, Range(0.1f, 20f)]
    protected float moveSpeed = 2f;

    [SerializeField]
    Color rayColor = Color.magenta;
    [SerializeField, Range(0.1f, 20f)]
    float rayDistance = 5f;
    [SerializeField]
    LayerMask groundLayer;
    [SerializeField, Range(0.1f, 20f)]
    protected float jumpForce = 7f;

    void Awake() 
    {
        anim = GetComponent<Animator>();
        spr = GetComponent<SpriteRenderer>();  
        rb2D = GetComponent<Rigidbody2D>();
    }

    protected bool Flip
    {
       get => GameplaySystem.Axis.x> 0f ? false : GameplaySystem.Axis.x < 0f ? true : spr.flipX;
    }

    protected bool Grounding
    {
        get => Physics2D.Raycast(transform.position, Vector2.down, rayDistance, groundLayer);
    }

    void OnDrawGizmosSelected() 
    {
       Gizmos.color = rayColor;
       Gizmos.DrawRay(transform.position, Vector2.down * rayDistance);
    }
}

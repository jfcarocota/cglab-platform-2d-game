using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character2D : MonoBehaviour
{
    Animator anim;
    SpriteRenderer spr;
    Rigidbody2D rb2D;
    [SerializeField, Range(0.1f, 20f)]
    float moveSpeed = 2f;

    [SerializeField]
    Color rayColor = Color.magenta;
    [SerializeField, Range(0.1f, 20f)]
    float rayDistance = 5f;
    [SerializeField]
    LayerMask groundLayer;
    [SerializeField, Range(0.1f, 20f)]
    float jumpForce = 7f;

    void Awake() 
    {
        anim = GetComponent<Animator>();
        spr = GetComponent<SpriteRenderer>();  
        rb2D = GetComponent<Rigidbody2D>();
    }

    void Update() 
    {
        transform.Translate(Vector2.right * Axis.x * moveSpeed * Time.deltaTime);   
        spr.flipX = Flip; 
    }

    void FixedUpdate() 
    {
        if(Grounding)
        {
            if(JumpButton)
            {
                rb2D.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
                anim.SetTrigger("jump");
            }
        }
    }

    void LateUpdate()
    {
        anim.SetFloat("moveX", Mathf.Abs(Axis.x));
        anim.SetBool("grounding", Grounding);
    }

    Vector2 Axis
    {
        get => new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
    }

    bool Flip
    {
       get => Axis.x > 0f ? false : Axis.x < 0f ? true : spr.flipX;
    }

    bool Grounding
    {
        get => Physics2D.Raycast(transform.position, Vector2.down, rayDistance, groundLayer);
    }

    bool JumpButton
    {
        get => Input.GetButtonDown("Jump");
    }

    void OnDrawGizmosSelected() 
    {
       Gizmos.color = rayColor;
       Gizmos.DrawRay(transform.position, Vector2.down * rayDistance);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    float moveSpeed;
    [SerializeField]
    float timeLimit;
    float timer = 0;
    float timerDelay = 0;
    [SerializeField]
    float delay;
    [SerializeField]
    Vector2 dir = Vector2.right;

    SpriteRenderer spr;

    Animator anim;

    void Awake() 
    {
        spr = GetComponent<SpriteRenderer>();   
        anim = GetComponent<Animator>(); 
    }

    void Update()
    {
        /*transform.Translate(dir * moveSpeed * Time.deltaTime);
        timer += Time.deltaTime;
        if(timer >= timeLimit)
        {
            timer = 0;
            spr.flipX = FlipSprite;
            dir.x = dir.x > 0 ? -1 : 1;
        }*/

        if(timer < timeLimit)
        {
            transform.Translate(dir * moveSpeed * Time.deltaTime);
            timer += Time.deltaTime;
        }
        else
        {
            if(timerDelay == 0)
            {
                anim.SetTrigger("idle");
            }
            timerDelay += Time.deltaTime;
            if(timerDelay >= delay)
            {
                spr.flipX = FlipSprite;
                dir.x = dir.x > 0 ? -1 : 1;
                timer = 0;
                timerDelay = 0;
                anim.SetTrigger("patrol");
            }
        }
    }

    bool FlipSprite
    {
        get =>  dir.x > 0 ? true : false;
    }
}

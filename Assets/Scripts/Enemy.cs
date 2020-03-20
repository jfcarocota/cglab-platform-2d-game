using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    float moveSpeed;

    float delay;
    [SerializeField]
    Vector2 dir = Vector2.right;

    SpriteRenderer spr;

    Animator anim;

    IEnumerator moving;
    IEnumerator waiting;

    bool isMoving = true;

    [SerializeField]
    float movingTime;
    [SerializeField]
    float waitingTime;



    void Awake() 
    {
        spr = GetComponent<SpriteRenderer>();   
        anim = GetComponent<Animator>(); 
    }

    void Start() 
    {
        moving = Moving(movingTime);
        waiting = Waiting(waitingTime);
        StartCoroutine(moving);
        StartCoroutine(waiting);
    }

    IEnumerator Waiting(float waitTime)
    {
        while(true)
        {
            yield return new WaitForSeconds(waitTime);

            if(isMoving)
            {
                StopCoroutine(moving);
                anim.SetTrigger("idle");
            }
            else
            {
                spr.flipX = FlipSprite;
                dir.x = dir.x > 0 ? -1 : 1;
                anim.SetTrigger("patrol");
                StartMoving();
            }
            isMoving = !isMoving;
        }
    }

     void StartMoving()
     {
         moving = Moving(movingTime);
        StartCoroutine(moving);
     }


    IEnumerator Moving(float waitTime)
    {
        while(true)
        {
            transform.Translate(dir * moveSpeed * Time.deltaTime);
            yield return new WaitForSeconds(waitTime);
        }
    }



    bool FlipSprite
    {
        get =>  dir.x > 0 ? true : false;
    }
}

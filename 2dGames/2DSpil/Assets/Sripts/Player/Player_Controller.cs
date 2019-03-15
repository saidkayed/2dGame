using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Player_Controller : MonoBehaviour
{
    Vector2 movement;
    public float speed;
    float Camera_POS_X;

    Tween myTween;
    float Negativ_Cam_pos;

    Animator anim;



    private Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        StartCoroutine("Move_Cam");
        anim = GetComponent<Animator>();



    }
    void FixedUpdate()
    {

        if (Input.GetKey("w") || Input.GetKey("d") || Input.GetKey("a") || Input.GetKey("s"))
        {




            float moveHorizontal = Input.GetAxis("Horizontal");
            float moveVertical = Input.GetAxis("Vertical");


            movement = new Vector2(moveHorizontal * speed, moveVertical * speed);
            rb.velocity = movement;
        }
        else
        {
            anim.Play("Idle");
            // speed = 0;
            rb.velocity = Vector2.zero;
            //rb.AddForce(movement * speed);
        }

        if (Input.GetKey("a"))
        {
            anim.Play("Run");
            GetComponent<SpriteRenderer>().flipX = true;
        }

        if (Input.GetKey("d"))
        {
            GetComponent<SpriteRenderer>().flipX= false;
            anim.Play("Run");
        }
        if (Input.GetKey("w"))
        {
            anim.Play("Run");
        }
        if (Input.GetKey("s"))
        {
            anim.Play("Run");
        }


    }
    IEnumerator Move_Cam(){


        print("fuck");
        while (true)
        {
           
            if (Input.GetKeyDown("a"))
            {

                print("jhe");
                myTween = Camera.main.transform.DOMoveX(transform.position.x - 5, 0.8f);
                //yield return myTween.WaitForCompletion();
            }else if (Input.GetKeyDown("d"))
            {
                myTween = Camera.main.transform.DOMoveX(transform.position.x + 5, 0.8f);
                //yield return myTween.WaitForCompletion();
            }
            yield return null;
        }
         
        }
     
    }
    



using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Player_Controller : MonoBehaviour
{
    Vector2 movement;

    public float speed;
    public Vector2 Jump_Height;

    float Camera_POS_X;
    float Camera_Height;

    Tween myTween;
    float Negativ_Cam_pos;

    Animator anim;

    float playerHeight;

    bool isGrounded;
    bool isA;
    bool isD;
    bool can_be_hit;
    


    private Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {

        can_be_hit = true;
        rb = GetComponent<Rigidbody2D>();
        StartCoroutine("Move_Cam");
        anim = GetComponent<Animator>();

        Camera_Height = Camera.main.transform.position.y;
        


    }
    void Update()
    {
        print(can_be_hit + "" + "kdkdkd");
        

        if (isD)
        {
            myTween = Camera.main.transform.DOMoveX(transform.position.x+5, 2);
        } 
        if(isA)
        {
            myTween = Camera.main.transform.DOMoveX(transform.position.x-5, 2);
        }

      
        
        if (Input.GetKey("w") || Input.GetKey("d") || Input.GetKey("a") || Input.GetKey("s"))
        {




            float moveHorizontal = Input.GetAxis("Horizontal");
            float moveVertical = Input.GetAxis("Vertical");


            movement = new Vector2(moveHorizontal * speed,0);
            rb.velocity = movement;
        }
        else
        {

            // speed = 0;
           
            rb.velocity = Vector2.zero;
            if (isGrounded) {
                anim.Play("Idle");
            }
        }
      

        if (Input.GetKey("a"))
        {
            if (isGrounded)
            {
                anim.Play("Run");
            }
            GetComponent<SpriteRenderer>().flipX = true;
        }

        if (Input.GetKey("d"))
        {
            if (isGrounded)
            {
                anim.Play("Run");
            }

            GetComponent<SpriteRenderer>().flipX= false;
         
        }

        if (Input.GetKeyDown("w"))
        {

            if (isGrounded)
            {
          
                isGrounded = false;
                anim.Play("Jumping");
                transform.DOMoveY(transform.position.y + 2, 0.8f);
             
                

            }
        }
       /*
        if (Input.GetKey("s"))
        {
            anim.Play("Run");
        }
        */
    }
    IEnumerator Move_Cam(){       
        while (true)
        {
            

            if (Input.GetKeyDown("a"))
            {

                isD = false;
                isA = true;
             
                myTween = Camera.main.transform.DOMoveX(transform.position.x - 5, 2f);
          
            }else if (Input.GetKeyDown("d"))
            {
                isA = false;
                isD = true;
                myTween = Camera.main.transform.DOMoveX(transform.position.x + 5, 2f);

            }
        
            yield return null;
        }
         
        }
   

    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        if(collision.transform.tag == "ground")
        {
            isGrounded = true;
        }
       
        if(collision.transform.tag == "Alien" && can_be_hit)
        {
           
            Vector3 push_back = transform.position -  collision.transform.position;
         

            StartCoroutine("Ouch");
            

            if(push_back.x > 0)
                {
                transform.DOMoveX(collision.transform.position.x + 6, 1);
            }
            if(push_back.x < 0)
                {
                transform.DOMoveX(collision.transform.position.x - 6, 1);
            }
        }   
    }
   
   

    IEnumerator Ouch()
    {
        float hp = Stats.HP - 5;

        Stats.HP = hp;
        // can_be_hit = false;
        for (int i = 0; i < 4; i++) {
            GetComponent<SpriteRenderer>().DOFade(0, 0);


            yield return new WaitForSeconds(0.3f);
            
        GetComponent<SpriteRenderer>().color = new Color(1f,1f,1f,1f);
            yield return new WaitForSeconds(0.3f);
    
        }
        //yield return new WaitForSeconds(1);
       // can_be_hit = true;

    }
 
}
    



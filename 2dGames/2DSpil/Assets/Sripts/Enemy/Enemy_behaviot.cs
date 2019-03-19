using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_behaviot : MonoBehaviour
{

    public GameObject Player;
    Vector3 start_pos;
    bool startCheck;
   

   

    // Start is called before the first frame update
    void Start()
    {
     
        start_pos = transform.position;
    }

    
    // Update is called once per frame
    void FixedUpdate ()
    {
        float distance_player = Vector2.Distance(transform.position,Player.transform.position);

        

        if(distance_player < 6)
        {
            print("walk to");
            startCheck = true;
         transform.position =  Vector2.MoveTowards(transform.position, Player.transform.position, 2 * Time.fixedDeltaTime);
           Vector3 flip = Player.transform.position - transform.position;
              if(flip.x > 0)
            {
                GetComponent<SpriteRenderer>().flipX = false;
            }
            if (flip.x < 0)
            {
                GetComponent<SpriteRenderer>().flipX = true;
            }
            GetComponent<Animator>().Play("Walk");

        }


        if (distance_player > 6 && startCheck)
        {
            print("walk back");  
            transform.position = Vector2.MoveTowards(transform.position, start_pos, 5 * Time.fixedDeltaTime);
            

        }


        if (Vector3.Distance(transform.position, start_pos) < 0.5f)
        {
            GetComponent<Animator>().Play("idle");
            print("boms");
           startCheck = false;
            print(startCheck);
        }

       
       
        






    }
   
   
}

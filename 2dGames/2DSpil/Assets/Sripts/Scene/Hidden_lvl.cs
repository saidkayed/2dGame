using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Hidden_lvl : MonoBehaviour
{

    static public bool isunlock;
public GameObject Secret_Planet;
    // Start is called before the first frame update
    void Start()
    {
        print(isunlock);
        if (isunlock == true)
        {
            print("hey");
            Secret_Planet.GetComponent<SpriteRenderer>().enabled = true;
            Secret_Planet.GetComponent<BoxCollider2D>().enabled = true;
        }

    }



    // Update is called once per frame
    void Update()
    {
        

    }



    
    private void OnTriggerEnter2D(Collider2D collision)
    {
  
        if(collision.gameObject.name == "New Sprite")
        {
            isunlock = true;
            gameObject.GetComponent<BoxCollider2D>().enabled = false;
            gameObject.GetComponent<SpriteRenderer>().enabled = false;
            StartCoroutine("load_level");
        }
    }

   IEnumerator load_level()
    {
        if (isunlock)
        {
           
            yield return new WaitForSeconds(2);

            SceneManager.LoadScene("Select_Levels");
        }
    }
}

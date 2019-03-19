using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class PlanetClick : MonoBehaviour
{
    public GameObject Planet1;
     public GameObject Planet2;
    public GameObject Planet3;

    //public Camera maincamera;


    bool planet_is_clicked = false;
    //public GameObject cubetest;
    // Start is called before the first frame update
    void Start()
    {
   
    }

    // Update is called once per frame
    void Update()
    {
       
        if (planet_is_clicked)
        {
        
            Camera.main.transform.position = Vector3.MoveTowards(Camera.main.transform.position, transform.position, 5 * Time.deltaTime);
        }

        if (Vector3.Distance(Camera.main.transform.position, transform.position) < 0.5f)
        {

            planet_is_clicked = false;
            if(transform.name == "Earth")
            {  
                transform.DOScale(1,5);
                StartCoroutine("Load_Level");
            }
            if (transform.name == "Planet X")
            {
                transform.DOScale(1, 5);
                // SceneManager.LoadScene("Earth");
            }



        }

    }


    private void OnMouseDown()
    {
        planet_is_clicked = true;
        Planet1.GetComponent<SpriteRenderer>().DOFade(-1, 5);
       Planet2.GetComponent<SpriteRenderer>().DOFade(-1, 5);
        Planet3.GetComponent<SpriteRenderer>().DOFade(-1, 5);
    }

    IEnumerator Load_Level()
    {
        yield return new WaitForSeconds(5);
        SceneManager.LoadScene("Earth");
    }
}

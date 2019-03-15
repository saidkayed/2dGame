using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class PlanetHover : MonoBehaviour
{
    bool mouseover = false;
    //starter Corutine en gang istedet for 100x
    bool Start_Once = true;

    float first_pos;
    Vector3 Text_pos;

    public TextMesh Planet_Name;
    Tween myTween;


    private void Start()
    {
        first_pos = transform.position.y;
        Text_pos = Planet_Name.transform.position;
        
       
    }


    private void OnMouseOver()
    {
        if (Start_Once)
        {
            StartCoroutine("Planet_Animation");
          
          
        }
            mouseover = true;
     
    }

    private void OnMouseExit()
    {
        Planet_Name.transform.position = new Vector3(Text_pos.x,Text_pos.y,Text_pos.z);
        mouseover = false;
        Start_Once = true;

        Planet_Name.text = "";
        StopCoroutine("Planet_Animation");
        transform.DOMoveY(first_pos, 1);
     

    }
    IEnumerator Planet_Animation()
    {
       

        while (mouseover) {
            Start_Once = false;
            Planet_Name.transform.position = new Vector3(gameObject.transform.position.x - 2, gameObject.transform.position.y - 1.5f, -1);
            Planet_Name.text = transform.name;
           

           Planet_Name.transform.DOMoveY(Planet_Name.transform.position.y + 0.5f,1);
            myTween = transform.DOMoveY(first_pos + 0.5f, 1);
            yield return myTween.WaitForCompletion();
           Planet_Name.transform.DOMoveY(Planet_Name.transform.position.y - 0.5f, 1);
            myTween = transform.DOMoveY(first_pos, 1);
            yield return myTween.WaitForCompletion();


        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class PlayScript : MonoBehaviour
   
{
    public GameObject Moveto;
    bool off = true;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("Planet_Animation");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDown()
    {
        print("hejsa");
        Camera.main.transform.DOMoveY(Moveto.transform.position.y,1);
    }

    private void OnMouseOver()
    {
        if (off)
        {
            StartCoroutine("Flash_Text");
        }
    }

    private void OnMouseExit()
    {
        off = true;
        StopCoroutine("Flash_Text");
        GetComponent<TextMesh>().color = Color.white;
    }

    IEnumerator Flash_Text()
    {
        off = false;
        while (true) {
            GetComponent<TextMesh>().color = Color.yellow;  
            yield return new WaitForSeconds(0.5f);
            GetComponent<TextMesh>().color = Color.white;
            yield return new WaitForSeconds(0.5f);
        }
    }
    IEnumerator Planet_Animation()
    {


        while (true)
        {

            Tween myTween;
            myTween = transform.DOMoveY(transform.position.y + 0.2f, 1);
            yield return myTween.WaitForCompletion();

            myTween = transform.DOMoveY(transform.position.y - 0.2f, 1);
            yield return myTween.WaitForCompletion();


        }
    }
    }

using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key_Item : MonoBehaviour
{

    float first_pos;

    Tween myTween;

    // Start is called before the first frame update
    void Start()
    {
        first_pos = transform.position.y;
        StartCoroutine("Item_Hover");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator Item_Hover()
    {
        while (true)
        {
         
            myTween = transform.DOMoveY(first_pos + 0.5f, 1);
            yield return myTween.WaitForCompletion();
           
            myTween = transform.DOMoveY(first_pos, 1);
            yield return myTween.WaitForCompletion();

        }
    }
}

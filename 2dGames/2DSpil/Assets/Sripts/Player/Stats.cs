using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stats : MonoBehaviour
{
   public static float HP = 100;
  
    public GameObject hp_text;
    // Start is called before the first frame update
    void Start()
    {
        
        
    }

    // Update is called once per frame
    void Update()
    {
        hp_text.GetComponent<TMPro.TextMeshProUGUI>().text = "HP:" + HP.ToString();
    }
}

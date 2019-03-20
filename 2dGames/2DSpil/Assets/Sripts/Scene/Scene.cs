using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scene : MonoBehaviour
{
    
    void Start()
    {
        if (Hidden_lvl.isunlock == true) {
            transform.position = new Vector3(0, 0.1599998f,-10f);
                }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

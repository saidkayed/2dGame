using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health_kit : MonoBehaviour
{
    public float health_kit = 20;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
      
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.transform.tag == "Player")
        {
            float hp = Stats.HP + 10;

            Stats.HP = hp;

            if (Stats.HP > 100)
            {
                Stats.HP = 100;
            }
        }
        StartCoroutine("destroy");
    }

    IEnumerator destroy()
    {
        yield return new WaitForSeconds(0);
        Destroy(gameObject);
    }
}

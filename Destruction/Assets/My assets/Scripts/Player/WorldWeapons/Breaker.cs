using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Breaker : MonoBehaviour
{

    public Shatter myShatter;
    private bool shatter;
    private float delay;
    // Start is called before the first frame update
    void Start()
    {
        shatter = false;
        delay = Random.Range(0.1f, 0.6f);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(1))
        {
            if (!shatter)
            {
                shatter = true;
            }
            

        }

        if (shatter)
        {
            delay -= Time.deltaTime;
            if(delay <= 0)
            {
                Damage();
            }
        }
    }

    void Damage()
    {
        if (myShatter != null)
        {
            myShatter.Obliviate();
            
        }
        Destroy(gameObject);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SledgeHead : MonoBehaviour
{
    public Sledge sledge;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Hello");
        if (sledge.swinging)
        {

            Shatter shatter = other.gameObject.GetComponent<Shatter>();
            if (shatter != null)
            {
                shatter.Obliviate();
            }
            else
            {
                other.attachedRigidbody.AddForce(500f * transform.forward);
            }
            

        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (sledge.swinging)
        {

            Shatter shatter = other.gameObject.GetComponent<Shatter>();
            if (shatter != null)
            {
                shatter.Obliviate();
            }
            else
            {
                if (other.attachedRigidbody != null)
                {
                    other.attachedRigidbody.AddForce(100f * transform.forward);
                }
            }


        }
    }
}

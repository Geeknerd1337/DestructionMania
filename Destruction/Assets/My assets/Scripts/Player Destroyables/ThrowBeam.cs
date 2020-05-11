using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowBeam : MonoBehaviour
{


    public float throwForce = 700f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            transform.SetParent(null);
            GetComponent<Rigidbody>().isKinematic = false;
            GetComponent<Rigidbody>().AddForce(transform.forward * throwForce);
        }
    }
}

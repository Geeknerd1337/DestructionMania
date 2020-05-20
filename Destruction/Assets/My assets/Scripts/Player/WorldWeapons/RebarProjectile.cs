using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RebarProjectile : MonoBehaviour
{
    private Rigidbody rb;
    private float time = 0.2f;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        
    }

    // Update is called once per frame
    void Update()
    {
        time -= Time.deltaTime;
        if(time < 0)
        {
            rb.useGravity = true;
        }
    }
}

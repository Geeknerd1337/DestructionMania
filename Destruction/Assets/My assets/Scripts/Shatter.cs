﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shatter : MonoBehaviour
{


    public GameObject destroyedObject;
    private Rigidbody rb;
    private bool destroyed;
    private AudioSource sound;
    public GameObject breakSound;
    public ParticleSystem partSystem;
    public float breakPitch;
    public LevelManager manager;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        destroyed = false;
        sound = GetComponent<AudioSource>();
        manager = FindObjectOfType<LevelManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Obliviate()
    {
        if (!destroyed)
        {
            GameObject snd = Instantiate(breakSound);
            snd.GetComponent<AudioSource>().pitch = breakPitch;
            snd.transform.position = transform.position;
            Destroy(snd, 4f);
            GameObject g = Instantiate(destroyedObject);
            g.transform.position = transform.position;
            g.transform.rotation = transform.rotation;
            Rigidbody[] rbs = g.GetComponentsInChildren<Rigidbody>();
            foreach (Rigidbody body in rbs)
            {
                body.velocity = rb.velocity;
            }


            if(partSystem != null)
            {
                partSystem.transform.SetParent(null);
                partSystem.Play();
                Destroy(partSystem.gameObject, 10f);
            }

            destroyed = true;
            manager.graceTimer = 0;
            Destroy(gameObject);
        }
    }

    public void Explode()
    {
        GameObject g = Instantiate(destroyedObject);
        g.transform.position = transform.position;
        g.transform.rotation = transform.rotation;
        Rigidbody[] rbs = g.GetComponentsInChildren<Rigidbody>();
        Collider[] array = Physics.OverlapSphere(transform.position, 5f);

        foreach(Collider nearBy in array)
        {
            Rigidbody rbb = nearBy.GetComponent<Rigidbody>();
            if(rbb != null)
            {
                //rbb.AddExplosionForce(700f, transform.position, 5f);
            }
        }

        foreach (Rigidbody body in rbs)
        {
            body.velocity = rb.velocity;
            //body.AddExplosionForce(700f, transform.position, 5f);

        }
        //rb.AddExplosionForce(2000f, transform.position,10f);
        Destroy(gameObject);
    }

    private void OnCollisionEnter(Collision collision)
    {

        if (collision.relativeVelocity.magnitude > 8)
        {
            
            Obliviate();
        }

        if (collision.relativeVelocity.magnitude > 2 && !destroyed && sound != null)
        {
            sound.Play();
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySoundOnHit : MonoBehaviour
{
    private AudioSource sound;
    // Start is called before the first frame update
    void Start()
    {

        sound = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {


        if (collision.relativeVelocity.magnitude > 8 && sound != null)
        {
            sound.Play();
        }
    }
}

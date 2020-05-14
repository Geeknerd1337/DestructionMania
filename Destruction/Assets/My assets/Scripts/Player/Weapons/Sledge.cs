using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sledge : Weapon
{
    private Animator animator;
    public bool swinging;
    private AudioSource sound;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        sound = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && !animator.GetCurrentAnimatorStateInfo(0).IsName("SledgeSwing"))
        {
            Swing();
            
        }
        if (animator.GetCurrentAnimatorStateInfo(0).IsName("SledgeSwing") && animator.GetCurrentAnimatorStateInfo(0).normalizedTime < 0.1f)
        {
            
            swinging = true;
        }
        else
        {
            swinging = false;
        }
    }

    void Swing()
    {
        animator.Play("SledgePrepare");
    }

    public void PlaySound()
    {
        sound.Play();
    }
}

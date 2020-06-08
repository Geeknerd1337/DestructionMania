using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RebarLauncher : Weapon
{

    public Animator a;
    public ParticleSystem spinpart;
    public ParticleSystem collectPart;
    public Transform projectilePoint;
    public GameObject projectile;
    // Start is called before the first frame update
    void Start()
    {
        a = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && !a.GetCurrentAnimatorStateInfo(0).IsName("Fire"))
        {
            Shoot();

        }
    }

    void Shoot()
    {
        a.Play("Fire");
        spinpart.Play();
        collectPart.Play();
        GetComponent<AudioSource>().Play();
        
    }

    void FireProjectile()
    {
        GameObject g = Instantiate(projectile);
        g.transform.position = projectilePoint.position;
        g.transform.rotation = projectilePoint.rotation;
        g.GetComponent<Rigidbody>().AddForce(g.transform.forward * 4000f);
       
    }

    public void DepleteCharges()
    {
        charges--;
    }
}

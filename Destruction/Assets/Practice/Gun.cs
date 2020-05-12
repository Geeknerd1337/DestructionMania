using UnityEngine;

/// WIP
public class Gun : MonoBehaviour
{
    // Variables
    public float damage = 10f;
    public float range = 100f;
    public float impactForce = 30f;
    public Camera fpscam;
    public ParticleSystem flash;
    public GameObject impacteffect;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {

            Shoot();
        }


    }

    // Blank template for shooting.
    void Shoot()
    {
        flash.Play();
        RaycastHit hit;
        if (Physics.Raycast(fpscam.transform.position, fpscam.transform.forward, out hit, range))
        {
            Debug.Log(hit.transform.name);
            Target target = hit.transform.GetComponent<Target>();
            if (target != null)
            {
                target.TakeDamage(damage);
            }

            if (hit.rigidbody != null)
            {
                hit.rigidbody.AddForce(-hit.normal * impactForce);
            }

            GameObject impactGO = Instantiate(impacteffect, hit.point, Quaternion.LookRotation(hit.normal));
            Destroy(impactGO, 2f);

        }


    }



}

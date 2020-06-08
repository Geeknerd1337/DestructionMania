using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakerHand : Weapon
{

    public GameObject breakerPrefab;

    // Start is called before the first frame update
    void Start()
    {
        base.InitializeWeapon();
    }

    // Update is called once per frame
    void Update()
    {
        if ((Input.GetKeyDown(KeyCode.E) || Input.GetMouseButtonDown(0) || Input.GetButtonDown("Fire1")))
        {
            PlaceObject();
        }
    }

    void PlaceObject()
    {
        RaycastHit hit;
        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range, lm))
        {
            Shatter target = hit.collider.transform.GetComponent<Shatter>();
            if (target != null)
            {
                GameObject g = Instantiate(breakerPrefab);
                g.transform.position = hit.point;
                g.transform.rotation = Quaternion.FromToRotation(Vector3.up, hit.normal);
                g.GetComponent<Breaker>().myShatter = target;
                g.transform.parent = target.transform;
                Debug.Log(target.name);
                charges--;
            }
        }
        
    }
}

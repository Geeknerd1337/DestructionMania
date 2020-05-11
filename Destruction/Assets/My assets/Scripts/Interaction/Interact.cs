using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;
public class Interact : MonoBehaviour
{

    public float range = 10f;
    public Camera fpsCam;
    public FirstPersonController playerController;
    public LayerMask lm;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if ((Input.GetKeyDown(KeyCode.E) || Input.GetMouseButtonDown(0) || Input.GetButtonDown("Fire1")))
        {
               InteractWith();
        }
    }

    void InteractWith()
    {

        RaycastHit hit;
        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range, lm))
        {
            Shatter target = hit.collider.transform.GetComponent<Shatter>();
            Debug.Log(hit.transform.name);
            if (target != null)
            {
                target.Explode();
                Debug.Log(target.name);
            }
        }


    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{

    public int quantity = 0;
    public float range = 10f;
    public Camera fpsCam;
    public LayerMask lm;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void InitializeWeapon()
    {
        fpsCam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

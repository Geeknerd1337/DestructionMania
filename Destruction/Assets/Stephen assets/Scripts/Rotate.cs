using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
   public GameObject Obj;

   public float x,y,z;
    
    // Update is called once per frame
    void FixedUpdate()
    {
        Obj.transform.Rotate(x * Time.deltaTime,y * Time.deltaTime,z * Time.deltaTime,Space.World);
    }
}

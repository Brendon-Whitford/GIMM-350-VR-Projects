using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crossbow : MonoBehaviour
{
    public GameObject crossBow;
    
    void Start()
    {
        
    }

    void Update()
    {
       if(this.transform.position.y < 11)
        {
            Instantiate(crossBow, new Vector3(2.2f, 16.3f, 2.2f), Quaternion.Euler(270,90,0));
            Destroy(this.gameObject);
        } 
    }
    
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crossbow : MonoBehaviour
{
    public GameObject crossbow;
    public GameObject arrow;
    private Vector3 arrowSpawnPos;
    void Start()
    {
        
    }

    void Update()
    {
       if(this.transform.position.y < 11)
        {
            this.transform.position = new Vector3(2.2f, 16.3f, 2.2f);
            this.transform.rotation = Quaternion.Euler(270, 90, 0);
        } 
    }
    public void ShootCrossbow()
    {
        arrowSpawnPos = crossbow.transform.position;
        GameObject temp = Instantiate(arrow, GameObject.Find("Crossbow").GetComponent<Transform>());
        temp.transform.SetParent(null);
    }

}

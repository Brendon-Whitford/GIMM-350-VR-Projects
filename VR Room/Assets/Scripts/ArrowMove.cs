using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ArrowMove : MonoBehaviour
{
    Rigidbody rb;
    float speed = 50f;
    GameObject bow;
    private AudioSource arrowAudio;
    public AudioClip shootSound;
    
    void Start()
    {
        arrowAudio = GetComponent<AudioSource>();
        rb = GetComponent<Rigidbody>();
        bow = GameObject.FindGameObjectWithTag("CrossbowN");
        rb.AddForce((bow.transform.right*-1) * Time.deltaTime * speed, ForceMode.Impulse);
        arrowAudio.PlayOneShot(shootSound, 1);
        Invoke("DeleteArrow", 10);
    }

    void DeleteArrow()
    {
        Destroy(gameObject);
    }

    void Update()
    {
        
    }
}

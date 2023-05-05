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
    public ParticleSystem arrowParticles;
    
    void Start()
    {
        arrowAudio = GetComponent<AudioSource>();
        rb = GetComponent<Rigidbody>();
        bow = GameObject.FindGameObjectWithTag("CrossbowN");
        rb.AddForce((bow.transform.right*-1) * Time.deltaTime * speed, ForceMode.Impulse);
        arrowAudio.PlayOneShot(shootSound, 1);
        //Instantiate(arrowParticles, this.transform.position, this.transform.rotation);
        //arrowParticles.transform.parent = this.gameObject.transform;
        Invoke("DeleteArrow", 10);
    }

    void DeleteArrow()
    {
        Destroy(gameObject);
        
    }

    void Update()
    {
        //arrowParticles.transform.position = this.transform.position;
    }
}

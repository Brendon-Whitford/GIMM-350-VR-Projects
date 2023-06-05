using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = 5;
    public GameObject gameManager;
    private Rigidbody enemyRb;
    private AudioSource enemyAudio;
    public AudioClip enemyDeath;
    public ParticleSystem explosionParticle;
    
    
    // Start is called before the first frame update
    void Start()
    {
        enemyRb = GetComponent<Rigidbody>();
        enemyAudio = GetComponent<AudioSource>();
        gameManager = GameObject.Find("GameManager");
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter(Collider other)
    {
        GameObject tower = GameObject.FindGameObjectWithTag("Tower");
        GameObject arrow = GameObject.FindGameObjectWithTag("Arrow");
        Vector3 explosionPos = new Vector3(transform.position.x, transform.position.y + 5, transform.position.z);
        if (other == tower.GetComponent<Collider>())
        {
            gameManager.GetComponent<GameManager>().towerHealth -= 1;
            Debug.Log(gameManager.GetComponent<GameManager>().towerHealth);
            enemyAudio.PlayOneShot(enemyDeath, 1);
            Destroy(gameObject);
            Instantiate(explosionParticle, explosionPos, explosionParticle.transform.rotation);
            
            //Instantiate(explosionParticle, transform.position, explosionParticle.transform.rotation);
        }
        if (other.GetComponent<ArrowMove>())
        {
            enemyAudio.PlayOneShot(enemyDeath, 1);
            Destroy(other);
            Destroy(gameObject);
            Instantiate(explosionParticle, explosionPos, explosionParticle.transform.rotation);
            
        }
    }
}

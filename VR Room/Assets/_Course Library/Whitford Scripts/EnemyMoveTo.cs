using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMoveTo : MonoBehaviour
{
    public Transform tower;
    // Start is called before the first frame update
    void Start()
    {
        NavMeshAgent agent = GetComponent<NavMeshAgent>();
        agent.destination = tower.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

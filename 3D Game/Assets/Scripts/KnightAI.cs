using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class KnightAI : MonoBehaviour
{
    public NavMeshAgent Enemy;

    public Transform Player;

    //states

    public float SightRange;

    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    void Update()
    {
        
        Enemy.SetDestination(Player.position);
        
    }

    


    
}

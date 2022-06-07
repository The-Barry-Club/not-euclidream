using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyScript : MonoBehaviour
{


    public Transform PointA;
    public Transform PointB;

    public Transform ennemy;

    bool toPointA = true;
    bool toPointB = false;

    public NavMeshAgent agent;



    // Start is called before the first frame update
   void Start()
   {
       agent = GetComponent<NavMeshAgent>();
       ennemy = GetComponent<Transform>();
   } 

    // Update is called once per frame
    void Update()
    {

        if(toPointA){
            //transform.LookAt(PointA);
            Vector3 destination = new Vector3(PointA.position.x,ennemy.position.y,PointA.position.z);
            agent.SetDestination(destination);
        } 
        else if(toPointB){
            //transform.LookAt(PointB);
            Vector3 destination = new Vector3(PointB.position.x,ennemy.position.y,PointB.position.z);
            agent.SetDestination(destination);
        } 
        

    }




    void OnTriggerStay(Collider other)
    {

        Debug.Log(other);
        if(other.tag == "PointA"){
            Debug.Log("collide a");
            toPointA = false;
            toPointB = true;
        }
        else if(other.tag == "PointB"){
            Debug.Log("collide B");
            toPointA = true;
            toPointB = false;
        }
    }
}

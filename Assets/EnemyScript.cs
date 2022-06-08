using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyScript : MonoBehaviour
{


    public Transform PointA;
    public Transform PointB;

    public Transform ennemy;


    public NavMeshAgent agent;

    public GameObject inner = null;
    public GameObject outer = null;

    public bool Once = false;

    public int InnerRange = 0;
    public int OuterRange = 0;



    // Start is called before the first frame update
   void Start()
   {
       agent = GetComponent<NavMeshAgent>();
       ennemy = GetComponent<Transform>();
       GoPointA();
   } 

    // Update is called once per frame
    void Update()
    {

        //Get list of player sorted by distance
        GameObject[] players = GameObject.FindGameObjectsWithTag("Player");
        List<(float,GameObject)> listPDinner = new List<(float,GameObject)>();
        List<(float,GameObject)> listPDouter = new List<(float,GameObject)>();
        foreach(var player in players)
        {
            //Je calcul la distance :
            float dist = Vector3.Distance(player.transform.position,ennemy.position);
            Debug.Log("DIST : " +dist);
            //J'add dans les listes
            if(dist < InnerRange) listPDinner.Add((dist,player));
            if(dist < OuterRange) listPDouter.Add((dist,player));
            
        }

        if(listPDinner.Count>0) listPDinner.Sort((a, b) => a.Item1.CompareTo(b.Item1));
        if(listPDouter.Count>0) listPDouter.Sort((a, b) => a.Item1.CompareTo(b.Item1));

        //Je cherche si inner

        int i = 0;
        inner = null;
        while (i<listPDinner.Count && inner == null)
        {
            if(listPDinner[i].Item1 < InnerRange)
            {
                inner = listPDinner[i].Item2;
            }
            i++;
        }


        if(inner != null)
        {
            outer = inner;
            Once = true;
        } 

        if(listPDouter.Count == 0) outer = null;

        if(outer)
        {
           
            
            Vector3 destination = new Vector3(outer.GetComponent<Transform>().position.x,ennemy.position.y,outer.GetComponent<Transform>().position.z);
            agent.SetDestination(destination);


            var dir = outer.GetComponent<Transform>().position - ennemy.position;
            Quaternion LookAtRotation = Quaternion.LookRotation(dir);
            Quaternion LookAtRotationOnly_Y = Quaternion.Euler(transform.rotation.eulerAngles.x, LookAtRotation.eulerAngles.y, transform.rotation.eulerAngles.z);
            ennemy.rotation = LookAtRotationOnly_Y;
            
        }
        else{
            if(Once){
                GoPointA();
                Once = false;
            }
            
        }


        

        

        


    }

    public void GoPointA()
    {
        transform.LookAt(PointA);
            Vector3 destination = new Vector3(PointA.position.x,ennemy.position.y,PointA.position.z);
            agent.SetDestination(destination);
    }

    public void GoPointB()
    {
        transform.LookAt(PointB);
            Vector3 destination = new Vector3(PointB.position.x,ennemy.position.y,PointB.position.z);
            agent.SetDestination(destination);
    }




    
}

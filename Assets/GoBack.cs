using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoBack : MonoBehaviour
{


    public string dir = "";
    


   
    void OnTriggerEnter(Collider other)
    {
        if(dir == "PointA"){

            if(other.tag == "Ennemy" && other.GetComponent<EnemyScript>().outer == null )
            {
                other.GetComponent<EnemyScript>().GoPointA();

            }


        }


        else if(dir == "PointB")
        {
            if(other.tag == "Ennemy" && other.GetComponent<EnemyScript>().outer == null)
            {
                other.GetComponent<EnemyScript>().GoPointB();

            }

        }
    }


}

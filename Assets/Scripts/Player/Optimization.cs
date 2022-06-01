using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Optimization : MonoBehaviour
{


    public Camera cam;
    public Transform PlayerPos;

    public GameObject Player;

    public List<GameObject> portalList;

    // Start is called before the first frame update
    void Start()
    {
        foreach (GameObject obj in GameObject.FindGameObjectsWithTag("Portal"))
        {
            portalList.Add(obj);
        }

    }

    // Update is called once per frame
    void Update()
    {


        //Desactivate portals if they are too far
        foreach (GameObject obj in portalList)
        {

            /*
            Debug.Log(obj.GetComponent<Transform>().position);
            if(Vector3.Distance(PlayerPos.position,obj.GetComponent<Transform>().position) < 5)
            {
                obj.SetActive(true);
                obj.GetComponent<CameraRef>().cam.SetActive(true);
            }
            else{
                obj.SetActive(false);
                obj.GetComponent<CameraRef>().cam.SetActive(false);
            } 
            */

            if(IsInView(Player,obj) && Vector3.Distance(PlayerPos.position,obj.GetComponent<Transform>().position) < 20)
            {
                Debug.Log("visible "+ obj);
                obj.GetComponent<CameraRef>().cam.SetActive(true);
            }
            else{
                obj.GetComponent<CameraRef>().cam.SetActive(false);
            } 

            
        }



    }


    private bool IsVisible(Camera c, GameObject target){

        var planes = GeometryUtility.CalculateFrustumPlanes(c);
        var point = target.transform.position;

        foreach (var plane in planes)
        {
            if(plane.GetDistanceToPoint(point) < 0)
                return false;
        
        }
        return true;
    }



    private bool IsInView(GameObject origin, GameObject toCheck)
     {
         Vector3 pointOnScreen = cam.WorldToScreenPoint(toCheck.GetComponentInChildren<Renderer>().bounds.center);
 
         //Is in front
         if (pointOnScreen.z < 0)
         {
             Debug.Log("Behind: " + toCheck.name);
             return false;
         }
 

        /*
         //Is in FOV
         if ((pointOnScreen.x < 0) || (pointOnScreen.x > Screen.width) ||
                 (pointOnScreen.y < 0) || (pointOnScreen.y > Screen.height))
         {
             Debug.Log("OutOfBounds: " + toCheck.name);
             return false;
         }

         */
 
        /* RaycastHit hit;
         Vector3 heading = toCheck.transform.position - origin.transform.position;
         Vector3 direction = heading.normalized;// / heading.magnitude;
         
         if (Physics.Linecast(cam.transform.position, toCheck.GetComponentInChildren<Renderer>().bounds.center, out hit))
         {
             if (hit.transform.name != toCheck.name)
             {
                 /* -->
                 Debug.DrawLine(cam.transform.position, toCheck.GetComponentInChildren<Renderer>().bounds.center, Color.red);
                 Debug.LogError(toCheck.name + " occluded by " + hit.transform.name);
                 
                 Debug.Log(toCheck.name + " occluded by " + hit.transform.name);
                 return false;
             }
         }*/
         return true;
     }

}

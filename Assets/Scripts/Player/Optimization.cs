using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Optimization : MonoBehaviour
{


    public Camera cam;
    public Transform PlayerPos;

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
        }



    }


    private bool IsVisible(Camera c, GameObject target){

        var planes = GeometryUtility.CalculateFrustumPlanes(c);
        var point = target.transform.position;

        foreach (var plane in planes)
        {
            if(plane.GetDistanceToPoint(point) > 0)
                return false;
        
        }
        return true;
    }

}

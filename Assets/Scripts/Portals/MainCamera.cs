using UnityEngine;

public class MainCamera : MonoBehaviour {


    public GameObject[] PopoList;
    Portal[] portals;

    void Awake () {
         PopoList = GameObject.FindGameObjectsWithTag("PortalNew");
         portals = new Portal [PopoList.Length];
         for(int i =0;i<PopoList.Length;i++)
            portals[i] = PopoList[i].GetComponent<Portal>();

    }

    void OnPreCull () {

        for (int i = 0; i < portals.Length; i++) {
            portals[i].PrePortalRender ();
        }
        for (int i = 0; i < portals.Length; i++) {
            portals[i].Render ();
        }

        for (int i = 0; i < portals.Length; i++) {
            portals[i].PostPortalRender ();
        }

    }

}
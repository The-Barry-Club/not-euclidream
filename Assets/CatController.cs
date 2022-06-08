using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatController : MonoBehaviour
{
    public Animator anim;
    public float speed;
    public Transform path;
    public Quest q;
    public List<Vector3> points;
    public float waittime;
    int pi;
    bool once;
    // Start is called before the first frame update
    void Start()
    {
        points = new List<Vector3>();
        path = q.paths[0];
        for (int i = 0; i < path.childCount; i++)
            points.Add(path.GetChild(i).position);
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (path != q.paths[q.current])
        {
            pi = 0;
            path = q.paths[q.current];
            points = new List<Vector3>();
            for (int i = 0; i < path.childCount; i++)
                points.Add(path.GetChild(i).position);
        }

        if (points.Count > 1 && transform.position != points[pi])
        {
            anim.SetBool("iswalk", true);
            transform.LookAt(points[pi]);
            transform.position = Vector3.MoveTowards(transform.position, points[pi], speed);
        }
        else
        {
            if (!once)
            {
                once = true;
                StartCoroutine(Wait());
            }
        }
    }
    IEnumerator Wait()
    {
        anim.SetBool("iswalk", false);
        yield return new WaitForSeconds(waittime);
        if (pi + 1 < points.Count)
            pi++;
        else
            pi = 0;
        once = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.tag);
        if (other.tag == "Check")
            q.current++;
    }
}

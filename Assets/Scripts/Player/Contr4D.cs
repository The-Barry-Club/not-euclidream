using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Contr4D : MonoBehaviour
{
    public GameObject[] shapes;
    public List<Shape4D> sh4d;

    public Quest q;

    public bool goodrot = false;
    bool allowrot = true;
    public float stoprot;

    public bool goodposx = false;
    bool allowposx = true;
    public float stopposx;
    // Start is called before the first frame update
    void Start()
    {
        sh4d = new List<Shape4D>();
        foreach (var shape in shapes)
            sh4d.Add(shape.GetComponent<Shape4D>());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            if (Input.GetKey("m"))
                foreach (Shape4D s in sh4d)
                    s.positionW += 0.1f;
            if (Input.GetKey("n"))
                foreach (Shape4D s in sh4d)
                    s.positionW -= 0.1f;
            if (Input.GetKey("t"))
                if (allowrot)
                    foreach (Shape4D s in sh4d)
                    {
                        s.rotationW.y += 1f;
                        if (goodrot && allowrot && (s.rotationW.y > stoprot || s.rotationW.y < -stoprot))
                        {
                            q.current++;
                            allowrot = false;
                        }
                    }
            if (Input.GetKey("r"))
                if (allowrot)
                    foreach (Shape4D s in sh4d)
                    {
                        s.rotationW.y -= 1f;
                        if (goodrot && allowrot && (s.rotationW.y > stoprot || s.rotationW.y < -stoprot))
                        {
                            q.current++;
                            allowrot = false;
                        }
                    }
            if (Input.GetKey("k"))
                if (allowposx)
                    foreach (var s in shapes)
                    {
                        s.transform.position += new Vector3(0.1f, 0, 0);
                        if (goodposx && allowposx && (s.transform.position.x < stopposx + 0.3f && s.transform.position.x > stopposx - 0.3f))
                        {
                            q.current++;
                            allowposx = false;
                        }
                    }

            if (Input.GetKey("j"))
                if (allowposx)
                    foreach (var s in shapes)
                    {
                        s.transform.position += new Vector3(-0.1f, 0, 0);
                        if (goodposx && allowposx && (s.transform.position.x < stopposx + 0.3f && s.transform.position.x > stopposx - 0.3f))
                        {
                            q.current++;
                            allowposx = false;
                        }
                    }
        }
    }
}

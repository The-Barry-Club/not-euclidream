using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Mathematics;

public class Contr4D : MonoBehaviour
{
    public GameObject[] shapes;
    public List<Shape4D> sh4d;

    public Quest q;
    public bool last;

    public bool goodrot = false;
    bool allowrot = true;
    public float stoprot;

    public bool goodposx = false;
    bool allowposx = true;
    public float stopposx;

    public bool goodposz = false;
    bool allowposz = true;
    public float stopposz;

    public bool goodposy = false;
    bool allowposy = true;
    public float stopposy;
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
                        if (goodrot && allowrot && (s.rotationW.y == stoprot || s.rotationW.y == -stoprot))
                        {
                            if (!last)
                                q.current++;
                            allowrot = false;
                        }
                    }
            if (Input.GetKey("r"))
                if (allowrot)
                    foreach (Shape4D s in sh4d)
                    {
                        s.rotationW.y -= 1f;
                        if (goodrot && allowrot && (s.rotationW.y == stoprot || s.rotationW.y == -stoprot))
                        {
                            if (!last)
                                q.current++;
                            allowrot = false;
                        }
                    }
            if (Input.GetKey("k") && allowposx && goodposx)
            {
                foreach (var s in shapes)
                    {
                        s.transform.position += new Vector3(0.1f, 0, 0);
                        if (goodposx && allowposx && (s.transform.position.x < stopposx + 0.3f && s.transform.position.x > stopposx - 0.3f))
                        {
                            q.current++;
                            allowposx = false;
                        }
                    }
            }

            if (Input.GetKey("j") && allowposx && goodposx)
            {
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

            if (Input.GetKey("g") && allowposz && goodposz)
            {
                foreach (var s in shapes)
                    {
                        s.transform.position += new Vector3(0, 0, 0.1f);
                        if (goodposz && allowposz && (s.transform.position.z < stopposz + 0.3f && s.transform.position.z > stopposz - 0.3f))
                        {
                            allowposz = false;
                        }
                    }
            }

            if (Input.GetKey("h") && allowposz && goodposz)
            {
                foreach (var s in shapes)
                    {
                        s.transform.position += new Vector3(0, 0, -0.1f);
                        if (goodposz && allowposz && (s.transform.position.z < stopposz + 0.3f && s.transform.position.z > stopposz - 0.3f))
                        {
                            allowposz = false;
                        }
                    }
            }

            if (Input.GetKey("o") && allowposy && goodposy)
            {
                foreach (var s in shapes)
                    {
                        s.transform.position += new Vector3(0, 0.1f, 0);
                        if (goodposy && allowposy && (s.transform.position.y < stopposy + 0.3f && s.transform.position.y > stopposy - 0.3f))
                        {
                            allowposy = false;
                        }
                    }
            }

            if (Input.GetKey("p") && allowposy && goodposy)
            {
                foreach (var s in shapes)
                    {
                        s.transform.position += new Vector3(0, -0.1f, 0);
                        if (goodposy && allowposy && (s.transform.position.y < stopposy + 0.3f && s.transform.position.y > stopposy - 0.3f))
                        {
                            allowposy = false;
                        }
                    }
            }
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//************ Based on the Shape script from https://github.com/SebLague/Ray-Marching
//************ Added rotation support and 4D PSR *************************************

public class Shape4D : MonoBehaviour
{
    public enum ShapeType { HyperSphere, HyperCube, DuoCylinder, plane, Cone, FiveCell, SixteenCell };
    public enum Operation { Union, Blend, Substract, Intersect };
    
    [Header("Shape Settings")]
    public ShapeType shapeType;
    public Operation operation;

    [Header("4D Transform Settings")]
    public float positionW;
    [Tooltip ("The rotation around the xw, yw and zw planes respectively")]
    public Vector3 rotationW;
    public float scaleW = 1f;

    [Header("Render Settings")]
    public Color colour;
    [Range (0,1)]
    public float smoothRadius;

    [Header("Moving")]
    public bool xpos;
    public bool ypos;
    public bool zpos;
    public bool wpos;
    public bool xrot;
    public bool yrot;
    public bool zrot;
    public bool wxrot;
    public bool wyrot;
    public bool wzrot;

    private Vector3 startPos;
    private Vector3 endPos;
    private Vector3 rotAng = new Vector3(720f, 720f, 720f);
    private Vector3 startRotw;
    private Vector3 endRotw;
    private float startPosw;
    private float endPosw;

    public float movSpeed = 1f;
    private float xmovSpeed = 1f;
    private float ymovSpeed = 1f;
    private float zmovSpeed = 1f;
    private float wmovSpeed = 1f;

    private float wxrotmovSpeed = 1f;
    private float wyrotmovSpeed = 1f;
    private float wzrotmovSpeed = 1f;

    [HideInInspector]
    public int numChildren;
    Vector4 parentScale = Vector4.one;
    private void Start()
    {
        xmovSpeed = movSpeed;
        ymovSpeed = movSpeed;
        zmovSpeed = movSpeed;
        wmovSpeed = movSpeed;

        wxrotmovSpeed = movSpeed*10;
        wyrotmovSpeed = movSpeed*10;
        wzrotmovSpeed = movSpeed*10;

        startPos = transform.position;
        endPos = startPos + new Vector3(5, 5, 5);

        startPosw = positionW;
        endPosw = startPosw + 5f;

        startRotw = rotationW;
        endRotw = startRotw + new Vector3(50, 50, 50);

}
    // returns the 4D position of the object
    public Vector4 Position()
    {
        return new Vector4(transform.position.x, transform.position.y, transform.position.z, positionW);
    }

    //returns the 3D rotation of the object
    public Vector3 Rotation()
    {
        return transform.eulerAngles * Mathf.Deg2Rad;
    }
    //returns the 3 remaining 4D rotation axis
    public Vector3 RotationW()
    {
        return rotationW * Mathf.Deg2Rad;
    }
    
    //returns the 4D scale of the object
    public Vector4 Scale()
    {
        if (transform.parent != null && transform.parent.GetComponent<Shape4D>() != null)
        {
            parentScale = transform.parent.GetComponent<Shape4D>().Scale();
        }
        else parentScale = Vector4.one;

        return Vector4.Scale(new Vector4(transform.localScale.x, transform.localScale.y, transform.localScale.z, scaleW), parentScale);

    }
    private void Update()
    {
        if(xpos)
        {
            if (transform.position.x >= endPos.x)
                xmovSpeed = -xmovSpeed;
            transform.Translate(Vector3.right * xmovSpeed * Time.deltaTime, Space.World);
            if (transform.position.x <= endPos.x - 5f)
                xmovSpeed = -xmovSpeed;
        }
        if (ypos)
        {
            if (transform.position.y >= endPos.y)
                ymovSpeed = -ymovSpeed;
            transform.Translate(Vector3.up * ymovSpeed * Time.deltaTime, Space.World);
            if (transform.position.y <= endPos.y - 5f)
                ymovSpeed = -ymovSpeed;
        }
        if (zpos)
        {
            if (transform.position.z >= endPos.z)
                zmovSpeed = -zmovSpeed;
            transform.Translate(Vector3.forward * zmovSpeed * Time.deltaTime, Space.World);
            if (transform.position.z <= endPos.z - 5f)
                zmovSpeed = -zmovSpeed;
        }
        if (wpos)
        {
            if (positionW >= endPosw)
                wmovSpeed = -wmovSpeed;
            positionW += wmovSpeed * Time.deltaTime;
            if (positionW <= startPosw)
                wmovSpeed = -wmovSpeed;
        }
        if (xrot)
        {
            transform.Rotate(rotAng.x * movSpeed * Time.deltaTime / 10, 0, 0, Space.World);
        }
        if (yrot)
        {
            transform.Rotate(0, rotAng.y * movSpeed * Time.deltaTime / 10, 0, Space.World);
        }
        if (zrot)
        {
            transform.Rotate(0, 0, rotAng.z * movSpeed * Time.deltaTime / 10, Space.World);
        }
        if (wxrot)
        {
            if (rotationW.x >= endRotw.x)
                wxrotmovSpeed = -wxrotmovSpeed;
            rotationW.x += wxrotmovSpeed * Time.deltaTime;
            if (rotationW.x <= startRotw.x)
                wxrotmovSpeed = -wxrotmovSpeed;
        }
        if (wyrot)
        {
            if (rotationW.y >= endRotw.y)
                wyrotmovSpeed = -wyrotmovSpeed;
            rotationW.y += wyrotmovSpeed * Time.deltaTime;
            if (rotationW.y <= startRotw.y)
                wyrotmovSpeed = -wyrotmovSpeed;
        }
        if (wzrot)
        {
            if (rotationW.z >= endRotw.z)
                wzrotmovSpeed = -wzrotmovSpeed;
            rotationW.z += wzrotmovSpeed * Time.deltaTime;
            if (rotationW.z <= startRotw.z)
                wzrotmovSpeed = -wzrotmovSpeed;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Change
{
    transform,
    rotate
}
public class ChangeScript : MonoBehaviour
{
    public Change change;
    private Quaternion rot1;
    private Quaternion rot2;
    Transform transformAddRot;
    [Header("CHANGE ROTATION")]
    public float extraXRot;
    public float extraYRot;
    public float extraZRot;
    [Space(10)]
    private Vector3 pos1;
    private Vector3 pos2;
    Transform transformAdd;
    [Header("CHANGE POSITION")]
    public float extraXPos;
    public float extraYPos;
    public float extraZPos;

    public bool isOpen;
     
    void Start()
    {
        transformAddRot = GetComponent<Transform>();
        rot1 = transform.rotation;


        transformAdd = GetComponent<Transform>();
        pos1 = transform.position;
        pos2 = transform.position + new Vector3(extraXPos, extraYPos, extraZPos);

    }

    void OnMouseDown()
    {
        switch (change)
        {
            case Change.transform:
                if (transform.position.Equals(pos1))
                {
                    transform.position = pos2;
                    isOpen = true;
                }
                else
                {
                    transform.position = pos1;
                    isOpen = false;
                }
                break;

            case Change.rotate:
                if (transform.rotation.Equals(rot1))
                {
                    transform.Rotate(transform.position + new Vector3(extraXRot, extraYRot, extraZRot));
                    isOpen = true;
                }
                else
                {
                    transform.rotation = rot1;
                    isOpen = false;
                }
                break;
               
            default:
                break;
        }
       
    }
}

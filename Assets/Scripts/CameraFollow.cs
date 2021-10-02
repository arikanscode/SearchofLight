using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    private Transform playerTransform;
    [SerializeField] private float smoothX;
    [SerializeField] private float smoothY;
    [SerializeField] private float minX;
    [SerializeField] private float maxX;
    [SerializeField] private float minY;
    [SerializeField] private float maxY;


    private void Start()
    {
        playerTransform = GameObject.Find("Player").transform;

        
    }
    void LateUpdate()
    {
        float posX = Mathf.MoveTowards(transform.position.x, playerTransform.position.x, smoothX);
        float posY = Mathf.MoveTowards(transform.position.y, playerTransform.position.y+2f, smoothX);

        transform.position = new Vector3(Mathf.Clamp(posX,minX,maxX),Mathf.Clamp( posY,minY,maxY),transform.position.z);
        
    }

}

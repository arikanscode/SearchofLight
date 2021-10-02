using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashlightFollow : MonoBehaviour
{
    public Transform player;


    void FixedUpdate()
    {
        Vector3 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        //difference.Normalize();
        float rotation = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;

        if (player.transform.localScale == new Vector3(1, 1, 1))
        {
            transform.localRotation = Quaternion.Euler(0, 0, rotation);
        }

        if (player.transform.localScale == new Vector3(-1, 1, 1))
        {
            transform.localRotation = Quaternion.Euler(180, 180f, -rotation);
        }
    }
}
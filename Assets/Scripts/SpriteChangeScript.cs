using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteChangeScript : MonoBehaviour
{

    public Sprite sp1, sp2;
    SpriteRenderer sr;
    public bool lightsIsReady;
   
    void Start()
    {
        sr = gameObject.GetComponent<SpriteRenderer>();
    }
    void OnMouseDown()
    {
        if (sr.sprite.Equals(sp1))
        {
            sr.sprite = sp2;
            lightsIsReady = true;

        }
        else
            sr.sprite = sp1;
    }
}

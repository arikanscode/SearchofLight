using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public GameObject notePad;

    public bool notePadActive;


    // Start is called before the first frame update
    void Start()
    {
        notePad.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            notePadActive = !notePadActive;
        }
        if (notePadActive)
        {
            notePad.SetActive(true);
        }
        else
        {
            notePad.SetActive(false);
        }
       


    }
}

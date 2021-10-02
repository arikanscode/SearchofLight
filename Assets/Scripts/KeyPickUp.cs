using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KeyPickUp : MonoBehaviour
{

    [SerializeField]
    private Text pickUpText;
    private PlayerMovement player;

    private bool pickUpAllowed;
    public ChangeScript frontObject;



    // Start is called before the first frame update
    void Start()
    {
        pickUpText.gameObject.SetActive(false);
        
        
    }

    // Update is called once per frame
    void Update()
    {
        if (pickUpAllowed && Input.GetKeyDown(KeyCode.E)) 
        {
            PickUp(player);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag=="Player" && frontObject.isOpen)
        {
            pickUpText.gameObject.SetActive(true);
            pickUpAllowed = true;
            player = collision.GetComponent<PlayerMovement>();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag=="Player")
        {
            pickUpText.gameObject.SetActive(false);
            pickUpAllowed = false;
            player = null;
        }
    }

    public void PickUp(PlayerMovement player)
    {
        GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>().PlayerAudio();
        player.keyCount++;
        Destroy(gameObject);
        pickUpText.gameObject.SetActive(false);
    }
}

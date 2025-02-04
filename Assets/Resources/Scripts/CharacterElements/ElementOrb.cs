using System.Collections.Generic;
using Invector.vCharacterController;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.UI;

public class ElementOrb : MonoBehaviour
{

    private GameObject player;
    private GameObject playerGO;
    private ElementController controller;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

        player = GameObject.FindGameObjectWithTag("Players");
        controller = player.GetComponent<ElementController>();
        

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        
        if (collision.gameObject.tag == "Wind")
        {
            controller.waterActive = false;
            controller.fireActive = false;
            controller.grappleActive = false;
            Destroy(collision.gameObject);
            player.GetComponent<ElementController>().elementSlot = 1;
            Invoke(nameof(TriggerAnim), 0.2f);

            controller.windFound = true;
           

        } else if (collision.gameObject.tag == "Grass")
        {
            controller.waterActive = false;
            controller.fireActive = false;
            controller.windActive = false;
            Destroy(collision.gameObject);
            player.GetComponent<ElementController>().elementSlot = 2;
            Invoke(nameof(TriggerAnim), 0.2f);
            controller.grappleFound = true;
            
        } else if(collision.gameObject.tag == "Fire")
        {
            controller.waterActive = false;
            controller.grappleActive = false;
            controller.windActive= false;
            Destroy(collision.gameObject);
            player.GetComponent<ElementController>().elementSlot = 3;
            Invoke(nameof(TriggerAnim), 0.2f);
            controller.fireFound = true;
            
        } else if (collision.gameObject.tag == "Ice")
        {
            controller.windActive = false;
            controller.fireActive = false;
            controller.grappleActive = false;
            Destroy(collision.gameObject);
            player.GetComponent<ElementController>().elementSlot = 4;
            Invoke(nameof(TriggerAnim), 0.2f);
            controller.waterFound = true;
        }

    }

    private void TriggerAnim()
    {
        playerGO = GameObject.FindGameObjectWithTag("Player");
        playerGO.GetComponent<Animator>().SetTrigger("Power");
    }
}

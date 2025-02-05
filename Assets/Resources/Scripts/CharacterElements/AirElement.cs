using Invector.vCharacterController;
using UnityEngine;

public class AirElement : MonoBehaviour
{

    private vThirdPersonMotor controller;
    private GameObject players;
    private ElementController elcontroller;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        controller = GetComponent<vThirdPersonMotor>();
        players = GameObject.FindGameObjectWithTag("Players");
        elcontroller = players.GetComponent<ElementController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (elcontroller.windActive) 
        {
            controller.jumpHeight = 8f;
            controller.freeSpeed.walkSpeed = 4f;
            controller.freeSpeed.runningSpeed = 4f;
            controller.freeSpeed.sprintSpeed = 8f;
            
        } else
        {
            controller.jumpHeight = 2.5f;
        }
        
    }
}

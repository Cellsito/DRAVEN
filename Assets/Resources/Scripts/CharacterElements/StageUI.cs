using UnityEngine;
using UnityEngine.InputSystem.XR;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StageUI : MonoBehaviour
{

    public Sprite NoPower;
    public Sprite WindStage;
    public Sprite GrassStage;
    public Sprite IceStage;
    public Sprite FireStage;
    private ElementController elcontroller;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

        GameObject player = GameObject.FindWithTag("Players");
        if (player != null)
        {
            elcontroller = player.GetComponent<ElementController>();
        }


    }

    // Update is called once per frame
    void Update()
    {
        Image element;

        element = gameObject.GetComponent<Image>();

        if (elcontroller.fireFound)
        {
            element.sprite = FireStage;
        }
        else if (elcontroller.waterFound)
        {
            element.sprite = IceStage;
        }

        else if (elcontroller.grappleFound)
        {
            element.sprite = GrassStage;

        }
        else if (elcontroller.windFound) 
        {
            element.sprite = WindStage;
        
        } else
        {
            element.sprite = NoPower;
        }
    }
}

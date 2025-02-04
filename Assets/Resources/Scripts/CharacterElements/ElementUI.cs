using UnityEngine;
using UnityEngine.UI;

public class ElementUI : MonoBehaviour
{

    public Sprite fireElement;
    public Sprite windElement;
    public Sprite grappleElement;
    public Sprite waterElement;
    public Sprite noElement;
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

        if (elcontroller.fireActive)
        {
            element.sprite = fireElement;
        }

        else if (elcontroller.windActive)
        {
            element.sprite = windElement;
        }

        else if (elcontroller.grappleActive) 
        { 
            element.sprite = grappleElement;
        
        }

        else if (elcontroller.waterActive) 
        {
            element.sprite = waterElement;
        } else
        {
            element.sprite = noElement;
        }


    }
}

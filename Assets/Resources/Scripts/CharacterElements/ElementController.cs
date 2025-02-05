
using UnityEngine;

public class ElementController : MonoBehaviour
{

    public int medallionCounter = 0;

    public bool windFound;
    public bool windActive;

    public bool grappleFound;
    public bool grappleActive;

    public bool fireFound;
    public bool fireActive;

    public bool waterFound;
    public bool waterActive;

    public int elementSlot = 1;

    private ChangeElement changeElement;
    public AudioSource audioSource;
    public AudioClip audioClip;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        changeElement = GetComponent<ChangeElement>();
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.E))
        {

            audioSource.clip = audioClip;
            audioSource.Play();
            windActive = false;
            fireActive = false;
            waterActive = false;
            grappleActive = false;

            if (elementSlot == 4)
            {
                elementSlot = 0;
            }
            elementSlot++;
        }

        if (Input.GetKeyDown(KeyCode.Q)) {
            audioSource.clip = audioClip;
            audioSource.Play();
            windActive = false;
            fireActive = false;
            waterActive = false;
            grappleActive = false;
            elementSlot--;
            if (elementSlot == 0)
            {
                
                elementSlot = 4;
            }
            
        }

        if (elementSlot == 1)
        {
            if (windFound)
            {
                windActive = true;
                changeElement.WindElement();
            }
            else
            {
                changeElement.NoElement();
            }
        }

        if (elementSlot == 2)
        {
            if (grappleFound)
            {
                grappleActive = true;
                changeElement.GrassElement();
            }
            else
            {
                changeElement.NoElement();
            }
        }

        if (elementSlot == 3)
        {
            if (fireFound)
            {
                fireActive = true;
                changeElement.FireElement();
            }
            else
            {
                changeElement.NoElement();
            }
        }

        if (elementSlot == 4)
        {
            if (waterFound)
            {
                waterActive = true;
                changeElement.IceElement();
            } else
            {
                changeElement.NoElement();
            }
        }
    }
}

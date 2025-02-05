using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class MainMenuUI : MonoBehaviour
{
    string UITag;
    public AudioSource audioSource;
    public AudioClip hoverClip;
    public AudioClip pressedClip;
    public GameObject start;
    public GameObject easy;
    public GameObject normal;
    public GameObject hard;
    public GameObject back;
    private Vector3 initialScale;
    private RaycastResult curRaysastResult;
    public Difficulty difficulty;
    private string overUI;
    
    private void Start()
    {
        initialScale = transform.localScale;
        difficulty.difficultyID = 0;
    }

    private void Update()
    {
        if (IsMouseOn("StartUI"))
        {
            if (overUI != "StartUI")
            {
                audioSource.clip = hoverClip;
                audioSource.Play();
                overUI = "StartUI";
            }
            IncreaseScale(true, start);
            if (Input.GetMouseButtonDown(0)) {
                start.SetActive(false);
                easy.SetActive(true);
                normal.SetActive(true);
                hard.SetActive(true);
                back.SetActive(true);
            }
        } else if (IsMouseOn("EasyUI"))
        {
            IncreaseScale(true, easy);
            if (overUI != "EasyUI")
            {
                audioSource.clip = hoverClip;
                audioSource.Play();
                overUI = "EasyUI";
            }
            if (Input.GetMouseButtonDown(0))
            {
                audioSource.clip = pressedClip;
                audioSource.Play();
                SceneManager.LoadScene("mapa");
                difficulty.difficultyID = 1;
            }
            
        } else if (IsMouseOn("NormalUI"))
        {
            if (overUI != "NormalUI")
            {
                audioSource.clip = hoverClip;
                audioSource.Play();
                overUI = "NormalUI";
            }
            IncreaseScale(true, normal);
            if (Input.GetMouseButtonDown(0))
            {
                audioSource.clip = pressedClip;
                audioSource.Play();
                SceneManager.LoadScene("mapa");
                difficulty.difficultyID = 2;
            }

        } else if (IsMouseOn("HardUI"))
        {
            if (overUI != "HardUI")
            {
                audioSource.clip = hoverClip;
                audioSource.Play();
                overUI = "HardUI";
            }
            IncreaseScale(true, hard);
            if (Input.GetMouseButtonDown(0))
            {
                audioSource.clip = pressedClip;
                audioSource.Play();
                SceneManager.LoadScene("mapa");
                difficulty.difficultyID = 3;
            }
        } else if (IsMouseOn("Back"))
        {
            IncreaseScale(true, back);
            if (overUI != "Back")
            {
                audioSource.clip = hoverClip;
                audioSource.Play();
                overUI = "Back";
            }

            if (Input.GetMouseButtonDown(0))
            {
                audioSource.clip = pressedClip;
                audioSource.Play();
                easy.SetActive(false);
                normal.SetActive(false);
                hard.SetActive(false);
                back.SetActive(false);
                start.SetActive(true);
            }
        }
        
        else
        {
            overUI = null;
            IncreaseScale(false, start);
            IncreaseScale(false, easy);
            IncreaseScale(false, normal);
            IncreaseScale(false, hard);
            IncreaseScale(false, back);
        }



    }


    //Returns 'true' if we touched or hovering on Unity UI element.
    public bool IsMouseOn(string tag)
    {
        UITag = tag;
        
        return IsPointerOverUIElement(GetEventSystemRaycastResults());
    }


    //Returns 'true' if we touched or hovering on Unity UI element.
    private bool IsPointerOverUIElement(List<RaycastResult> eventSystemRaysastResults)
    {
        for (int index = 0; index < eventSystemRaysastResults.Count; index++)
        {
            curRaysastResult = eventSystemRaysastResults[index];
            if (curRaysastResult.gameObject.tag == UITag)
                return true;
        }
        return false;
    }


    //Gets all event system raycast results of current mouse or touch position.
    static List<RaycastResult> GetEventSystemRaycastResults()
    {
        PointerEventData eventData = new PointerEventData(EventSystem.current);
        eventData.position = Input.mousePosition;
        List<RaycastResult> raysastResults = new List<RaycastResult>();
        EventSystem.current.RaycastAll(eventData, raysastResults);
        return raysastResults;
    }

    private void IncreaseScale(bool status, GameObject go)
    {
        Vector3 finalScale = initialScale;

        if (status) {
            finalScale = initialScale * 1.1f;
        }

        if (go != null)
        {
            go.transform.localScale = finalScale;
           
        }
    }
}

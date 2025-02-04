using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using UnityEngine;

public class IceFloor : MonoBehaviour
{

    ElementController controller;
    private List<GameObject> ices;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        controller = GetComponent<ElementController>();
        ices = new List<GameObject>();
        ices = GameObject.FindGameObjectsWithTag("IceFloor").ToList();
    }

    // Update is called once per frame
    void Update()
    {
            foreach (GameObject item in ices)
            {
            if (controller.waterActive)
            {
                if (ices != null)
                {
                    if (!item.activeSelf)
                    {
                        item.SetActive(true);
                    }
                }
            } else
            {
                if (ices != null)
                {
                    if (item.activeSelf) { 
                        item.SetActive(false);
                    }
            }
        }

        }
    }
}

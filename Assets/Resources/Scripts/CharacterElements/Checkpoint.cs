using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;

public class Checkpoint : MonoBehaviour
{

    public bool Activated;
    public float cpDistanceFromPlayer;
    public float cpDistanceToInteract;
    public float cpDistanceToExist;
    public bool NearEnough;

    public Transform cpPosition;
    private GameObject player;

    public Transform spawnPos;
    public static Transform spawnPosition;

    public static List<GameObject> checkpointList;
    public GameObject cpUI;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        checkpointList = GameObject.FindGameObjectsWithTag("Checkpoint").ToList();
    }

    // Update is called once per frame
    void Update()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        

        cpDistanceFromPlayer = Vector3.Distance(cpPosition.transform.position, player.transform.position);

        if (cpDistanceFromPlayer < cpDistanceToInteract)
        {
            
            if (Activated) {
                if (cpUI != null) {
                    cpUI.GetComponent<TextMeshProUGUI>().text = "Checkpoint ativo!";
                }
                
            } else
            {
                if (cpUI != null)
                {
                    cpUI.GetComponent<TextMeshProUGUI>().text = "Aperte C para salvar o checkpoint!";
                }
                
            }
            
            NearEnough = true;
            if (cpUI != null) 
            {
                if (!cpUI.activeSelf && NearEnough == true) 
                {
                    cpUI.SetActive(true);
                }
            }  

            if (Input.GetKeyDown(KeyCode.C))
            {

                ActivateCheckPoint();

                Debug.Log("Checkpoint Salvo");

            }
        } else
        {
            if (cpDistanceFromPlayer < cpDistanceToExist) 
            {
                NearEnough = false;
                if (cpUI != null)
                {
                    if (cpUI.activeSelf)
                    {
                        cpUI.SetActive(false);
                    }
                }
            }
            
        }
    }


    public static Vector3 GetActiveCheckPointPosition()
    {
        // If player die without activate any checkpoint, we will return a default position
        Vector3 result = new Vector3(10, 10, 0);

        if (checkpointList != null)
        {
            foreach (GameObject cp in checkpointList)
            {
                // We search the activated checkpoint to get its position
                if (cp.GetComponent<Checkpoint>().Activated)
                {
                    result = cp.GetComponent<Checkpoint>().spawnPos.position;
                    break;
                }
            }
        }
        return result;
    }
        

    private void ActivateCheckPoint()
    {
        // We deactivate all checkpoints in the scene
        foreach (GameObject cp in checkpointList)
        {
            cp.GetComponent<Checkpoint>().Activated = false;
        }

        Activated = true;
    }

    public static GameObject GetActiveCheckPoint()
    {
        if (checkpointList != null)
        {
            foreach (GameObject cp in checkpointList)
            {
                if (cp.GetComponent<Checkpoint>().Activated) return cp;
            }
        }
        return null;
    }

    public bool isPlayerNearEnoughCP()
    {
        cpDistanceFromPlayer = Vector3.Distance(cpPosition.transform.position, player.transform.position);

        if (cpDistanceFromPlayer < cpDistanceToInteract)
        {
            return true;
        } else
        {
            return false;
        }
        
        
    }
}

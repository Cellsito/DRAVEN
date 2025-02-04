using System.Collections.Generic;
using UnityEngine;

public class ChangeElement : MonoBehaviour
{

    public GameObject noElement;
    public GameObject wind;
    public GameObject fire;
    public GameObject ice;
    public GameObject grass;
    private GameObject mainCamera;
    private vThirdPersonCamera camera;
    private GameObject player;
    private ElementController elcontroller;
    private List<GameObject> players = new List<GameObject>();

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

        mainCamera = GameObject.FindGameObjectWithTag("MainCamera");
        camera = mainCamera.GetComponent<vThirdPersonCamera>();
        player = GameObject.FindWithTag("Player");
        elcontroller = GetComponent<ElementController>();

        players.Add(noElement);
        players.Add(ice);
        players.Add(fire);
        players.Add(grass);
        players.Add(wind);

        
    }

    public void DeactivateAll()
    {
        noElement.SetActive(false);
        wind.SetActive(false);
        fire.SetActive(false);
        ice.SetActive(false);
        grass.SetActive(false);
    }

    public void NoElement()
    {
        if (noElement.activeSelf == true) return;
        Debug.Log(player);
        noElement.transform.position = GetPlayer().transform.position;
        DeactivateAll();
        noElement.SetActive(true);
        
        camera.currentTarget = noElement.transform;
    }

    public void WindElement()
    {
        if (wind.activeSelf == true) return;
        Debug.Log(player);
        wind.transform.position = GetPlayer().transform.position;
        DeactivateAll();
        
        wind.SetActive(true);
        wind.GetComponent<Rigidbody>().linearVelocity = new Vector3(0, 0 ,0);

        camera.currentTarget = wind.transform;
    }

    public void FireElement()
    {
        if (fire.activeSelf == true) return;
        Debug.Log(player);
        fire.transform.position = GetPlayer().transform.position;
        DeactivateAll();
        
        fire.SetActive(true);
        

        camera.currentTarget = fire.transform;
    }

    public void IceElement()
    {
        if (ice.activeSelf == true) return;
        Debug.Log(player);
        ice.transform.position = GetPlayer().transform.position;
        DeactivateAll();
        
        ice.SetActive(true);
        
        camera.currentTarget = ice.transform;
    }

    public void GrassElement()
    {
        if (grass.activeSelf == true) return;
        Debug.Log(player);
        grass.transform.position = GetPlayer().transform.position;
        DeactivateAll();

        grass.SetActive(true);
        camera.currentTarget = grass.transform;
    }

    private GameObject activatedPlayer;
    GameObject GetPlayer()
    {
        activatedPlayer = null; // Reseta antes de procurar

        foreach (GameObject pl in players)
        {
            if (pl != null && pl.activeSelf)
            {
                activatedPlayer = pl;
                break; // Encontrou o player ativo, pode sair do loop
            }
        }

        if (activatedPlayer == null)
        {
            Debug.LogError("Nenhum player ativo encontrado!");
        }

        return activatedPlayer;
    }
}

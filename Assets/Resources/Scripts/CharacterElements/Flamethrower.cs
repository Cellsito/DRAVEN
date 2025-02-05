using System;
using System.Collections.Generic;
using Invector.vCharacterController;
using Unity.VisualScripting;
using UnityEngine;

public class Flamethrower : MonoBehaviour
{

    [Header("References")]
    public Transform cam;
    public Transform gunTip;
    public LayerMask whatIsFlameble;
    public LineRenderer lr;
    public AudioSource audioSource;
    public AudioClip fireSound;

    [Header("Flamethrower")]
    public float maxFlameDistance;
    public float flameDelayTime;
    public Material flameMaterial;

    private Vector3 hitPoint;
    private GameObject hitPointGameObject;

    [Header("Cooldown")]
    public float flamingCd;
    private float flamingCdTimer;

    [Header("Input")]
    public KeyCode flamingKey = KeyCode.Mouse1;

    public bool flaming;
    private ElementController elcontroller;
    private GameObject players;
    private GameObject player;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        players = GameObject.FindGameObjectWithTag("Players");
        elcontroller = players.GetComponent<ElementController>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(flamingKey)) StartFlame();

        player = GameObject.FindGameObjectWithTag("Player");

        if (flamingCdTimer > 0)
        {
            flamingCdTimer -= Time.deltaTime;
        }
    }

    private void LateUpdate()
    {
        if (flaming)
        {
            lr.SetPosition(0, gunTip.position);
        }
    }

    private void StartFlame()
    {
        if (flamingCdTimer > 0 || !elcontroller.fireFound || !elcontroller.fireActive) return;

        player.GetComponent<Animator>().SetTrigger("Slash");

        RaycastHit hit;
        if (Physics.Raycast(cam.position, cam.forward, out hit, maxFlameDistance, whatIsFlameble))
        {
            hitPoint = hit.point;
            hitPointGameObject = hit.transform.gameObject;

            Invoke(nameof(ExecuteFlame), flameDelayTime);
        } else
        {
            hitPoint = cam.position + cam.forward * maxFlameDistance;

            Invoke(nameof(StopFlame), flameDelayTime + 1);
        }
        Invoke(nameof(DelayString), flameDelayTime);
    }

    private void ExecuteFlame()
    {
        foreach (GameObject go in hitPointGameObject.GetAllChilds())
        {
            go.GetComponent<Rigidbody>().useGravity = true;
            go.GetComponent<Renderer>().material = flameMaterial;
            audioSource.clip = fireSound;
            audioSource.Play();
        }

        Invoke(nameof(StopFlame), flameDelayTime);
    }

    public void StopFlame()
    {


        flaming = false;

        flamingCdTimer = flamingCd;

        lr.enabled = false;

        if (hitPointGameObject!= null) hitPointGameObject.SetActive(false);

        Invoke(nameof(DestroyObjects), 6f);
    }

    private void DelayString()
    {
        flaming = true;

        lr.enabled = true;
        lr.SetPosition(1, hitPoint);

    }

    private void DestroyObjects()
    {
        if (hitPointGameObject!= null) hitPointGameObject.GetAllChilds().ForEach(GameObject.Destroy);


    }

}

public static class ClassExtension
{
    public static List<GameObject> GetAllChilds(this GameObject Go)
    {
        List<GameObject> list = new List<GameObject>();
        if (Go.transform.childCount != 0) 
        {
            for (int i = 0; i < Go.transform.childCount; i++)
            {
                list.Add(Go.transform.GetChild(i).gameObject);
            }
            
        } else
        {
            Debug.Log("GameObject inválido para fogo!");
            return null;
        }
        return list;
    }
}

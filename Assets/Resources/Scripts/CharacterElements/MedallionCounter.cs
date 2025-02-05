using UnityEngine;

public class MedallionCounter : MonoBehaviour
{

    public GameObject wall;
    public GameObject player;
    private ElementController controller;
    public AudioSource audioSource;
    public AudioClip clip;
    

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
        
    }

    // Update is called once per frame
    void Update()
    {
        controller = player.GetComponent<ElementController>();
        if (controller.medallionCounter >= 4)
        {
            if (wall != null)
            {
                if (wall.activeSelf)
                {
                    Destroy(wall);
                }
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Medallion")
        {
            controller.medallionCounter++;
            Destroy(collision.gameObject);
            audioSource.clip = clip;
            audioSource.Play();
            
        }
    }
}

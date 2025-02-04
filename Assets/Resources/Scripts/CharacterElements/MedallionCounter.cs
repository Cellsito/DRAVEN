using UnityEngine;

public class MedallionCounter : MonoBehaviour
{

    public GameObject wall;
    public int counter;
    

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        counter = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (counter >= 4)
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
            counter++;
            Destroy(collision.gameObject);
            
        }
    }
}

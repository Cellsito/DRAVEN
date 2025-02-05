using UnityEngine;

public class Finale : MonoBehaviour
{

    public GameObject finalMedallion;

    private GameObject fade;
    public GameObject credits;
    public GameObject countdown;
    public GameObject background;
    public AudioClip finalSong;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        fade = GameObject.FindGameObjectWithTag("Fade");

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Final")
        {

            background.GetComponent<AudioSource>().clip = finalSong;
            background.GetComponent<AudioSource>().Play();

            fade.GetComponent<Animator>().SetTrigger("Fade");
            credits.SetActive(true);
            credits.GetComponent<Animator>().SetTrigger("Credits");

            Destroy(countdown);
            Destroy(collision.gameObject);
        }
    }
}

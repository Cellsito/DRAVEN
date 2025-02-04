using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Countdown : MonoBehaviour
{

    public int segundos;
    public int minutos;
    public float timer;
    public Difficulty difficulty;
    public GameObject fade;
    public GameObject gameOver;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

        

        if (difficulty.difficultyID == 1)
        {
            timer = 35 * 60;
            Debug.Log("Fácil");
        } else if (difficulty.difficultyID == 2) {
            timer = 25 * 60;
            Debug.Log("Normal");
        } else if (difficulty.difficultyID == 3)
        {
            timer = 15 * 60;
            Debug.Log("Difícil");
        } else
        {
            Destroy(gameObject);
        }
    }

    // Update is called once per frame

    string segundosFix;
    string minutosFix;
    void Update()
    {
        timer -= Time.deltaTime;
        minutos = (int)timer / 60;
        segundos = (int)timer % 60;

        minutosFix = (minutos > 0) ? (minutos < 10) ? "0" + minutos.ToString() + ":" : minutos.ToString() + ":" : null;
        segundosFix = (segundos < 10) ? "0" + segundos.ToString() : segundos.ToString();

        if (segundos >= 0)
        {
            GetComponent<TextMeshProUGUI>().text = minutosFix + segundosFix;
        }
        
        
        if (((int)timer) == 0)
        {
            fade.GetComponent<Animator>().SetTrigger("Fade");
            gameOver.GetComponent<Animator>().SetTrigger("GameOver");
            GetComponent<TextMeshProUGUI>().text = null;

        }
        if (segundos == -10)
        {
            SceneManager.LoadScene("MainMenu");
        }

    }
}

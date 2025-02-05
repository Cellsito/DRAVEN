using TMPro;
using UnityEngine;
using UnityEngine.InputSystem.XR;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{

    public int lifes;
    public Difficulty difficulty;
    public GameObject LifeText;
    public GameObject LifeRoot;
    public GameObject player;
    public GameObject fade;
    public GameObject gameOver;
    public GameObject countdown;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (difficulty.difficultyID == 0)
        {
            lifes = 999;
        } else if (difficulty.difficultyID == 1)
        {
            lifes = 5;
        } else if (difficulty.difficultyID == 2)
        {
            lifes = 3;
        } else if (difficulty.difficultyID == 3) {
            lifes = 1;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (LifeText != null)
        {
            LifeText.GetComponent<TextMeshProUGUI>().text = lifes.ToString();
        }


        if (!(lifes > 0))
        {
            if (LifeRoot != null)
            {
                Invoke(nameof(MainMenu), 10f);
                Destroy(LifeRoot);
                Destroy(player);
            }

            if (player != null)
            {

                fade.GetComponent<Animator>().SetTrigger("Fade");
                gameOver.GetComponent<Animator>().SetTrigger("GameOver");
                if (countdown != null)
                {
                    Destroy(countdown);
                }
            }
        }
    }

    private void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}

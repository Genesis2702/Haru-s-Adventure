using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEditor.SearchService;

public class GameManager : MonoBehaviour
{
    private int score = 0;
    public int multiplier = 1;
    private float scoreMultiplierDuration = 10.0f;
    public TextMeshProUGUI scoreText;
    private PlayerController playerControllerScript;
    public GameObject gameOverText;
    public Button tryAgainButton;
    public Button homeButton;
    public Button optionButton;
    public GameObject optionMenu;
    public Button continueButton;
    public Button quitButton;
    public bool inOptionMenu = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        ScoreUpdating(score);
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (playerControllerScript.isAlive)
        {
            if (multiplier == 2)
            {
                scoreMultiplierDuration -= Time.deltaTime;
                if (scoreMultiplierDuration < 0)
                {
                    multiplier = 1;
                    scoreMultiplierDuration = 10.0f;
                }
            }
        }
        GameOver();
    }

    public void ScoreUpdating(int scoreToAdd)
    {
        score += scoreToAdd * multiplier;
        scoreText.text = "SCORE: " + score;
    }

    private void GameOver()
    {
        if (!playerControllerScript.isAlive && inOptionMenu)
        {
            gameOverText.SetActive(true);
            tryAgainButton.gameObject.SetActive(true);
            homeButton.gameObject.SetActive(true);
        }
    }

    public void GameRestarting()
    {
        SceneManager.LoadScene(1);
    }

    public void HomeScreen()
    {
        SceneManager.LoadScene(0);
    }

    public void Option()
    {
        inOptionMenu = true;
        optionMenu.SetActive(true);
        continueButton.gameObject.SetActive(true);
        homeButton.gameObject.SetActive(true);
        quitButton.gameObject.SetActive(true);
    }

    public void Continue()
    {
        inOptionMenu = false;
        optionMenu.SetActive(false);
        continueButton.gameObject.SetActive(false);
        homeButton.gameObject.SetActive(false);
        quitButton.gameObject.SetActive(false);
    }

    public void Quit()
    {
        Application.Quit();
    }
}

using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndMenuController : MonoBehaviour
{
    public TextMeshProUGUI scoreText; 

    void Start()
    {
        if (ScoreManager.instance != null)
        {
            scoreText.text = "Score: " + ScoreManager.instance.score;
        }
    }
    // Called when the Play button is clicked
    public void OnPlayButtonClick()
    {
        SceneManager.LoadScene("MainMenu"); // Load the Main Menu scene
    }
    // Called when the Quit button is clicked
    public void OnQuitButtonClick()
    {
        Application.Quit(); // Quit the game
    }
}
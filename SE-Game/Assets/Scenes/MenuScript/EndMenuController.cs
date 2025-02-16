using UnityEngine;
using UnityEngine.SceneManagement;

public class EndMenuController : MonoBehaviour
{
    // Called when the Play button is clicked
    public void OnPlayButtonClick()
    {
        SceneManager.LoadScene("Gameplay"); // Load the Gameplay scene
    }
    // Called when the Quit button is clicked
    public void OnQuitButtonClick()
    {
        Application.Quit(); // Quit the game
    }
}
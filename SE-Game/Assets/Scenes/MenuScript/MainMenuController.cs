using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    public GameObject instructionsPanel; // Reference to the Instructions Panel

    // Called when the Play button is clicked
    public void OnPlayButtonClick()
    {
        SceneManager.LoadScene("Gameplay"); // Load the Gameplay scene
    }

    // Called when the Instructions button is clicked
    public void OnInstructionsButtonClick()
    {
        instructionsPanel.SetActive(!instructionsPanel.activeSelf); // Toggle the panel
    }

    // Called when the Quit button is clicked
    public void OnQuitButtonClick()
    {
        Application.Quit(); // Quit the game
    }

    // In MainMenuController.cs
    public void CloseInstructionsPanel()
    {
        instructionsPanel.SetActive(false);
    }
}
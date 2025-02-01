using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class MainMenu : MonoBehaviour
{
    private Button playButton;

    void Start()
    {
        // Get the UI Document and assign the play button
        var root = GetComponent<UIDocument>().rootVisualElement;
        playButton = root.Q<Button>("Play"); // Match the button's name in UI Builder

        if (playButton != null)
        {
            playButton.clicked += OnPlayButtonClicked;
        }
    }

    private void OnPlayButtonClicked()
    {
        Debug.Log("Play button clicked! Loading the game...");
        SceneManager.LoadScene(1); // Replace "GameScene" with the name of your game scene
    }

    private void OnDestroy()
    {
        // Clean up to avoid memory leaks
        if (playButton != null)
        {
            playButton.clicked -= OnPlayButtonClicked;
        }
    }
}

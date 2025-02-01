using UnityEngine;
using TMPro;

public class QuestUI : MonoBehaviour
{
    public TextMeshProUGUI questText; // Use TextMeshProUGUI for TextMeshPro support

    private QuestSystem questSystem;

    private void Start()
    {
        // Find the QuestSystem in the scene
        questSystem = FindObjectOfType<QuestSystem>();

        if (questSystem != null)
        {
            // Subscribe to the QuestSystem events
            questSystem.OnQuestUpdated += UpdateQuestDisplay;
            questSystem.OnQuestCompleted += DisplayCompletionMessage;

            // Initialize the quest display
            UpdateQuestDisplay(0, questSystem.targetKills);
        }
    }

    private void UpdateQuestDisplay(int current, int target)
    {
        // Display the active quest and progress
        questText.text = $"{questSystem.questName}: Kill Bears ({current}/{target})";
    }

    private void DisplayCompletionMessage()
    {
        // Show a quest completion message
        questText.text = $"{questSystem.questName} Completed!";
    }

    private void OnDestroy()
    {
        // Unsubscribe from events to avoid memory leaks
        if (questSystem != null)
        {
            questSystem.OnQuestUpdated -= UpdateQuestDisplay;
            questSystem.OnQuestCompleted -= DisplayCompletionMessage;
        }
    }
}

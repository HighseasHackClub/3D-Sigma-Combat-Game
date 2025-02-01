using UnityEngine;

public class QuestSystem : MonoBehaviour
{
    public string questName = "Bear Slayer"; // Name of the quest
    public int targetKills = 10;            // Number of bears to kill
    private int currentKills = 0;           // Current progress

    public delegate void QuestUpdated(int current, int target);
    public event QuestUpdated OnQuestUpdated;

    public delegate void QuestCompleted();
    public event QuestCompleted OnQuestCompleted;

    public void RegisterKill()
    {
        if (currentKills < targetKills)
        {
            currentKills++;
            OnQuestUpdated?.Invoke(currentKills, targetKills); // Notify UI or other systems

            if (currentKills >= targetKills)
            {
                CompleteQuest();
            }
        }
    }

    private void CompleteQuest()
    {
        Debug.Log($"Quest Completed: {questName}!");
        OnQuestCompleted?.Invoke(); // Trigger quest completion events
    }
}

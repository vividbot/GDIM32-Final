using UnityEngine;

public class E_QuestManager : MonoBehaviour
{
    

    [SerializeField] private GameObject testQuest;
    [SerializeField] private Transform  testQuestLocation;
    public bool TriggerQuestInspector;
    int questsCompleted;
    [SerializeField] int questsToWin;

    void Start()
    {
        questsCompleted = 0;
        Locator.Instance.newQuestStarted += TriggerQuest;
        Locator.Instance.questCompleted += CompleteQuest;
    }

    void Update()
    {
        if(TriggerQuestInspector == true)
        {
            TriggerQuest(testQuest, testQuestLocation);
        }
    }

    // Update is called once per frame
    void TriggerQuest(GameObject questType, Transform questLocation)
    {
        
        Instantiate(questType, questLocation.position, questLocation.rotation);
        Debug.Log("Quest Started");

    }
    public void CompleteQuest(string questName)
    {
        questsCompleted += 1;
        Debug.Log("You completed - " + questName);
        if(questsCompleted == questsToWin)
        {
            Debug.Log("Your shift is over!");
            UnityEditor.EditorApplication.isPlaying = false;
            
        }
    }
}

using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class E_QuestManager : MonoBehaviour
{
    

    [SerializeField] private GameObject testQuest;
    [SerializeField] private Transform  testQuestLocation;
    public bool TriggerQuestInspector;
    int questsCompleted;
    [SerializeField] int questsToWin;
    [SerializeField] TextMeshProUGUI questListText;
    

    List<string> questList = new List<string>();
    void Start()
    {
        questListText.text = "";
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
        // Debug.Log("You completed - " + questName);
        questList.Add(questName);
        questListText.text = string.Join("\n", questList);
        Debug.Log("Completed quest list updated, quests completed - " + questList.Count);
        foreach(var x in questList)
        {
            Debug.Log(x.ToString());
        }
        


        if(questsCompleted == questsToWin)
        {
            Debug.Log("Your shift is over!");
            UnityEditor.EditorApplication.isPlaying = false;
            
        }
    }
}

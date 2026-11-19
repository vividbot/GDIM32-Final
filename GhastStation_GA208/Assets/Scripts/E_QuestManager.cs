using UnityEngine;

public class E_QuestManager : MonoBehaviour
{
    

    [SerializeField] private GameObject testQuest;
    [SerializeField] private Transform  testQuestLocation;
    public bool TriggerQuestInspector;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
    Locator.Instance.newQuestStarted += TriggerQuest;

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
}

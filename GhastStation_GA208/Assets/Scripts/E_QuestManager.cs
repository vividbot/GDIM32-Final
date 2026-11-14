using Unity.VisualScripting;
using UnityEngine;

public class E_QuestManager : MonoBehaviour
{
    private GameObject questName;

    [SerializeField] GameObject testQuest;
    [SerializeField] Transform  testQuestLocation;
    public bool testQuest;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
    Locator.Instance.newQuestStarted += TriggerQuest;

    }

    // Update is called once per frame
    void TriggerQuest(GameObject questType, Transform questLocation)
    {
        
        Instantiate(questType, questLocation.position, questLocation.rotation);
        Debug.Log("Quest Started");

    }
}

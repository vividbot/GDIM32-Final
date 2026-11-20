using TMPro;
using UnityEngine;

public class UI : MonoBehaviour
{

    //Ui Variables
    private int objectCount;
    [SerializeField] private TextMeshProUGUI uiText;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gameObject.SetActive(false);

        uiText.text = "Items Stocked - 0";
        objectCount = 0;
        Locator.Instance.objectCountUpdate += ObjectCountUpdated;
        Locator.Instance.NPCInteract.QuestAssigned += QuestStarted;
    }

    void QuestStarted()
    {
        gameObject.SetActive(true);
    }

    void ObjectCountUpdated(int x)
    {
        Debug.Log("Current Items in zone - " + x);
        objectCount += x;
        uiText.text = "Items Stocked - " + objectCount;


    }
}

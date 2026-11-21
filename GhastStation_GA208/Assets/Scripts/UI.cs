using TMPro;
using UnityEngine;

public class UI : MonoBehaviour
{

    //Ui Variables


    //Temporary
    // private int restockCount;
    // private int plungerCount;
    // [SerializeField] private TextMeshProUGUI uiText_restock;
    // [SerializeField] private TextMeshProUGUI uiText_plunger;
    // [SerializeField] string plungerTag;
    // [SerializeField] string restockTag;
/// These Variables are all temporary ^^^^


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        

        // uiText_restock.text = "Items Stocked - 0";
        // restockCount = 0;
        // plungerCount = 0;

        // Locator.Instance.objectCountUpdate += ObjectCountUpdated;
        // Locator.Instance.NPCInteract.QuestAssigned += QuestStarted;
    }

    void QuestStarted()
    {
    }

    // void ObjectCountUpdated(int x, string tag)
    // {
    //     Debug.Log("Current Items in zone - " + x);
        
    //     if(tag == plungerTag)
    //     {
    //         Debug.Log("Plunger Dunked");
    //         plungerCount += x;
    //         uiText_plunger.text = "Times Plunged : " + plungerCount;

    //     }
    //     if(tag == restockTag)
    //     {
    //         Debug.Log("Item Restocked");
    //         Debug.Log("Restock Count before : " + restockCount);
    //         restockCount += x;
    //         Debug.Log("New Stock Count : " + restockCount);
    //         uiText_restock.text = "Items Stocked : " + restockCount;
    //     }

        


    // }
}

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
        uiText.text = "Items Stocked - 0";
        objectCount = 0;
        Locator.Instance.objectCountUpdate += ObjectCountUpdated;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void ObjectCountUpdated(int x)
    {
        Debug.Log("Current Items in zone - " + x);
        objectCount += x;
        uiText.text = "Items Stocked - " + objectCount;


    }
}

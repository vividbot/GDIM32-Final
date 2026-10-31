using UnityEngine;

public class E_QuestZone : MonoBehaviour
{
    /// <summary>
    /// This Script is here to handle detecting when Physics objects are placed in the correct zones and then will fire and event - 
    /// Event and Locator Scripts will come later but this script for now is going to just start by detecting Physics Objects in the correct area..
    /// </summary>

    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("QuestItem"))
        {
            // Debug.Log("Item Placed in zone");
            Locator.Instance.QuestObjectScored(1);

        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("QuestItem"))
        {
            // Debug.Log("Item Removed From Zone");
            Locator.Instance.QuestObjectScored(-1);

        } 
        // Debug.Log("Item Removed from Zone");
    }
}

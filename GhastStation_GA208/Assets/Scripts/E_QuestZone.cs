using UnityEngine;

public class E_QuestZone : MonoBehaviour
{
    /// <summary>
    /// This Script is here to handle detecting when Physics objects are placed in the correct zones and then will fire and event - 
    /// Event and Locator Scripts will come later but this script for now is going to just start by detecting Physics Objects in the correct area..
    /// </summary>
    
    [SerializeField] string tagType;
    [SerializeField] bool TrackExit;
    [SerializeField] int scoreAmmount;
    
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
        if (other.gameObject.CompareTag(tagType))
        {
            // Debug.Log("Item Placed in zone");
            Locator.Instance.QuestObjectScored(scoreAmmount, tagType);

        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag(tagType) && TrackExit == true)
        {
            Debug.Log("Item Removed From Zone");
            Locator.Instance.QuestObjectScored(-scoreAmmount, tagType);

        }
        
        // Debug.Log("Item Removed from Zone");
    }
}

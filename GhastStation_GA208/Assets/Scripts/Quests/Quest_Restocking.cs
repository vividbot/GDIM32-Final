using UnityEngine;

public class Quest_Restocking : Quest
{


    [SerializeField] GameObject restockingItemstoSpawn;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public override void Start()
    {
        base.Start();
        Debug.Log("Restocking Quest is Active");
        Instantiate(restockingItemstoSpawn, transform.position, Quaternion.identity);
    }

    public override void scoredPoint(int x, string tag)
    {
        base.scoredPoint(x, tag);
        Debug.Log("Current Items Stocked: " + score);
        
        if(score == targetScore)
        {
            Debug.Log("Restocking Complete!");
            Debug.Log("Final Score: " + score);
            Locator.Instance.finishQuest(questName);
            Destroy(gameObject);

        }
    }
}

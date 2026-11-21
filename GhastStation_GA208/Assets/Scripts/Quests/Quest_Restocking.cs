using UnityEngine;

public class Quest_Restocking : Quest
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Debug.Log("Restocking Quest is Active");

    }

    public override void scoredPoint(int x, string tag)
    {
        base.scoredPoint(x, tag);
        Debug.Log("Current Items Stocked: " + score);
    }
}

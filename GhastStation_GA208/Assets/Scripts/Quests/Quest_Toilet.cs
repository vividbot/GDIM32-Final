using UnityEngine;

public class Quest_Toilet : Quest
{
    bool PlungerActive;
    public override void Start()
    {
        base.Start();
        PlungerActive = true;
        Debug.Log("Toilet Quest is Active");
    }
    public override void scoredPoint(int x, string tag)
    {
        base.scoredPoint(x, tag);
        Debug.Log("Times Plunged: " + score);

        if(score == targetScore)
        {
            Debug.Log("You plunged the Toilet!");
            Locator.Instance.finishQuest(questName);
            
            

        }
    }


}

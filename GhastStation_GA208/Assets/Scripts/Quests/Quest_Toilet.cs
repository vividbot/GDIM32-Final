using Unity.Mathematics;
using UnityEngine;

public class Quest_Toilet : Quest
{

    GameObject plungerPositon;
    public override void Start()
    {
        base.Start();
        Debug.Log("Toilet Quest is Active");
        plungerPositon = GameObject.Find("Plunger");
        plungerPositon.transform.position = transform.position + new Vector3 (0, 1, 0);
    }
    public override void scoredPoint(int x, string tag)
    {
        base.scoredPoint(x, tag);
        Debug.Log("Times Plunged: " + score);

        if(score == targetScore)
        {
            Debug.Log("You plunged the Toilet!");
            Locator.Instance.finishQuest(questName);
            Destroy(gameObject);

        }
    }


}

using UnityEngine;

public class Quest_Toilet : Quest
{
    public bool PlungerActive;
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
    }


}

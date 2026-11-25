using System;
using UnityEngine;

public class Quest : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    protected int score;
    [SerializeField] protected int targetScore;
    [SerializeField] protected string tagType;
    [SerializeField] protected string questName;
    [SerializeField] protected GameObject uiText;
    public virtual void Start()
    {
        score = 0;
        Locator.Instance.objectCountUpdate += scoredPoint;
        UIStart();
    }

    // Update is called once per frame
    public virtual void scoredPoint(int x, string tag)
    {
        if(tagType == tag)
        {
            score += x;

        }
        // Ovveride logic depending on what you want to do with each method paramater. 
        
    }
    public virtual void OnDisable()
    {
        Locator.Instance.objectCountUpdate -= scoredPoint;
        UIStop();

    }

    public virtual void UIStart()
    {
        //Instantiates whatever UI Text or UI prefab is needed for each quest
        //Can Be overridden if there are specific things needed to be done (IE Plunger quest has some sort of health bar thing)
    }
    public virtual void UIStop()
    {
        //Removes UI From Canvas once Task is complete and script is Disabled
    }


}

using UnityEngine;

public class Quest : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    protected int score;
    [SerializeField] protected int targetScore;
    [SerializeField] protected string tagType;
    [SerializeField] protected string questName;
    public virtual void Start()
    {
        score = 0;
        Locator.Instance.objectCountUpdate += scoredPoint;
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


}

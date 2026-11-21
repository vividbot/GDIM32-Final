using UnityEngine;

public class Quest : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    
    void Start()
    {
        Locator.Instance.objectCountUpdate += scoredPoint;
    }

    // Update is called once per frame
    public virtual void scoredPoint(int score, string tag)
    {
        // Ovveride logic depending on what you want to do with each method paramater. 
        
    }


}

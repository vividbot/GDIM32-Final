using UnityEngine;
using TMPro;


public class Quest : MonoBehaviour
{
    protected int score;

    [Header("Basic Quest Paramaters")]
    [SerializeField] protected int targetScore;
    [SerializeField] protected string questName;
    [SerializeField] protected string tagType;
    [Header("Quest UI Paramaters")]
    [SerializeField] protected TextMeshProUGUI uiTextPreFab;
    protected TextMeshProUGUI uiText;
    [SerializeField] protected string questText;
    protected GameObject canvasParent;
    public virtual void Start()
    {
        score = 0;
        Locator.Instance.objectCountUpdate += scoredPoint;
        UIStart();
        Debug.Log("Starting Score" + score);
    }

    // Update is called once per frame
    public virtual void scoredPoint(int x, string tag)
    {
        if(tagType == tag)
        {
            score += x;
            
            uiText.text = questText + " " + score;

        }
        // Ovveride logic depending on what you want to do with each method paramater. 
        
    }

    public virtual void UIStart()
    {
        //Instantiates whatever UI Text or UI prefab is needed for each quest
        //Can Be overridden if there are specific things needed to be done (IE Plunger quest has some sort of health bar thing)
        canvasParent = GameObject.FindWithTag("Canvas");
        uiText = Instantiate(uiTextPreFab, canvasParent.transform, false);
        // Instantiate(uiText, canvasParent, false);
        uiText.text = questText + " " + score;
    }
    public virtual void UIStop()
    {
        Destroy(uiText);
        //Removes UI From Canvas once Task is complete and script is Disabled
    }
    public virtual void OnDisable()
    {
        Locator.Instance.objectCountUpdate -= scoredPoint;
        UIStop();

    }




}

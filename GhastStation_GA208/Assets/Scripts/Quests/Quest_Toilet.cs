using UnityEngine;

public class Quest_Toilet : MonoBehaviour
{


    /// <summary>
    /// Pretend for now there is logic here written to handle the plunger quest idk. 
    /// 
    /// 
    /// Probably take info from quest zone script and locator, and add UI when this script is started,
    /// Thinking store the score in the quest manager script?
    /// 
    /// figuring it out
    /// </summary>
    public bool PlungerActive;
    public static Quest_Toilet Instance { get; private set; }

    void Start()
    {
        // PlungerActive = true;
        // if(Instance != null && Instance == this)
        // {
        //     Destroy(this);
        //     return;
        // }

        // Instance = this;

        Debug.Log("Toilet Quest is Active");
    }
}

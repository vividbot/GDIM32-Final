using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class Locator : MonoBehaviour
{
    public static Locator Instance { get; private set; }
    public PickupController PickUp { get; private set; }
    public PlayerScript Player { get; private set; }

    private int currentPoints;

    private void Awake()
    {
        if(Instance != null && Instance == this)
        {
            Destroy(this);
            return;
        }

        Instance = this;

        GameObject playerObj = GameObject.FindWithTag("Player");
        GameObject camera = GameObject.FindWithTag("MainCamera");
        PickUp = camera.GetComponent<PickupController>();
        Player = playerObj.GetComponent<PlayerScript>();
    }

    public virtual void QuestObjectScored(int pointsScored)
    {
        currentPoints += pointsScored;   
        Debug.Log("Objects in Zone - " + currentPoints);
        
    }
}

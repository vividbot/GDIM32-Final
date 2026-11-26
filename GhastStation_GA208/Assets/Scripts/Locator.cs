using System;
using System.Collections.Specialized;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class Locator : MonoBehaviour
{
    public static Locator Instance { get; private set; }
    public PickupController PickUp { get; private set; }
    public PlayerScript Player { get; private set; }
    public Q_NPCInteract NPCInteract { get; private set; }

    public delegate void ObjectsPlaced(int x, string tag);
    public event ObjectsPlaced objectCountUpdate;

    public delegate void QuestTriggered(GameObject questName, Transform questLocation);
    public event QuestTriggered newQuestStarted;
    public delegate void IncreaseTotalScore(string questName);
    public event IncreaseTotalScore questCompleted;


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
        GameObject NPC = GameObject.FindWithTag("NPC");

        PickUp = camera.GetComponent<PickupController>();
        Player = playerObj.GetComponent<PlayerScript>();
    }

    public virtual void QuestObjectScored(int pointsScored, string QuestType)
    {
        
        // Debug.Log("Objects in Zone - " + currentPoints);
        objectCountUpdate.Invoke(pointsScored, QuestType);
        Debug.Log(pointsScored + " " + QuestType);

    }

    public virtual void TriggerQuest(GameObject questObject, Transform location)
    {

        Debug.Log("Locator Received Quest trigger input.");
        newQuestStarted.Invoke(questObject, location);
    }

    public virtual void finishQuest(string questName)
    {
        Debug.Log("Locator Recieved End quest Request");
        questCompleted.Invoke(questName);
    }
}

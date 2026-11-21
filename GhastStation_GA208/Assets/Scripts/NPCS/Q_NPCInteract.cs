using System;
using System.Collections;
using TMPro;
using UnityEngine;

public enum GhostTalkStates
{
    NotTalking,
    Talking,
}
public class Q_NPCInteract : MonoBehaviour
{
    public delegate void EmptyDelagate();
    public event EmptyDelagate QuestAssigned; 

    private GhostTalkStates ghostState;

    [Header("Dialog Distance Variables")]
    [SerializeField] private float minTalkingDistance = 5f;
    [SerializeField] private bool isWithinTalkingDistance = false;


    [Header("NPC Quest")]
    [SerializeField] private GameObject questObject;
    [SerializeField] private Transform questLocation;
    [SerializeField] private bool canGiveTask = true;

    [Header("Dialog Settings")]
    public string[] lines;
    [SerializeField] private float textSpeed;
    [SerializeField] private TextMeshProUGUI dialogText;
    [SerializeField] private GameObject dialogBox;
    private int index;

    //player vector
    private Vector3 playerPosition;

    void Start()
    {
        Locator.Instance.Player.Interacted += PlayerInteract;
        ghostState = GhostTalkStates.NotTalking;
        dialogText.text = string.Empty;
    }

    void Update()
    {
        PlayerScript player = Locator.Instance.Player;
        playerPosition = player.transform.position;

        if(Vector3.Distance(transform.position, playerPosition) <= minTalkingDistance)
        {
            isWithinTalkingDistance = true;
        }
        else
        {
            isWithinTalkingDistance = false;
            ghostState = GhostTalkStates.NotTalking;
            EndDialog();
        }

    }

    public void PlayerInteract()
    {
        if (!isWithinTalkingDistance)
        {
            return;
        }

        else if (isWithinTalkingDistance && ghostState == GhostTalkStates.NotTalking)
        {
            StartDialog();

            Debug.Log("talking to npc");
            ghostState = GhostTalkStates.Talking;

            if (canGiveTask == true)
            {
                Locator.Instance.TriggerQuest(questObject, questLocation);
                QuestAssigned?.Invoke();
                Debug.Log("I am giving you a quest!");
                canGiveTask = false;
            }

        }
        else if(isWithinTalkingDistance && ghostState == GhostTalkStates.Talking)
        {
            NextLine();
        }

    }

    void StartDialog()
    {
        Debug.Log("Meow");  
        dialogBox.SetActive(true);
        index = 0;
        StartCoroutine(TypeLine());

    }
    void NextLine()
    {
        if (index < lines.Length - 1)
        {
            index++;
            dialogText.text = string.Empty;
            StartCoroutine(TypeLine());
        }
        else
        {
            EndDialog();
        }
    }

    void EndDialog()
    {
        StopCoroutine(TypeLine());
        dialogBox.SetActive(false);
        dialogText.text = string.Empty;
        ghostState = GhostTalkStates.NotTalking;
    }

    IEnumerator TypeLine()
    {
        foreach (char c in lines[index].ToCharArray())
        {
            dialogText.text += c;
            yield return new WaitForSeconds(textSpeed);
        }
    }
}

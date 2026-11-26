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

    [SerializeField] private GhostTalkStates ghostState;

    [Header("Dialog Distance Variables")]
    [SerializeField] private float minTalkingDistance = 5f;
    [SerializeField] private bool isWithinTalkingDistance = false;
    [SerializeField] private GameObject withinRangeIndicator;

    [Header("NPC Quest")]
    [SerializeField] private GameObject questObject;
    [SerializeField] private Transform questLocation;
    [SerializeField] private string questAssigned;
    [SerializeField] private bool canGiveTask = true;
    [SerializeField] private bool taskCompleted = false;

    [Header("Dialog Settings")]

    [SerializeField] private NPCDialog lines;
    [SerializeField] private string[] currentLines;
    [SerializeField] private float textSpeed;
    [SerializeField] private TextMeshProUGUI dialogText;
    [SerializeField] private GameObject dialogBox;
    private int index;

    //player vector
    public Vector3 playerPosition;

    void Start()
    {
        Locator.Instance.Player.Interacted += PlayerInteract;
        Locator.Instance.questCompleted += NPCTaskCompleted;

        ghostState = GhostTalkStates.NotTalking;

        currentLines = lines.taskAssignedDialog;

        dialogText.text = string.Empty;
    }

    void Update()
    {
        PlayerScript player = Locator.Instance.Player;
        playerPosition = player.transform.position;

        if(Vector3.Distance(transform.position, playerPosition) <= minTalkingDistance)
        {
            isWithinTalkingDistance = true;
            withinRangeIndicator.SetActive(true);
        }
        else
        {
            isWithinTalkingDistance = false;
            withinRangeIndicator.SetActive(false);
        }

    }

    public void PlayerInteract()
    {
        if (!isWithinTalkingDistance && ghostState == GhostTalkStates.NotTalking)
        {
            return;
        }

        else if (isWithinTalkingDistance && ghostState == GhostTalkStates.NotTalking)
        {
            UpdateLines();
            StartDialog();
            ghostState = GhostTalkStates.Talking;

            if (canGiveTask == true)
            {
                Locator.Instance.TriggerQuest(questObject, questLocation);
                QuestAssigned?.Invoke();
                canGiveTask = false;
            }

        }
        else if(ghostState == GhostTalkStates.Talking)
        {
            StopAllCoroutines();
            NextLine();
        }

    }

    void StartDialog()
    {
        dialogBox.SetActive(true);
        index = 0;

        StartCoroutine(TypeLine());

    }
    void NextLine()
    {
        if (index < currentLines.Length - 1)
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
        dialogBox.SetActive(false);
        dialogText.text = string.Empty;
        ghostState = GhostTalkStates.NotTalking;
    }

    IEnumerator TypeLine()
    {
        foreach (char c in currentLines[index].ToCharArray())
        {
            dialogText.text += c;
            yield return new WaitForSeconds(textSpeed);
        }
    }

    void UpdateLines()
    {
        if(!taskCompleted)
        {
            currentLines = lines.taskAssignedDialog;
        }
        else if(taskCompleted)
        {
            currentLines = lines.taskCompletedDialog;
        }
    }

    void NPCTaskCompleted(string questName)
    {
        if(questName == questAssigned)
        {
            taskCompleted = true;
        }
    }

}

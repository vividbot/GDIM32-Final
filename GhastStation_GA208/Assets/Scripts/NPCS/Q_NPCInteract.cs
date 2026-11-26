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
    [SerializeField] private bool canGiveTask = true;

    [Header("Dialog Settings")]

    [SerializeField] private NPCDialog lines;
    //string[] lines;
    [SerializeField] private float textSpeed;
    [SerializeField] private TextMeshProUGUI dialogText;
    [SerializeField] private GameObject dialogBox;
    private int index;

    //player vector
    public Vector3 playerPosition;

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
            NextLine();
        }

    }

    void StartDialog()
    {
        dialogBox.SetActive(true);
        index = 0;

        StopCoroutine(TypeLine());
        StartCoroutine(TypeLine());

    }
    void NextLine()
    {
        if (index < lines.dialogLine.Length - 1)
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
        foreach (char c in lines.dialogLine[index].ToCharArray())
        {
            dialogText.text += c;
            yield return new WaitForSeconds(textSpeed);
        }
    }
}

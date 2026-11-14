using UnityEngine;

public enum GhostTalkStates
{
    NotTalking,
    Talking,
}
public class Q_NPCInteract : MonoBehaviour
{
    public delegate void EmptyDelagate();
    public event EmptyDelagate QuestAssigned; //invoke this event when needed, not sure of a place for it right now.

    [Header("Dialog Distance Variables")]
    [SerializeField] private float minTalkingDistance = 5f;
    [SerializeField] private bool isWithinTalkingDistance = false;
    [SerializeField] private GameObject dialogBox;
    private GhostTalkStates ghostState;

    //player vector
    private Vector3 playerPosition;

    void Start()
    {
        Locator.Instance.Player.Interacted += PlayerInteract;
        ghostState = GhostTalkStates.NotTalking;
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
            dialogBox.SetActive(false);
        }

    }

    public void PlayerInteract()
    {
        if (!isWithinTalkingDistance)
        {
            Debug.Log("You aren't within range silly");
            //I will add actual dialog when I get home. I have some scripts from a project on my computer that will work pretty well for dialog I think.
            return;
        }
        else if (isWithinTalkingDistance && ghostState == GhostTalkStates.NotTalking)
        {
            Debug.Log("talking to npc");
            //set UI to active
            dialogBox.SetActive(true); 
            //placeholder just to get it working. For now, to escape the dialog box, you need to walk away from the npc.
            //I will make it so if you press E when dialog is exhausted it will close
            ghostState = GhostTalkStates.Talking;
            //trigger quest?
        }
        else if(isWithinTalkingDistance && ghostState == GhostTalkStates.Talking)
        {
            //move onto next dialog line
            Debug.Log("Moved onto next dialog option");
        }

    }
}

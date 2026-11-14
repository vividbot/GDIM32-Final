using UnityEngine;

public enum GhostTalkStates
{
    NotTalking,
    Talking,
}
public class Q_NPCInteract : MonoBehaviour
{
    [Header("Dialog Distance Variables")]
    [SerializeField] private float minTalkingDistance = 5f;
    [SerializeField] private bool isWithinTalkingDistance = false;

    private GhostTalkStates ghostState;

    //player
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
        }

    }

    public void PlayerInteract()
    {
        if (!isWithinTalkingDistance)
        {
            Debug.Log("You aren't within range silly");
            return;
        }
        else if (isWithinTalkingDistance && ghostState == GhostTalkStates.NotTalking)
        {
            Debug.Log("talking to npc");
            //set UI to active
            ghostState = GhostTalkStates.Talking;
        }
        else if(isWithinTalkingDistance && ghostState == GhostTalkStates.Talking)
        {
            //move onto next dialog line
            Debug.Log("Moved onto next dialog option");
        }

    }
}

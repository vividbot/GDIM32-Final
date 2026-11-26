using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [Header("Quest Audio")]
    [SerializeField] AudioSource questAssignedAudio;


    void Start()
    {
        Locator.Instance.NPCInteract.QuestAssigned += PlayQuestAssigned;
    }
    void PlayQuestAssigned()
    {
        Debug.Log("play quest sound");

        questAssignedAudio.Play();
    }

}

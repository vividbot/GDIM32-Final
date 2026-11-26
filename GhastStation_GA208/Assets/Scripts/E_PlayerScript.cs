
using UnityEngine;
using UnityEngine.Assemblies;

public class PlayerScript : MonoBehaviour
{
    //events
    public delegate void EmptyDelagate();
    public event EmptyDelagate Interacted;

    [SerializeField] private float moveSpeed = 10.0f; 
    [SerializeField] private float webSpeedMultiplier = 0.5f;

    private CharacterController controller;   


    //Testing stuff
    [SerializeField] GameObject QuestToSpawn;
    [SerializeField] Transform QuestPosition;
     
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        #if UNITY_WEBGL
        moveSpeed *= webSpeedMultiplier;
        #endif
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {

        //Test Quest Triggering

        if (Input.GetKeyDown(KeyCode.T))
        {
            Locator.Instance.TriggerQuest(QuestToSpawn, QuestPosition);
        }

        // Handle Player movement
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;
        controller.SimpleMove(move * moveSpeed * Time.deltaTime);

        if (Input.GetKeyDown(KeyCode.E))
        {
            Interacted?.Invoke();
        }

    }

}

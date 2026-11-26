
using UnityEngine;
using UnityEngine.Assemblies;

public class PlayerScript : MonoBehaviour
{
    //events
    public delegate void EmptyDelagate();
    public event EmptyDelagate Interacted;

    [SerializeField] private float moveSpeed = 10.0f;
    [SerializeField] private float groundDrag;
    [SerializeField] private float webSpeedMultiplier = 0.5f;
    private Rigidbody rb;

    private float horizontalMovement;
    private float verticalMovement;


    //Testing stuff
    [SerializeField] GameObject QuestToSpawn;
    [SerializeField] Transform QuestPosition;
     
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        #if UNITY_WEBGL
        moveSpeed *= webSpeedMultiplier;
        #endif
        //controller = GetComponent<CharacterController>();
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {

        // Handle Player movement
        horizontalMovement = Input.GetAxis("Horizontal");
        verticalMovement = Input.GetAxis("Vertical");

        rb.linearDamping = groundDrag;

        //Test Quest Triggering
        if (Input.GetKeyDown(KeyCode.T))
        {
            Locator.Instance.TriggerQuest(QuestToSpawn, QuestPosition);
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            Interacted?.Invoke();
        }

    }

    private void FixedUpdate()
    {
        Vector3 move = transform.right * horizontalMovement + transform.forward * verticalMovement;

        rb.AddForce(move.normalized * moveSpeed, ForceMode.Force);
    }
}

using UnityEngine;
public enum RatStates
{
    Running,
    Grabbed,
    Thrown,
}
public class RatMovement : MonoBehaviour
{
    //State Machine
    RatStates currentState;

    //script needs to find a way to speak with the pick up script to switch states... Maybe through events?
    //PickUpController script triggers event, RatMovement listens for it and triggers based on when the player picks up rat or throws/drops it...

    [Header("Rat Game Objects")] 
    [SerializeField] private GameObject ratOnGround;
    [SerializeField] private GameObject ratInAir;

    [Header("Rat Movement Variables")]
    [SerializeField]  private float ratSpeed = 4f;
    [SerializeField] private float ratDirectionChangeRate = 1f;
    private Rigidbody ratRB;

    private void Start()
    {
       ratRB = GetComponent<Rigidbody>();
    }
    private void Update()
    {
        if(currentState == RatStates.Running)
        {
            ratDirectionChangeRate =- Time.deltaTime;

            RatMove();

            if (ratDirectionChangeRate < 0)
            {
                //change direction logic. 
                //needs to pause for a second, then rotate, and then start moving again.
            }
        }
    }

    public void RatMove()
    {
        // needs to move forward in a way that is smooth and compliant with a rigidbody.
        // also needs to pause briefly? Is moving also on a timer, just like the direction change? Maybe it's the same timer. hhrg.
        // everything i can find online seems so overcomplicated for what this script needs to be...
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            currentState = RatStates.Running;
            Debug.Log("Is Running");
        }
    }
}

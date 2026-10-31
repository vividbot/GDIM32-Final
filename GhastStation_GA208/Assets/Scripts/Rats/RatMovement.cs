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

    /*
    [Header("Rat Game Objects")] 
    [SerializeField] private GameObject ratOnGround;
    [SerializeField] private GameObject ratInAir;

    Saving this just in case I reapproach the double GameObject solution.
    */

    private void Start()
    {

    }
    private void Update()
    {

    }
}
